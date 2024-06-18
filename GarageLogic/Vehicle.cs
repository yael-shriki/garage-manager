using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_VehicleModel;
        protected readonly string r_LicenseNumber;
        protected float m_EnergyPercentRemaining;
        protected List<Tire> m_VehicleTires;
        protected EnergySystem m_EnergySystem;
        protected VehicleCard m_VehicleCard;
        protected Dictionary<string, string> m_VehicleProperties = new Dictionary<string, string>();

        protected Vehicle(string i_LicenseNumber, string i_VehicleModel)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_VehicleModel = i_VehicleModel;
            BuildProperties();
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public List<Tire> Tires
        {
            get { return m_VehicleTires; }
            set { m_VehicleTires = value; }
        }

        public EnergySystem EnergySystem
        {
            get { return m_EnergySystem; }
            set { m_EnergySystem = value; }
        }

        public float EnergyPercentRemaining
        {
            get { return m_EnergyPercentRemaining; }
            set { m_EnergyPercentRemaining = value; }
        }

        public Dictionary<string, string> VehicleProperties
        {
            get { return m_VehicleProperties; }
            set { m_VehicleProperties = value; }
        }

        public VehicleCard VehicleCard
        {
            get { return m_VehicleCard; }
            set { m_VehicleCard = value; }
        }

        public abstract void BuildProperties();

        public abstract void ValidateProperties();

        public void CreateTires(int i_NumOfTires, float i_MaxTireAirPressure)
        {
            List<Tire> newTires = new List<Tire>();

            for (int i = 0; i < i_NumOfTires; i++)
            {
                Tire tire = new Tire(i_MaxTireAirPressure);
                newTires.Add(tire);
            }

            m_VehicleTires = newTires;
        }

        public void UpdateVehicleCard(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleCard vehicleCard = new VehicleCard(i_OwnerName, i_OwnerPhoneNumber);
            m_VehicleCard = vehicleCard;
        }

        public void InitializeTire(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Tire tire in m_VehicleTires)
            {
                tire.InitializeTire(i_ManufacturerName, i_CurrentAirPressure);
            }
        }

        public void CalcEnergyPercent(float i_CurrentEnergy, float i_MaxEnergyCapacity)
        {
            m_EnergyPercentRemaining = (i_CurrentEnergy / i_MaxEnergyCapacity) * 100;
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.AppendLine();
            vehicleInfo.AppendLine(string.Format(
@"Vehicle's License Number : {0}
Model Name: {1}", r_LicenseNumber, r_VehicleModel));
            vehicleInfo.Append(m_VehicleCard.ToString());
            vehicleInfo.AppendLine("Tires specifications");
            vehicleInfo.AppendLine("----------------------------------------");
            for (int i = 0; i < m_VehicleTires.Count; i++)
            {
                StringBuilder tireInfo = new StringBuilder();
                Tire tire = m_VehicleTires[i];
                tireInfo.Append("Tire ");
                tireInfo.Append(i.ToString());
                tireInfo.Append(": ");
                tireInfo.Append(tire.ToString());
                vehicleInfo.AppendLine(tireInfo.ToString());
            }
            vehicleInfo.AppendLine("----------------------------------------");
            vehicleInfo.AppendLine(m_EnergySystem.ToString());

            return vehicleInfo.ToString();
        }
    }
}
