using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private static readonly GarageManager sr_GarageManager = new GarageManager();

        public static void Run()
        {
            bool isUserQuitting = false;

            Console.WriteLine("Hello! Welcome to our garage!");
            while (!isUserQuitting)
            {
                eGarageOptions menuOption = InputGetter.GetUserMenuChoice();
                Console.Clear();
                switch (menuOption)
                {
                    case eGarageOptions.AddVehicle:
                        addVehicleToGarage();
                        break;
                    case eGarageOptions.ShowLicensePlates:
                        showLicenseNumsByFilter();
                        break;
                    case eGarageOptions.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case eGarageOptions.InflateTiresToMax:
                        inflateTiresToMax();
                        break;
                    case eGarageOptions.FuelGasVehicle:
                        fuelGasVehicle();
                        break;
                    case eGarageOptions.ChargeElectricVehicle:
                        chargeElectricVehicle();
                        break;
                    case eGarageOptions.ShowVehicleDetails:
                        displayVehicleInfo();
                        break;
                    case eGarageOptions.Quit:
                        isUserQuitting = true;
                        break;
                }
            }
        }

        private static void addVehicleToGarage()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();

            if (!sr_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                createNewVehicle(licenseNumber);
            }
            else
            {
                Console.WriteLine("This vehicle is already in the garage.");
                sr_GarageManager.UpdateVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
            }
        }

        private static void createNewVehicle(string i_licenseNumber)
        {
            try
            {
                eVehicleType newVehicleType = InputGetter.GetVehicleType();
                string newVehicleModel = InputGetter.GetVehicleModel();
                float currentEnergy = InputGetter.GetEnergyRemaining();
                Vehicle newVehicle = sr_GarageManager.InitVehicle(newVehicleType, i_licenseNumber, newVehicleModel, currentEnergy);
                updateTires(newVehicle);
                updateVehicleCard(newVehicle);
                updateVehicleParametersFromUser(newVehicle.VehicleProperties, newVehicle);
                sr_GarageManager.AddVehicleToGarage(i_licenseNumber, newVehicle);
                sr_GarageManager.UpdateVehicleStatus(i_licenseNumber, eVehicleStatus.InRepair);
                printActionSuccessful("Your vehicle was successfully added to our garage.");
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter all details again.");
                createNewVehicle(i_licenseNumber);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.Clear();
                Console.WriteLine("The current energy you entered is greater than the maximum energy capacity.");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter all details again.");
                createNewVehicle(i_licenseNumber);
            }
        }

        private static void printActionSuccessful(string i_SuccessMessage)
        {
            Console.Clear();
            Console.WriteLine(i_SuccessMessage);
            System.Threading.Thread.Sleep(2000);
        }

        private static void updateVehicleCard(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter the owner name:");
            string ownerName = InputGetter.GetNotNullOrEmptyInput();
            while (!VehicleCard.IsValidOwnerName(ownerName))
            {
                Console.WriteLine("Invalid name. Please use only letters:");
                ownerName = InputGetter.GetNotNullOrEmptyInput();
            }
            Console.WriteLine("Please enter the owner phone number:");
            string ownerPhoneNumber = InputGetter.GetNotNullOrEmptyInput();
            while (!VehicleCard.IsValidOwnerPhoneNumber(ownerPhoneNumber))
            {
                Console.WriteLine("Invalid phone number. Please enter a 10 digit number:");
                ownerPhoneNumber = InputGetter.GetNotNullOrEmptyInput();
            }

            i_Vehicle.UpdateVehicleCard(ownerName, ownerPhoneNumber);
        }

        private static void updateVehicleParametersFromUser(Dictionary<string, string> i_VehicleProperties, Vehicle i_VehicleToUpdate)
        {
            foreach (string parameter in i_VehicleProperties.Keys.ToList())
            {
                Console.WriteLine("Enter {0}:", parameter);
                i_VehicleProperties[parameter] = InputGetter.GetNotNullOrEmptyInput();
            }
            i_VehicleToUpdate.ValidateProperties();
        }

        private static void updateTires(Vehicle i_Vehicle)
        {
            Console.WriteLine("Press 1 if you would like to update all tires the same or 2 if you would like to update each tire seperately:");
            int validChoice = InputGetter.GetValidChoice(1, 2);
            try
            {
                if (validChoice == 1)
                {
                    Console.WriteLine("Please enter your tire's manufacturures name:");
                    string manufacturerName = InputGetter.GetNotNullOrEmptyInput();
                    Console.WriteLine("Please enter the current air pressure in your tires:");
                    float currentAirPressure = InputGetter.ReadFloat();
                    i_Vehicle.InitializeTire(manufacturerName, currentAirPressure);
                }
                else
                {
                    int tireCount = 1;
                    foreach (Tire tire in i_Vehicle.Tires)
                    {
                        Console.WriteLine("Please enter tire {0} manufacturures name:", tireCount);
                        string manufacturerName = InputGetter.GetNotNullOrEmptyInput();
                        Console.WriteLine("Please enter the current air pressure in tire {0}:", tireCount);
                        float currentAirPressure = InputGetter.ReadFloat();
                        tire.InitializeTire(manufacturerName, currentAirPressure);
                        tireCount++;
                    }
                }
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                updateTires(i_Vehicle);
            }
        }

        private static void showLicenseNumsByFilter()
        {
            List<string> licenseNums = new List<string>();

            Console.WriteLine("You can see the license plates in the garage filtered by one of the following:");
            Console.WriteLine(string.Format(
@"1. In repair
2. Repaired
3. Paid
4. No filter - all vehicles"));
            eVehicleStatus validChoice = (eVehicleStatus)InputGetter.GetValidChoice(1, 4);
            if (validChoice == eVehicleStatus.InRepair)
            {
                licenseNums = sr_GarageManager.GetVehicleLicenseNumsByStatus(validChoice);
            }
            else if (validChoice == eVehicleStatus.Repaired)
            {
                licenseNums = sr_GarageManager.GetVehicleLicenseNumsByStatus(validChoice);
            }
            else if (validChoice == eVehicleStatus.Paid)
            {
                licenseNums = sr_GarageManager.GetVehicleLicenseNumsByStatus(validChoice);
            }
            else
            {
                licenseNums = sr_GarageManager.GetVehicleLicenseNums();
            }

            Console.WriteLine("The license numbers with status - {0} - are: ", validChoice);
            foreach (string licenseNumber in licenseNums)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private static void changeVehicleStatus()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();
            eVehicleStatus newStatus = InputGetter.GetNewStatus();
            try
            {
                sr_GarageManager.UpdateVehicleStatus(licenseNumber, newStatus);
                printActionSuccessful("Your vehicle's status was successfully changed.");
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                changeVehicleStatus();
            }
        }

        private static void inflateTiresToMax()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();
            try
            {
                sr_GarageManager.InflateTiresToMax(licenseNumber);
                printActionSuccessful("Your vehicle's tires were successfully inflated to the maximum.");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                inflateTiresToMax();
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                inflateTiresToMax();
            }
        }

        private static void fuelGasVehicle()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();
            eFuelType fuelType = InputGetter.GetFuelType();
            float fuelToAdd = InputGetter.GetEnergyAmount("fuel");
            try
            {
                sr_GarageManager.FuelVehicle(licenseNumber, fuelType, fuelToAdd);
                printActionSuccessful("Your vehicle was successfully fueled.");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                fuelGasVehicle();
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                fuelGasVehicle();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("The fuel type you have chosen is not a valid type.");
                fuelGasVehicle();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("The vehicle you have chosen is not a fuel powered vehicle, choose a different vehicle.");
                fuelGasVehicle();
            }
        }

        private static void chargeElectricVehicle()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();
            float hoursToAdd = InputGetter.GetEnergyAmount("hours");
            try
            {
                sr_GarageManager.ChargeVehicle(licenseNumber, hoursToAdd);
                printActionSuccessful("Your vehicle was successfully charged.");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                chargeElectricVehicle();
            }
            catch (VehicleNotInGarageException ex)
            {
                chargeElectricVehicle();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("The vehicle you have chosen is not an electric powered vehicle, choose a different vehicle.");
                chargeElectricVehicle();
            }
        }

        private static void displayVehicleInfo()
        {
            string licenseNumber = InputGetter.GetLicenseNumber();
            try
            {
                Vehicle vehicle = sr_GarageManager.GetVehicle(licenseNumber);
                Console.WriteLine(vehicle.ToString());
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                displayVehicleInfo();
            }
        }
    }
}
