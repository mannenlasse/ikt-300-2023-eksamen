using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psuManager;
namespace PSUFactory
{
    public enum PsuType
    {
        PSU3000
        // Add more PSU types here if needed
    }

    public class PsuFactory
    {
        public IPSU CreatePSU(PsuType psuType)
        {
            switch (psuType)
            {
                case PsuType.PSU3000:
                    return new PSU3000();
                // Add cases for other PSU types here
                default:
                    throw new ArgumentException("Unsupported PSU type: " + psuType);
            }
        }

        public List<PsuType> GetAvailablePSUTypes()
        {
            // Return a list of available PSU types
            return new List<PsuType>
            {
                PsuType.PSU3000
                // Add more PSU types here if needed
            };
        }
    }
}