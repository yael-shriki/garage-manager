namespace Ex03.GarageLogic
{
    public abstract class EnergySystem
    {
        protected float m_CurrentEnergy;
        protected readonly float r_MaxEnergyCapacity;

        protected EnergySystem(float i_MaxEnergyCapacity, float i_CurrentEnergyCapacity)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            AddEnergy(i_CurrentEnergyCapacity);
        }

        public float MaxEnergy
        {
            get { return r_MaxEnergyCapacity; }
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set { m_CurrentEnergy = value; }
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            if (m_CurrentEnergy + i_EnergyToAdd <= r_MaxEnergyCapacity)
            {
                m_CurrentEnergy += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergyCapacity - m_CurrentEnergy);
            }
        }
    }
}
