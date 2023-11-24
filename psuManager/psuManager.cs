namespace psuManager
{
    using System;
    using System.Collections;
    using System.IO.Ports;
    using System.Net.WebSockets;




        public interface IPSU
    {
        public string getNominalVolt();
        public string getNominalWatt();
        public string getSerialNumber();

        public string getManufacture();

        public string getSoftVersion();

        public string getDeviceType();

        public string getArticleNumber();

        public void setVoltage(int setVolt);

        public int remoteOnOf();

        
    }








    internal class PSU3000 : IPSU
    {
        public string getArticleNumber()
        {
            throw new NotImplementedException();
        }

        public string getDeviceType()
        {
            throw new NotImplementedException();
        }

        public string getManufacture()
        {
            throw new NotImplementedException();
        }

        public string getNominalVolt()
        {
            throw new NotImplementedException();
        }

        public string getNominalWatt()
        {
            throw new NotImplementedException();
        }

        public string getSerialNumber()
        {
            throw new NotImplementedException();
        }

        public string getSoftVersion()
        {
            throw new NotImplementedException();
        }

        public int remoteOnOf()
        {
            throw new NotImplementedException();
        }


        public void setVoltage(int setVolt)
        {
            throw new NotImplementedException();
        }
    }


    public class PSU : IPSU
    {

        //INTERNAL FUNCTION
        public static string getCom()
        {
            string com = "Com7";
            return com;
        }






        public string getVolt()
        {
            string com = getCom();
            int percentVolt = 0;

            // Get voltage

            //SD = MessageType + CastType + Direction + Length
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);

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


        public string getNominalVolt()
        {
            string com = getCom();
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
                double percentVolt = Convert.ToDouble(getVolt());
                volt = (double)percentVolt * nominalVoltage / 25600;
                return volt.ToString("0.00");
            }
        }






        public string getWatt()
        {
            string com = getCom();
            int percentWatt = 0;

            // Get voltage

            //SD = MessageType + CastType + Direction + Length
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);

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
                string percentWattString = responseTelegram[5].ToString("X") + responseTelegram[6].ToString("X");
                percentWatt = Convert.ToInt32(percentWattString, 16);
                return percentWatt.ToString("0.00");
            }
        }

        public string getNominalWatt()
        {
            string com = getCom();
            float nominalWatt = 0;
            double watt;

            //  Get Nominal Voltage
            List<byte> response;

            byte[] bytesToSend = { 0x74, 0x00, 0x04, 0x00, 0x78 };

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
                nominalWatt = BitConverter.ToSingle(byteArray, 0);
                double percentWatt = Convert.ToDouble(getWatt());
                watt = (double)percentWatt * nominalWatt / 25600;
                return watt.ToString("0.00");
            }
        }




        //Get the serial number 
        public string getSerialNumber()
        {
            string com = getCom();
            // reading serial number
            List<byte> Serialresponse;
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

                Serialresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        //Console.WriteLine(t);
                        Serialresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);

                string binary = Convert.ToString(Serialresponse[0], 2);
                string payloadLengtBinaryString = binary.Substring(4);
                int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

                string serialNumberString = "";

                if (Serialresponse[2] == 1) // means that I got a response on obj, which is refers to the object list.
                {
                    for (var i = 0; i < payloadLength; i++)
                    {
                        serialNumberString += Convert.ToChar(Serialresponse[3 + i]);
                    }
                }

                return serialNumberString;
            }
        }

        public string getManufacture()
        {
            string com = getCom();
            // reading serial number
            List<byte> Serialresponse;
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);
            // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
            // OBJ = 0x01 = 1
            byte[] serialBytesToSend = { 0x7F, 0x00, 0x08, 0x00, 0x87 };
            using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
            {
                Thread.Sleep(500);
                port.Open();
                // write to the USB port
                port.Write(serialBytesToSend, 0, serialBytesToSend.Length);
                Thread.Sleep(500);

                Serialresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        //Console.WriteLine(t);
                        Serialresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);

                string binary = Convert.ToString(Serialresponse[0], 2);
                string payloadLengtBinaryString = binary.Substring(4);
                int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

                string manufact = "";

                for (var i = 0; i < payloadLength; i++)
                {
                    manufact += Convert.ToChar(Serialresponse[3 + i]);
                }

                return manufact;
            }
        }

        public string getSoftVersion()
        {
            string com = getCom();
            // reading serial number
            List<byte> Serialresponse;
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);
            // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
            // OBJ = 0x01 = 1
            byte[] serialBytesToSend = { 0x7F, 0x00, 0x09, 0x00, 0x88 };

            using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
            {
                Thread.Sleep(500);
                port.Open();
                // write to the USB port
                port.Write(serialBytesToSend, 0, serialBytesToSend.Length);
                Thread.Sleep(500);

                Serialresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        //Console.WriteLine(t);
                        Serialresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);

                string binary = Convert.ToString(Serialresponse[0], 2);
                string payloadLengtBinaryString = binary.Substring(4);
                int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

                string softVersion = "";


                for (var i = 0; i < payloadLength; i++)
                {
                    softVersion += Convert.ToChar(Serialresponse[3 + i]);
                }

                return softVersion;
            }
        }

        public string getDeviceType()
        {
            string com = getCom();
            // reading serial number
            List<byte> Serialresponse;
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);
            // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
            // OBJ = 0x01 = 1
            byte[] serialBytesToSend = { 0x7F, 0x00, 0x00, 0x00, 0x7F };

            using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
            {
                Thread.Sleep(500);
                port.Open();
                // write to the USB port
                port.Write(serialBytesToSend, 0, serialBytesToSend.Length);
                Thread.Sleep(500);

                Serialresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        //Console.WriteLine(t);
                        Serialresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);

                string binary = Convert.ToString(Serialresponse[0], 2);
                string payloadLengtBinaryString = binary.Substring(4);
                int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

                string manufact = "";


                for (var i = 0; i < payloadLength; i++)
                {
                    manufact += Convert.ToChar(Serialresponse[3 + i]);
                }

                return manufact;
            }
        }


        public string getArticleNumber()
        {
            string com = getCom();
            // reading serial number
            List<byte> Serialresponse;
            int SDHex = (int)0x40 + (int)0x20 + 0x10 + 5; //6-1 ref spec 3.1.1
            byte SD = Convert.ToByte(SDHex.ToString(), 10);
            // Remember the dataframe setup, SD, DN,   OBJ, DATA checksum1, checksum2
            // OBJ = 0x01 = 1
            byte[] serialBytesToSend = { 0x7F, 0x00, 0x06, 0x00, 0x85 };

            using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
            {
                Thread.Sleep(500);
                port.Open();
                // write to the USB port
                port.Write(serialBytesToSend, 0, serialBytesToSend.Length);
                Thread.Sleep(500);

                Serialresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        //Console.WriteLine(t);
                        Serialresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);

                string binary = Convert.ToString(Serialresponse[0], 2);
                string payloadLengtBinaryString = binary.Substring(4);
                int payloadLength = Convert.ToInt32(payloadLengtBinaryString, 2);

                string artNum = "";


                for (var i = 0; i < payloadLength; i++)
                {
                    artNum += Convert.ToChar(Serialresponse[3 + i]);
                }

                return artNum;
            }
        }







        public int remoteOnOf()
        {
            string com = getCom();
            byte[] bytesToSendToTurnOnRC = new byte[] { 0xF1, 0x00, 0x36, 0x10, 0x10, 0x01, 0x47 }; // Turn on remote control
            List<byte> RCresponse;
            using (SerialPort port = new SerialPort(com, 115200, 0, 8, StopBits.One))
            {
                Thread.Sleep(500);
                port.Open();
                port.Write(bytesToSendToTurnOnRC, 0, bytesToSendToTurnOnRC.Length);
                Thread.Sleep(50);
                RCresponse = new List<byte>();
                int length = port.BytesToRead;
                if (length > 0)
                {
                    byte[] message = new byte[length];
                    port.Read(message, 0, length);
                    foreach (var t in message)
                    {
                        RCresponse.Add(t);
                    }
                }
                port.Close();
                Thread.Sleep(500);
                if (RCresponse[3] == 0)
                {
                    Console.WriteLine("Remote Control is turned on");
                }
                else
                {
                    Console.WriteLine(String.Format("Remote control is not turned on due to error: {0}", RCresponse[3].ToString()));
                }
            }
            return RCresponse[3];
        }
        public void setVoltage(int setVolt)
        {
            string com = getCom();

            // Calculate the percentage of Unom * 256
            int percentVoltage = setVolt; // Assuming voltage is a floating-point value

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
    }
}