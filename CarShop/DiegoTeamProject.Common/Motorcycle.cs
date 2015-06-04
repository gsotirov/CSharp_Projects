using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Motorcycle : Vehicle
    {
        //Constructor
        public Motorcycle(decimal torque,
            MotorcycleType motorcycleType,
                          //inherit vehicle class
            string brand,
            uint cubicCapacity,
            Designation designation,
            decimal factoryPrice,
            string firstRegistration,
            FuelType fuelType,
            decimal price,
            string gearBox,
            uint id,
            uint mileage,
            string model,
            uint horsePower,
            VehicleState state) : base(brand, cubicCapacity, designation, factoryPrice, firstRegistration, fuelType, price, gearBox, id, mileage, model, horsePower, state)
        {
            this.Torque = torque;
            this.MotorcycleType = motorcycleType;
        }

        public MotorcycleType MotorcycleType { get; set; }

        public decimal Torque { get; set; }

        public static void Add()
        {
            uint numbers = 0;
            decimal torque = 0;
            MotorcycleType motorcycleType = new MotorcycleType();
            string brand = string.Empty;
            uint cubicCapacity = 0;
            Designation designation = new Designation();
            decimal factoryPrice = 0;
            string firstRegistration = string.Empty;
            FuelType fuelType = new FuelType();
            decimal price = 0;
            string gearBox = string.Empty;
            uint iD = 0;
            uint mileage = 0;
            string model = string.Empty;
            uint horsePower = 0;
            VehicleState state = new VehicleState();

            torque = ConsoleInput.GetData<decimal>("Please input torque: ");
            motorcycleType = ConsoleInput.GetEnum<MotorcycleType>("Please input motorcycle type type: ");
            brand = ConsoleInput.GetData<string>("Please input brand: ");
            cubicCapacity = ConsoleInput.GetData<uint>("Please input cubic capacity: ");
            designation = ConsoleInput.GetEnum<Designation>("Please input designation: ");
            factoryPrice = ConsoleInput.GetData<decimal>("Please input factory price: ");
            firstRegistration = ConsoleInput.GetData<string>("Please input first registration: ");
            fuelType = ConsoleInput.GetEnum<FuelType>("Please input fuel type: ");
            price = ConsoleInput.GetData<decimal>("Please input price: ");
            gearBox = ConsoleInput.GetData<string>("Please input gearbox: ");
            mileage = ConsoleInput.GetData<uint>("Please input mileage: ");
            model = ConsoleInput.GetData<string>("Please input model: ");
            horsePower = ConsoleInput.GetData<uint>("Please input horse power: ");
            state = ConsoleInput.GetEnum<VehicleState>("Please input state: ");

            numbers = ConsoleInput.GetData<uint>("Please input number of delivered motorcycles: ");

            Motorcycle motorcycle = new Motorcycle(torque, motorcycleType, brand, cubicCapacity, designation, factoryPrice, firstRegistration, fuelType, price, gearBox, iD, mileage, model, horsePower, state);

            var prototype = new VehiclePrototype<Motorcycle>(motorcycle);

            for (int i = 0; i < numbers; i++)
            {
                VehiclePrototype<Motorcycle> tempotype = prototype.Clone() as VehiclePrototype<Motorcycle>;

                long id = DateTime.Now.Ticks;
                tempotype.vehicle.Id = (uint)id + (uint)i;
                Database.Load();
                Database.motorcycles.Add(tempotype.vehicle);
                Database.Save();
                Console.Clear();
            }
        }

        public string ExtendedToString()
        {
            return string.Format("Motorcycle information \n====================== \nModel:{0}\nBrand:{1}\nID:{2}\nRegistration:{3}\nMotorcycle type:{4}\nDesignation:{5}\nFactory price:{6}\nPrice:{7}\nCubic capacity:{8}\nGearbox:{9}\nFuel type:{10}\nHorse power:{11}\nTorque:{12}\nMileage:{13}\n======================", this.Model, this.Brand, this.Id, this.FirstRegistration, this.MotorcycleType, this.Designation, this.FactoryPrice, this.Price, this.CubicCapacity, this.GearBox, this.FuelType, this.HorsePower, this.Torque, this.Mileage);
        }
    }
}