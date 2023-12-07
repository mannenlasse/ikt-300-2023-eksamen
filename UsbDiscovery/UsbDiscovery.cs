using System.Management;
using System.IO.Ports;

namespace UsbDiscovery;

public class DeviceEventArgs : EventArgs
{
    public string ComPort { get; }
    public ComPortDiscovery.ComDeviceFilter ComFilter { get; }

    public DeviceEventArgs(string comPort, ComPortDiscovery.ComDeviceFilter comFilter)
    {
        ComPort = comPort;
        ComFilter = comFilter;
    }
}

public class ComPortDiscovery
{
    public event EventHandler<DeviceEventArgs> DeviceConnected;
    public event EventHandler<DeviceEventArgs> DeviceDisconnected;

    public List<ComDeviceFilter> ComDeviceFilterList = new List<ComDeviceFilter>();

    private Dictionary<string, ComDeviceFilter> _currentComPorts = new Dictionary<string, ComDeviceFilter>();

    public bool IsRunning { get; set; } = true;
    
    public async Task RunAsync()
    {
        while (IsRunning)
        {
            await Task.Delay(1000);
            
            RegularComPortCheck();
            
            // Console.WriteLine("Discovery is running.");
        }
    }
    
    private void RegularComPortCheck()
    {
        var availablePorts = SerialPort.GetPortNames();

        // Check for new connected comports
        foreach (var comPort in availablePorts)
        {
            if (_currentComPorts.ContainsKey(comPort))
                continue;
            
            var potentialFilter = ValidateComPort(comPort);

            if (potentialFilter == null)
                continue;
            
            var filter = (ComDeviceFilter)potentialFilter;
            
            OnDeviceConnected(comPort, filter);
            _currentComPorts.Add(comPort, filter);
        }

        // Check for disconnected comports
        foreach (var comPort in _currentComPorts)
        {
            if (availablePorts.Contains(comPort.Key))
                continue;
            
            OnDeviceDisconnected(comPort.Key, comPort.Value);
            _currentComPorts.Remove(comPort.Key);
        }
    }

    private void OnDeviceConnected(string comPort, ComDeviceFilter comFilter)
    {
        DeviceConnected?.Invoke(this, new DeviceEventArgs(comPort, comFilter));
    }

    private void OnDeviceDisconnected(string comPort, ComDeviceFilter comFilter)
    {
        DeviceDisconnected?.Invoke(this, new DeviceEventArgs(comPort, comFilter));
    }

    private ComDeviceFilter? ValidateComPort(string comPort)
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SerialPort");
        foreach (ManagementObject queryObject in searcher.Get())
        {
            var deviceId = queryObject["DeviceID"].ToString();
            if (deviceId.Contains(comPort))
            {
                var pnpId = queryObject["PNPDeviceID"].ToString();
                var pidIndex = pnpId.IndexOf("PID_") + "PID_".Length;
                var vidIndex = pnpId.IndexOf("VID_") + "VID_".Length;

                var thisPid = pnpId.Substring(pidIndex, 4);
                var thisVid = pnpId.Substring(vidIndex, 4);
                
                foreach (var filter in ComDeviceFilterList)
                {
                    if (thisPid == filter.Pid && thisVid == filter.Vid)
                    {
                        return filter;
                    }
                }

                return null;
            }
        }

        return null;
    }
    
    public struct ComDeviceFilter
    {
        public string Pid;
        public string Vid;
    }
}