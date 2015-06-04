using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class OffRoad : Vehicle
    {
        public OffRoad(DrivingWheels drivingWheels, OffRoadType offroadType,
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
            this.DrivingWheels = drivingWheels;
            this.OffroadType = offroadType;
        }

        public DrivingWheels DrivingWheels { get; set; }

        public OffRoadType OffroadType { get; set; }

        public static void Add()
        {
            uint numbers = 0;

            DrivingWheels drivingWheels = new DrivingWheels();
            OffRoadType offroadType = new OffRoadType();
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

            drivingWheels = ConsoleInput.GetEnum<DrivingWheels>("Please input driving wheels");
            offroadType = ConsoleInput.GetEnum<OffRoadType>("Please input the type of your offroad vehicle");
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

            numbers = ConsoleInput.GetData<uint>("Please input number of delivered offroad vehicles: ");

            OffRoad offroad = new OffRoad(drivingWheels, offroadType, brand, cubicCapacity, designation, factoryPrice, firstRegistration, fuelType, price, gearBox, iD, mileage, model, horsePower, state);

            var prototype = new VehiclePrototype<OffRoad>(offroad);

            for (int i = 0; i < numbers; i++)
            {
                VehiclePrototype<OffRoad> tempotype = prototype.Clone() as VehiclePrototype<OffRoad>;

                long id = DateTime.Now.Ticks;
                tempotype.vehicle.Id = (uint)id + (uint)i;
                Database.Load();
                Database.offRoads.Add(tempotype.vehicle);
                Database.Save();
                Console.Clear();
            }
        }

        public string ExtendedToString()
        {
            return string.Format("Offroad information \n====================== \nModel:{0}\nBrand:{1}\nID:{2}\nRegistration:{3}\nOfroad type:{4}\nDesignation:{5}\nFactory price:{6}\nPrice:{7}\nCubic capacity:{8}\nGearbox:{9}\nFuel type:{10}\nHorse power:{11}\nMileage:{12}\nDrivingWheels{13}\n======================", this.Model, this.Brand, this.Id, this.FirstRegistration, this.OffroadType, this.Designation, this.FactoryPrice, this.Price, this.CubicCapacity, this.GearBox, this.FuelType, this.HorsePower, this.Mileage, this.DrivingWheels);
        }
    }
}