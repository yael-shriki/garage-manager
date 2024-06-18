using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCard
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public VehicleCard(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public static bool IsValidOwnerName(string i_OwnerName)
        {
            bool isValidName = true;

            if (!isLetterOrSpace(i_OwnerName))
            {
                isValidName = false;
            }

            return isValidName;
        }

        private static bool isLetterOrSpace(string i_OwnerName)
        {
            bool isLetterOrSpace = true;

            foreach (char c in i_OwnerName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    isLetterOrSpace = false;
                }
            }

            return isLetterOrSpace;
        }

        public static bool IsValidOwnerPhoneNumber(string i_OwnerPhoneNumber)
        {
            bool isValidNumber = true;

            if (!i_OwnerPhoneNumber.All(char.IsNumber) || i_OwnerPhoneNumber.Length != 10)
            {
                isValidNumber = false;
            }

            return isValidNumber;
        }

        public override string ToString()
        {
            StringBuilder cardInfo = new StringBuilder();

            cardInfo.AppendLine(string.Format("Owner name: {0}", r_OwnerName.ToString()));
            cardInfo.AppendLine(string.Format("Owner phone number: {0}", r_OwnerPhoneNumber.ToString()));
            cardInfo.AppendLine(string.Format("Vehicle status: {0}", m_VehicleStatus.ToString()));

            return cardInfo.ToString();
        }
    }
}
