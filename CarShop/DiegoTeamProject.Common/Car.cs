using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Car : Vehicle
    {
        //Constructors 
        public Car(decimal torque, CarType carType,
                   // inherited from vehicule
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
            this.CarType = carType;
        }

        public decimal Torque { get; set; }

        // inherit CarType enum
        public CarType CarType { get; set; }

        public static void Add()
        {
            uint numbers = 0; ////This is no need for seller, client, rent, sale, upgrade and exchange

            decimal torque = 0;
            CarType carType = new CarType();
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
            carType = ConsoleInput.GetEnum<CarType>("Please input car type: ");
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

            ////This is no need for seller, client, rent, sale, upgrade and exchange
            numbers = ConsoleInput.GetData<uint>("Please input number of delivered cars: ");

            Car car = new Car(torque, carType, brand, cubicCapacity, designation, factoryPrice, firstRegistration, fuelType, price, gearBox, iD, mileage, model, horsePower, state);

            /*This is no need for seller, client, rent, sale, upgrade and exchange just this rows: 
            *  Database.Reload();
            Database.cars.Add(tempotype.vehicle);
            Database.Reload();
            Console.Clear();
            */

            var prototype = new VehiclePrototype<Car>(car);

            for (int i = 0; i < numbers; i++)
            {
                VehiclePrototype<Car> tempotype = prototype.Clone() as VehiclePrototype<Car>;

                long id = DateTime.Now.Ticks;
                tempotype.vehicle.Id = (uint)id + (uint)i;
                Database.Load();
                Database.cars.Add(tempotype.vehicle);
                Database.Save();
                Console.Clear();
            }
        }

        public string ExtendedToString()
        {
            return string.Format("Car information \n====================== \nModel:{0}\nBrand:{1}\nID:{2}\nRegistration:{3}\nCar type:{4}\nDesignation:{5}\nFactory price:{6:c}\nPrice:{7:c}\nCubic capacity{8}\nGearbox:{9}\nFuel type:{10}\nHorse power:{11}\nTorque:{12}\nMileage:{13}\n======================", this.Model, this.Brand, this.Id, this.FirstRegistration, this.CarType, this.Designation, this.FactoryPrice, this.Price, this.CubicCapacity, this.GearBox, this.FuelType, this.HorsePower, this.Torque, this.Mileage);
        }
    }
}