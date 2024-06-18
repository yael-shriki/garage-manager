using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelSystem : EnergySystem
    {
        private readonly eFuelType r_FuelType;

        public FuelSystem(eFuelType i_FuelType, float i_MaxEnergyCapacity, float i_CurrentEnergy) : base(i_MaxEnergyCapacity, i_CurrentEnergy)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void ReFuel(float i_FuelToAdd, eFuelType i_TypeOfFuel)
        {
            if (i_TypeOfFuel != r_FuelType)
            {
                throw new ArgumentException();
            }
            else
            {
                base.AddEnergy(i_FuelToAdd);
            }
        }

        public override string ToString()
        {
            StringBuilder fuelSystemInfo = new StringBuilder();

            fuelSystemInfo.AppendLine(string.Format("Current fuel status: {0} liters.", base.CurrentEnergy.ToString()));
            fuelSystemInfo.AppendLine(string.Format("Fuel type: {0}.", r_FuelType.ToString()));

            return fuelSystemInfo.ToString();
        }
    }
}

