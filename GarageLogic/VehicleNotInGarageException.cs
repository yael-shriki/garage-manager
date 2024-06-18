using System;

namespace Ex03.GarageLogic
{
    public class VehicleNotInGarageException : Exception
    {
        private readonly string r_LicenseNumber;

        public VehicleNotInGarageException(string i_LicenseNumber)
            : base(string.Format("The vehicle with license number {0} is not in the garage.", i_LicenseNumber))
        {
            r_LicenseNumber = i_LicenseNumber;
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }
    }
}
