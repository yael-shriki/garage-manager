using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicenseNumber, string i_VehicleModel) : base(i_LicenseNumber, i_VehicleModel)
        { }

        public override void BuildProperties()
        {
            VehicleProperties.Add("License Type", "");
            VehicleProperties.Add("Engine Volume", "");
        }

        public override void ValidateProperties()
        {
            if (Enum.TryParse(VehicleProperties["License Type"], true, out eLicenseType o_licenseType) && Enum.IsDefined(typeof(eLicenseType), o_licenseType))
            {
                m_LicenseType = o_licenseType;
            }
            else
            {
                throw new ArgumentException("Invalid license type.");
            }

            if (int.TryParse(VehicleProperties["Engine Volume"], out int o_engineVolume))
            {
                m_EngineVolume = o_engineVolume;
            }
            else
            {
                throw new ArgumentException("Invalid engine volume.");
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleInfo = new StringBuilder();

            motorcycleInfo.Append(base.ToString());
            motorcycleInfo.AppendLine(string.Format("License Type: {0}", m_LicenseType.ToString()));
            motorcycleInfo.AppendLine(string.Format("Engine Volume: {0}", m_EngineVolume.ToString()));

            return motorcycleInfo.ToString();
        }
    }
}
