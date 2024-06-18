using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_ContainsDangerousMaterials;
        private float m_CargoVolume;

        public Truck(string i_LicenseNumber, string i_VehicleModel) : base(i_LicenseNumber, i_VehicleModel)
        { }

        public override void BuildProperties()
        {
            VehicleProperties.Add("If Contains Dangerous Materials", "");
            VehicleProperties.Add("Cargo Volume", "");
        }

        public override void ValidateProperties()
        {
            if (bool.TryParse(VehicleProperties["If Contains Dangerous Materials"], out bool o_containsDangerous))
            {
                m_ContainsDangerousMaterials = o_containsDangerous;
            }
            else
            {
                throw new ArgumentException("Invalid value for Contains Dangerous Materials: Expecting 'False' (0) or 'True' (1).");
            }

            if (float.TryParse(VehicleProperties["Cargo Volume"], out float o_cargoVolume) && o_cargoVolume >= 0)
            {
                m_CargoVolume = o_cargoVolume;
            }
            else
            {
                throw new ArgumentException("Invalid Cargo Volume: Must be a non-negative number.");
            }
        }

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder();

            truckInfo.Append(base.ToString());
            string containsDangerousMaterials = m_ContainsDangerousMaterials ? "Yes" : "No";
            truckInfo.AppendLine(string.Format("Contains Dangerous Materials: {0}", containsDangerousMaterials));
            truckInfo.AppendLine(string.Format("Cargo Tank Volume: {0}", m_CargoVolume.ToString()));

            return truckInfo.ToString();
        }
    }
}
