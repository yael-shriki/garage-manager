namespace Ex03.GarageLogic
{
    internal static class VehicleCreator
    {
        private const int k_NumOfCarTires = 4;
        private const int k_NumOfMotorcycleTires = 2;
        private const int k_NumOfTruckTires = 12;
        private const float k_CarTireMaxAirPressure = 31;
        private const float k_MotorcycleTireMaxAirPressure = 33;
        private const float k_TruckTireMaxAirPressure = 28;
        private const float k_CarMaxFuelCapacity = 45;
        private const float k_CarMaxBatteryCapacity = 3.5f;
        private const float k_MotorcycleMaxFuelCapacity = 5.5f;
        private const float k_MotorcycleMaxBatteryCapacity = 2.5f;
        private const float k_TruckMaxFuelCapacity = 120;
        private const eFuelType k_CarFuelType = eFuelType.Octan95;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_LicenseNumber, string i_VehicleModel, float i_CurrentEnergy)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    newVehicle = new Car(i_LicenseNumber, i_VehicleModel);
                    initializeFuelBasedVehicle(newVehicle, i_CurrentEnergy, k_CarMaxFuelCapacity, k_CarFuelType, k_NumOfCarTires, k_CarTireMaxAirPressure);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_LicenseNumber, i_VehicleModel);
                    initializeElecticBasedVehicle(newVehicle, i_CurrentEnergy, k_CarMaxBatteryCapacity, k_NumOfCarTires, k_CarTireMaxAirPressure);
                    break;
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber, i_VehicleModel);
                    initializeFuelBasedVehicle(newVehicle, i_CurrentEnergy, k_MotorcycleMaxFuelCapacity, k_MotorcycleFuelType, k_NumOfMotorcycleTires, k_MotorcycleTireMaxAirPressure);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber, i_VehicleModel);
                    initializeElecticBasedVehicle(newVehicle, i_CurrentEnergy, k_MotorcycleMaxBatteryCapacity, k_NumOfMotorcycleTires, k_MotorcycleTireMaxAirPressure);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicenseNumber, i_VehicleModel);
                    initializeFuelBasedVehicle(newVehicle, i_CurrentEnergy, k_TruckMaxFuelCapacity, k_TruckFuelType, k_NumOfTruckTires, k_TruckTireMaxAirPressure);
                    break;
            }

            return newVehicle;
        }

        private static void initializeFuelBasedVehicle(Vehicle i_Vehicle, float i_CurrentEnergy, float i_MaxFuelCapacity, eFuelType i_FuelType, int i_NumOfTires, float i_MaxTireAirPressure)
        {
            i_Vehicle.EnergySystem = new FuelSystem(i_FuelType, i_MaxFuelCapacity, i_CurrentEnergy);
            i_Vehicle.CreateTires(i_NumOfTires, i_MaxTireAirPressure);
            i_Vehicle.CalcEnergyPercent(i_CurrentEnergy, i_MaxFuelCapacity);
        }

        private static void initializeElecticBasedVehicle(Vehicle i_Vehicle, float i_CurrentEnergy, float i_MaxBatteryCapacity, int i_NumOfTires, float i_MaxTireAirPressure)
        {
            i_Vehicle.EnergySystem = new ElectricSystem(i_MaxBatteryCapacity, i_CurrentEnergy);
            i_Vehicle.CreateTires(i_NumOfTires, i_MaxTireAirPressure);
            i_Vehicle.CalcEnergyPercent(i_CurrentEnergy, i_MaxBatteryCapacity);
        }
    }
}
