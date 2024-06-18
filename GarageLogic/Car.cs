using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_VehicleModel) : base(i_LicenseNumber, i_VehicleModel)
        { }

        public override void BuildProperties()
        {
            VehicleProperties.Add("Car Color", "");
            VehicleProperties.Add("Number of Doors", "");
        }

        public override void ValidateProperties()
        {
            if (Enum.TryParse(VehicleProperties["Car Color"], true, out eCarColor o_carColor) && Enum.IsDefined(typeof(eCarColor), o_carColor))
            {
                m_CarColor = o_carColor;
            }
            else
            {
                throw new ArgumentException("Invalid car color.");
            }

            if (Enum.TryParse(VehicleProperties["Number of Doors"], true, out eNumOfDoors o_numOfDoors) && Enum.IsDefined(typeof(eNumOfDoors), o_numOfDoors))
            {
                m_NumOfDoors = o_numOfDoors;
            }
            else
            {
                throw new ArgumentException("Invalid number of doors. ");
            }
        }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();

            carInfo.Append(base.ToString());
            carInfo.AppendLine(string.Format("Car Color: {0}", m_CarColor.ToString()));
            carInfo.AppendLine(string.Format("Number of car doors: {0}", m_NumOfDoors.ToString()));

            return carInfo.ToString();
        }
    }
}
