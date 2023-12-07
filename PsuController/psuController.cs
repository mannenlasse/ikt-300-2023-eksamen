using System.IO.Ports;
using System.Text.Json;

namespace PsuController;

public enum PsuType
{
    Psu2000,
    Psu3000,
    Dummy
}

public static class PsuFactory
{
    public static IPsu CreatePsu(PsuType psuType)
    {
        switch (psuType)
        {
            case PsuType.Dummy:
                return new Dummy();
            case PsuType.Psu2000:
                return new Psu2000("temp");
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
    public string ComPort { get; private set; }
    public string SerialNumber { get; private set; }
    
    public Psu2000(string comPort)
    {
        ComPort = comPort;
        ActivateRemoteControl();
        SerialNumber = GetSerialNumber();
    }
    
    public void SetVoltage(float setVolt)
    {
        int percentSetValue = (int)Math.Round((25600 * setVolt) / 84);

        string hexValue = percentSetValue.ToString("X");
        string hexValue1 = "";
        string hexValue2 = "";

        if (hexValue.Length == 4)
        {
            hexValue1 = hexValue.Substring(0, hexValue.Length / 2);
            hexValue2 = hexValue.Substring(hexValue.Length / 2);
        }
        else if (hexValue.Length == 3)
        {
            hexValue1 = hexValue.Substring(0, 1);
            hexValue2 = hexValue.Substring(1);
        }
        else if ((hexValue.Length is 2) || (hexValue.Length is 1))
        {
            hexValue1 = "0";
            hexValue2 = hexValue;
        }
        byte[] newbytesWithoutChecksum = { 0xF2, 0x00, 0x32, Convert.ToByte(hexValue1, 16), Convert.ToByte(hexValue2, 16), 0x0, 0x0 };

        int newsum = 0;
        int newarrayLength = newbytesWithoutChecksum.Length;
        for (int i = 0; i < newarrayLength; i++)
        {
            newsum += newbytesWithoutChecksum[i];
        }

        string newhexSum = newsum.ToString("X");
        string newcs1 = "";
        string newcs2 = "";
        if (newhexSum.Length == 4)
        {
            newcs1 = newhexSum.Substring(0, newhexSum.Length / 2);
            newcs2 = newhexSum.Substring(newhexSum.Length / 2);
        }
        else if (newhexSum.Length == 3)
        {
            newcs1 = newhexSum.Substring(0, 1);
            newcs2 = newhexSum.Substring(1);
        }
        else if ((newhexSum.Length is 2) || (newhexSum.Length is 1))
        {
            newcs1 = "0";
            newcs2 = newhexSum;
        }

        if (newcs1 != "")
        {


            newbytesWithoutChecksum[newarrayLength - 2] = Convert.ToByte(newcs1, 16);
            newbytesWithoutChecksum[newarrayLength - 1] = Convert.ToByte(newcs2, 16);
        }

        List<byte> newResponseTelegram;
        using (SerialPort port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            // write to the USB port
            port.Write(newbytesWithoutChecksum, 0, newbytesWithoutChecksum.Length);
            Thread.Sleep(500);

            newResponseTelegram = new List<byte>();
            int length = port.BytesToRead;
            if (length > 0)
            {
                byte[] message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    //Console.WriteLine(t);
                    newResponseTelegram.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
        }
        if (newResponseTelegram[3] == 0)
        {
            Console.WriteLine("New voltage was set");
        }
        else
        {
            Console.WriteLine(newResponseTelegram[3].ToString());
        }
    }

    public string GetVoltage()
    {
        /* ----- First, we read the "wrong" voltage ----- */
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
        using (var port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
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
        /* ----- First, we read the "wrong" current ----- */
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
        using (var port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
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
                var message = new byte[length];
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
        
        Console.WriteLine(responseTelegram.Count);
        
        var percentCurrentString = responseTelegram[7].ToString("X") + responseTelegram[8].ToString("X");
        var percentCurrentInt = Convert.ToInt32(percentCurrentString, 16);
        var percentCurrent = Convert.ToDouble(percentCurrentInt.ToString("0.00"));

        /* ----- Then we get the nominal current ----- */
        var nominalCurrent = GetNominalCurrent();
        
        /* ----- Lastly, we convert to the actual current ----- */
        var volt = (double)percentCurrent * nominalCurrent / 25600;
        return volt.ToString("0.00");
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
        // reading serial number
        List<byte> serialresponse;
        // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
        // OBJ = 0x01 = 1
        byte[] serialBytesToSend = { 0x7F, 0x00, 0x01, 0x00, 0x80 };
        using (SerialPort port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
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
        var jsonString = File.ReadAllText(@"./PsuController/comport.json");

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
        List<byte> response;
        byte[] bytesToSend = { 0x74, 0x00, 0x02, 0x00, 0x76 };
        using (var port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
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

    private double GetNominalCurrent()
    {
        List<byte> response;
        byte[] bytesToSend = { 0x74, 0x00, 0x03, 0x00, 0x77 };
        using (var port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
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
    
    private void ActivateRemoteControl()
    {
        var bytesToSendToTurnOnRc = new byte[] { 0xF1, 0x00, 0x36, 0x10, 0x10, 0x01, 0x47 }; // Turn on remote control
        using (SerialPort port = new SerialPort(ComPort, 115200, 0, 8, StopBits.One))
        {
            Thread.Sleep(500);
            port.Open();
            port.Write(bytesToSendToTurnOnRc, 0, bytesToSendToTurnOnRc.Length);
            Thread.Sleep(50);
            var rcResponse = new List<byte>();
            var length = port.BytesToRead;
            if (length > 0)
            {
                var message = new byte[length];
                port.Read(message, 0, length);
                foreach (var t in message)
                {
                    rcResponse.Add(t);
                }
            }
            port.Close();
            Thread.Sleep(500);
            if (rcResponse[3] ==0)
            {
                //Console.WriteLine("Remote Control is turned on");
            }
            else
            {
                Console.WriteLine($"Remote control is not turned on due to error: {rcResponse[3].ToString()}");
            }
        }
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


internal class Dummy : IPsu
{
    private float  voltage;
    private float current;
    private string serialnumber;
    
        
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
