# Garage Manager
## Console application that manages a vehicle garage using OOP design, including "Factory Method" design pattern.

The user interface and the logical layer which manages the object model and the logical entities of the system are separated.

The system supplies the user with the following options:

1. “Insert” a new vehicle into the garage. The user will be asked to select a vehicle type out of the supported vehicle types and to input the license number of the vehicle. If the vehicle is already in the garage (based on license number) the system will display an appropriate message and will use the vehicle in the garage (and will change the vehicle status to “In Repair”), if not, a new object of that vehicle type will be created and the user will be prompted to input the values for the properties of his vehicle, according to the type of vehicle he wishes to add.
2. Display a list of license numbers currently in the garage, with a filtering option based on the status of each vehicle
3. Change a certain vehicle’s status (Prompting the user for the license number and new desired status)
4. Inflate tires to maximum (Prompting the user for the license number)
5. Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill)
6. Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge)
7. Display vehicle information (License number, Model name, Owner name, Status in the garage, Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
