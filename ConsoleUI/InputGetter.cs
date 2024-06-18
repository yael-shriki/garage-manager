using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    public class InputGetter
    {
        private static int readInteger()
        {
            int o_number;

            string inputNumber = Console.ReadLine();
            while (!int.TryParse(inputNumber, out o_number))
            {
                Console.WriteLine("Not a number, please choose again:");
                inputNumber = Console.ReadLine();
            }

            return o_number;
        }

        public static float ReadFloat()
        {
            float o_number;

            string inputNumber = Console.ReadLine();
            while (!float.TryParse(inputNumber, out o_number))
            {
                Console.WriteLine("Not a number, please choose again:");
                inputNumber = Console.ReadLine();
            }

            return o_number;
        }

        public static eGarageOptions GetUserMenuChoice()
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine(string.Format(
@"1. Insert a vehicle into the garage. 
2. Display the license numbers of vehicles in the garage
3. Change a vehicle's status in garage.
4. Inflate a vehicle's tires to maximum.
5. Refuel a fuel based vehicle.
6. Charge an electric based vehicle.
7. Display a vehicle's information
8. Quit"));
            int validOption = InputGetter.GetValidChoice(1, 8);

            return (eGarageOptions)validOption;
        }

        public static int GetValidChoice(int i_MinValOption, int i_MaxValOption)
        {
            int customersChoice = readInteger();

            while (customersChoice < i_MinValOption || customersChoice > i_MaxValOption)
            {
                Console.WriteLine(string.Format("You must choose an option between {0} and {1}", i_MinValOption, i_MaxValOption));
                customersChoice = readInteger();
            }

            return customersChoice;
        }

        public static float GetEnergyRemaining()
        {
            Console.WriteLine("What is the amount of energy in your vehicle?");
            float energyPercentRemaining = ReadFloat();

            return energyPercentRemaining;
        }

        public static string GetNotNullOrEmptyInput()
        {
            string input = Console.ReadLine().Trim();
            while (input == null || input.Length == 0)
            {
                Console.WriteLine("Your input is empty, please enter a valid input");
                input = Console.ReadLine().Trim();
            }

            return input;
        }

        public static eVehicleType GetVehicleType()
        {
            Console.WriteLine("Please enter the vehicle's type from the following:");
            Console.WriteLine(string.Format(
@"1. Fuel Car
2. Electric Car
3. Fuel Motorcycle
4. Electric Motorcycle
5. Truck"));
            int validChoice = GetValidChoice(1, 5);

            return (eVehicleType)validChoice;
        }

        public static string GetVehicleModel()
        {
            Console.WriteLine("Please enter the vehicle's model name:");
            string modelName = GetNotNullOrEmptyInput();

            return modelName;
        }

        public static string GetLicenseNumber()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string licenseNumber = GetNotNullOrEmptyInput();

            return licenseNumber;
        }

        public static eVehicleStatus GetNewStatus()
        {
            Console.WriteLine("Please enter the vehicle's new status from the following:");
            Console.WriteLine(string.Format(
@"1. In repair.
2. Repaired.
3. Paid."));
            int validChoice = GetValidChoice(1, 3);

            return (eVehicleStatus)validChoice;
        }

        public static eFuelType GetFuelType()
        {
            Console.WriteLine("Please enter the vehicle's fuel type from the following:");
            Console.WriteLine(string.Format(
@"1. Soler
2. Octan95
3. Octan96
4. Octan98"));
            int validChoice = GetValidChoice(1, 4);

            return (eFuelType)validChoice;
        }

        public static float GetEnergyAmount(string i_EnergyType)
        {
            Console.WriteLine("Please enter the amount of {0} you would like to fill in liters:", i_EnergyType);
            float litersOfFuel = ReadFloat();

            return litersOfFuel;
        }
    }
}
