using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesInShop;

        public GarageManager()
        {
            r_VehiclesInShop = new Dictionary<string, Vehicle>();
        }

        public Vehicle InitVehicle(eVehicleType i_VehicleType, string i_LicenseNumber, string i_VehicleModel, float i_CurrentEnergy)
        {
            Vehicle newVehicle;
            try
            {
                newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_VehicleModel, i_CurrentEnergy);
            }
            catch(ValueOutOfRangeException ex)
            {
                throw ex;
            }

            return newVehicle;
        }

        public void AddVehicleToGarage(string i_LicenseNumber, Vehicle i_Vehicle)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                r_VehiclesInShop.Add(i_LicenseNumber, i_Vehicle);
            }
        }

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new VehicleNotInGarageException(i_LicenseNumber);
            }

            return r_VehiclesInShop[i_LicenseNumber];
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInShop.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetVehicleLicenseNums()
        {
            List<string> licenseNums = new List<string>();
            foreach (var vehicle in r_VehiclesInShop)
            {
                licenseNums.Add(vehicle.Key);
            }

            return licenseNums;
        }

        public List<string> GetVehicleLicenseNumsByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNums = new List<string>();

            foreach (var garageMember in r_VehiclesInShop)
            {
                Vehicle vehicle = garageMember.Value;
                if (vehicle.VehicleCard.VehicleStatus == i_VehicleStatus)
                {
                    licenseNums.Add(garageMember.Key);
                }
            }

            return licenseNums;
        }

        public void UpdateVehicleStatus(string i_LicenseNum, eVehicleStatus i_NewStatus)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNum);
            vehicle.VehicleCard.VehicleStatus = i_NewStatus;
        }

        public void InflateTiresToMax(string i_LicenseNum)
        {
            Vehicle vehicleToFillTires = GetVehicle(i_LicenseNum);

            foreach (Tire tire in vehicleToFillTires.Tires)
            {
                tire.InflateTire(tire.MaxAirPressure - tire.CurrentAirPressure);
            }
        }

        public void FuelVehicle(string i_LicenseNum, eFuelType i_FuelType, float i_FuelAmount)
        {
            Vehicle vehicleToFuel = GetVehicle(i_LicenseNum);
            FuelSystem fuelSystem = vehicleToFuel.EnergySystem as FuelSystem;

            if (fuelSystem == null)
            {
                throw new FormatException();
            }
            try
            {
                fuelSystem.ReFuel(i_FuelAmount, i_FuelType);
            }
            catch (ValueOutOfRangeException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public void ChargeVehicle(string i_LicenseNum, float i_HoursToAdd)
        {
            Vehicle vehicleToFuel = GetVehicle(i_LicenseNum);
            ElectricSystem electricSystem = vehicleToFuel.EnergySystem as ElectricSystem;

            if (electricSystem == null)
            {
                throw new FormatException();
            }
            try
            {
                electricSystem.ReCharge(i_HoursToAdd);
            }
            catch (ValueOutOfRangeException ex)
            {
                throw ex;
            }
        }
    }
}

