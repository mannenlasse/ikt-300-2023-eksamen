using psuManager;

namespace PSUFactory
{
    public class psuFactory
    {
        public IPSU CreatePSU(string psuType)
        {
            switch (psuType)
            {
                case "PSU3000":
                    return new PSU3000();
                default:
                    throw new ArgumentException("Unsupported PSU type: " + psuType);
            }
        }
    }
}