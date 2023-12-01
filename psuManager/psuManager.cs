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


    public string GetVolt()
    {
        string com = GetComport();
        int percentVolt = 0;

        // Get voltage

        //SD = MessageType + CastType + Direction + Length
        int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
        byte SD = Convert.ToByte(SDHex.ToString(), 10);

        System.Diagnostics.Debug.WriteLine("SD:" + SD);

        //SD, DN, OBJ, DATA, CS
        byte[] byteWithOutCheckSum = { SD, (int)0x00, (int)0x47, 0x0, 0x0 }; // quert status

        int sum = 0;
        int arrayLength = byteWithOutCheckSum.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            sum += byteWithOutCheckSum[i];
        }

        string hexSum = sum.ToString("X");
        string cs1 = "";
        string cs2 = "";
        if (hexSum.Length == 4)
        {
            cs1 = hexSum.Substring(0, hexSum.Length / 2);
            cs2 = hexSum.Substring(hexSum.Length / 2);
        }
        else if (hexSum.Length == 3)
        {
            cs1 = hexSum.Substring(0, 1);
            cs2 = hexSum.Substring(1);
        }
        else if ((hexSum.Length is 2) || (hexSum.Length is 1))
        {
            cs1 = "0";
            cs2 = hexSum;
        }

        if (cs1 != "")
        {


            byteWithOutCheckSum[arrayLength - 2] = Convert.ToByte(cs1, 16);
            byteWithOutCheckSum[arrayLength - 1] = Convert.ToByte(cs2, 16);
        }

        // now the byte array is ready to be sent

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

        if (responseTelegram == null)
        {
            string error = "No telegram was read";
            return error;
        }
        else
        {
            string percentVoltString = responseTelegram[5].ToString("X") + responseTelegram[6].ToString("X");
            percentVolt = Convert.ToInt32(percentVoltString, 16);
            return percentVolt.ToString("0.00");
        }
    }

    public string GetVoltage()
    {
        string com = GetComport();
        float nominalVoltage = 0;
        double volt;
        //  Get Nominal Voltage
        List<byte> response;
        byte[] bytesToSend = { 0x74, 0x00, 0x02, 0x00, 0x76 };
        using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))


        {
            Thread.Sleep(500);
            port.Open();
            port.Write(bytesToSend, 0, bytesToSend.Length);
            Thread.Sleep(50);
            response = new List<byte>();
            int length = port.BytesToRead;
            if (length > 0)
            {
                byte[] message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    response.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
        }
        if (response == null)
        {
            Console.WriteLine("No telegram was read");
            return "Not found";
        }
        else
        {
            byte[] byteArray = { response[6], response[5], response[4], response[3] };
            nominalVoltage = BitConverter.ToSingle(byteArray, 0);
            double percentVolt = Convert.ToDouble(GetVolt());
            volt = (double)percentVolt * nominalVoltage / 25600;
            return volt.ToString("0.00");
        }
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