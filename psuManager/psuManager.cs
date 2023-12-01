using System.IO.Ports;
using System.Text.Json;

namespace PsuManager;

public enum PsuType
{
    Psu2000,
    Psu3000
}

public static class PsuFactory
{
    public static IPsu CreatePsu(PsuType psuType)
    {
        switch (psuType)
        {
            case PsuType.Psu2000:
                return new Psu2000();
            case PsuType.Psu3000:
                return new Psu3000();
            default:
                throw new ArgumentException("Unsupported PSU type: " + psuType);
        }
    }
}

public interface IPsu
{
    // Project requirements
    public void SetVoltage(float setVolt);
    public string GetVoltage();
    public string GetCurrent();
    public void StopOperation();
    public void LockUnlock();
    
    // Custom
    public string GetSerialNumber();
}

public class Psu2000 : IPsu
{
    public void SetVoltage(float setVolt)
    {
        var com = GetComport();

        // Calculate the percentage of Unom * 256
        var percentVoltage = (int)setVolt; // Assuming voltage is a floating-point value

        // Construct the command to set the voltage
        int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5;
        byte SD = Convert.ToByte(SDHex.ToString(), 10);

        // SD, DN, OBJ, DATA (set value command)
        byte[] byteWithOutCheckSum = { SD, (int)0x01, (int)0x50, (byte)(percentVoltage & 0xFF), (byte)((percentVoltage >> 8) & 0xFF) };
        
        //SD = MessageType + CastType + Direction + Length
        //int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
        //byte SD = Convert.ToByte(SDHex.ToString(), 10);

        //SD, DN, OBJ, DATA, CS
        //byte[] byteWithOutCheckSum = { SD, (int)0x00, (int)0x47, 0x0, 0x0 }; // quert status

        // Calculate checksum and update the command
        int sum = byteWithOutCheckSum.Sum(b => (int)b);
        string hexSum = sum.ToString("X");
        string cs1 = hexSum.Substring(0, 2);
        string cs2 = hexSum.Substring(2);

        byteWithOutCheckSum[byteWithOutCheckSum.Length-2] = Convert.ToByte(cs1, 16);
        byteWithOutCheckSum[byteWithOutCheckSum.Length-1] = Convert.ToByte(cs2, 16);


        List<byte> responseTelegram;
        using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            // write to the USB port
            port.Write(byteWithOutCheckSum, 0, byteWithOutCheckSum.Length);
            Thread.Sleep(500);

            responseTelegram = new List<byte>();
            int length = port.BytesToRead;
            if (length > 0)
            {
                byte[] message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    //Console.WriteLine(t);
                    responseTelegram.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
        }
    }

    public string GetVoltage()
    {
        /* ----- First, we read the "wrong" voltage ----- */
        var com = GetComport();
        
        //SD = MessageType + CastType + Direction + Length
        var sdHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
        var sd = Convert.ToByte(sdHex.ToString(), 10);
        
        //SD, DN, OBJ, DATA, CS
        byte[] byteWithOutCheckSum = { sd, (int)0x00, (int)0x47, 0x0, 0x0 }; // quert status

        var sum = 0;
        var arrayLength = byteWithOutCheckSum.Length;
        for (var i = 0; i < arrayLength; i++)
        {
            sum += byteWithOutCheckSum[i];
        }

        var hexSum = sum.ToString("X");
        var cs1 = "";
        var cs2 = "";
        switch (hexSum.Length)
        {
            case 4:
                cs1 = hexSum.Substring(0, hexSum.Length / 2);
                cs2 = hexSum.Substring(hexSum.Length / 2);
                break;
            case 3:
                cs1 = hexSum.Substring(0, 1);
                cs2 = hexSum.Substring(1);
                break;
            case 2:
            case 1:
                cs1 = "0";
                cs2 = hexSum;
                break;
        }

        if (cs1 != "")
        {
            byteWithOutCheckSum[arrayLength - 2] = Convert.ToByte(cs1, 16);
            byteWithOutCheckSum[arrayLength - 1] = Convert.ToByte(cs2, 16);
        }

        // now the byte array is ready to be sent
        List<byte> responseTelegram;
        using (var port = new SerialPort(com, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            // write to the USB port
            port.Write(byteWithOutCheckSum, 0, byteWithOutCheckSum.Length);
            Thread.Sleep(500);

            responseTelegram = new List<byte>();
            var length = port.BytesToRead;
            if (length > 0)
            {
                byte[] message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    //Console.WriteLine(t);
                    responseTelegram.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
        }
        
        var percentVoltString = responseTelegram[5].ToString("X") + responseTelegram[6].ToString("X");
        var percentVoltInt = Convert.ToInt32(percentVoltString, 16);
        var percentVolt = Convert.ToDouble(percentVoltInt.ToString("0.00"));

        /* ----- Then we get the nominal voltage ----- */
        var nominalVoltage = GetNominalVoltage();
        
        /* ----- Lastly, we convert to the actual voltage ----- */
        var volt = (double)percentVolt * nominalVoltage / 25600;
        return volt.ToString("0.00");
    }

    public string GetCurrent()
    {
        throw new NotImplementedException();
    }

    public void StopOperation()
    {
        throw new NotImplementedException();
    }

    public void LockUnlock()
    {
        throw new NotImplementedException();
    }

    // Custom methods
    public string GetSerialNumber()
    {
        var com = GetComport();
        // reading serial number
        List<byte> serialresponse;
        // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
        // OBJ = 0x01 = 1
        byte[] serialBytesToSend = { 0x7F, 0x00, 0x01, 0x00, 0x80 };
        using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            // write to the USB port
            port.Write(serialBytesToSend, 0, serialBytesToSend.Length);
            Thread.Sleep(500);

            serialresponse = new List<byte>();
            int length = port.BytesToRead;
            if (length > 0)
            {
                byte[] message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    //Console.WriteLine(t);
                    serialresponse.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);

            string binary = Convert.ToString(serialresponse[0], 2);
            string payloadLengtBinaryString = binary.Substring(4);
            int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

            string serialNumberString = "";

            if (serialresponse[2] == 1) // means that I got a response on obj, which is refers to the object list.
            {
                for (var i = 0; i < payloadLength; i++)
                {
                    serialNumberString += Convert.ToChar(serialresponse[3 + i]);
                }
            }

            return serialNumberString;
        }
    }
    
    private static string? GetComport()
    {
        // Read the entire JSON file content as a string
        var jsonString = File.ReadAllText(@"./PsuManager/comport.json");

        // Use JsonDocument to parse the JSON string
        var document = JsonDocument.Parse(jsonString);
        // Access the root object
        var root = document.RootElement;

        // Access the value of the "comport" property
        var comportElement = root.GetProperty("comport");

        // Convert the JsonElement to a C# string
        return comportElement.GetString();
    }
    
    private double GetNominalVoltage()
    {
        var com = GetComport();
        
        List<byte> response;
        byte[] bytesToSend = { 0x74, 0x00, 0x02, 0x00, 0x76 };
        using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            port.Write(bytesToSend, 0, bytesToSend.Length);
            Thread.Sleep(50);
            response = new List<byte>();
            var length = port.BytesToRead;
            if (length > 0)
            {
                var message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    response.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
        }

        byte[] byteArray = { response[6], response[5], response[4], response[3] };
        return BitConverter.ToSingle(byteArray, 0);
    }
}

internal class Psu3000 : IPsu
{
    public void SetVoltage(float setVolt)
    {
        throw new NotImplementedException();
    }

    public string GetVoltage()
    {
        throw new NotImplementedException();
    }

    public string GetCurrent()
    {
        throw new NotImplementedException();
    }

    public void StopOperation()
    {
        throw new NotImplementedException();
    }

    public void LockUnlock()
    {
        throw new NotImplementedException();
    }

    public string GetSerialNumber()
    {
        throw new NotImplementedException();
    }
}