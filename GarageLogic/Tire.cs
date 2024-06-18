using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Tire(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void InflateTire(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure);
            }
        }

        public void InitializeTire(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            const float k_minAirPressure = 0;

            if (i_CurrentAirPressure >= k_minAirPressure && i_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_ManufacturerName = i_ManufacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(k_minAirPressure, r_MaxAirPressure);
            }
        }

        public override string ToString()
        {
            StringBuilder tireInfo = new StringBuilder();

            tireInfo.AppendLine();
            tireInfo.AppendLine(string.Format(
@"Manufacturers: {0}
Air Pressure: {1}", m_ManufacturerName, m_CurrentAirPressure));

            return tireInfo.ToString();
        }
    }
}
