namespace Ex03.GarageLogic
{
    public class ElectricSystem : EnergySystem
    {
        public ElectricSystem(float i_MaxEnergyCapacity, float i_CurrentEnergy) : base(i_MaxEnergyCapacity, i_CurrentEnergy)
        { }

        public void ReCharge(float i_HoursToAdd)
        {
            base.AddEnergy(i_HoursToAdd);
        }

        public override string ToString()
        {
            return string.Format("Current battery status: {0} hours.", base.CurrentEnergy.ToString());
        }
    }
}

