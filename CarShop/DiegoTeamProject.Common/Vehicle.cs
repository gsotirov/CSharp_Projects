using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public abstract class Vehicle
    {
        // Fields
        private VehicleState state;

        //Constructors.
        public Vehicle(
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
            VehicleState state)
        {
            this.Brand = brand;
            this.CubicCapacity = cubicCapacity;
            this.Designation = designation;
            this.FactoryPrice = factoryPrice;
            this.FirstRegistration = firstRegistration;
            this.FuelType = fuelType;
            this.Price = price;
            this.GearBox = gearBox;
            this.Id = id;
            this.Mileage = mileage;
            this.Model = model;
            this.HorsePower = horsePower;
            this.State = state;
        }

        public Vehicle()
        {
        }

        // Properties
        public uint CubicCapacity { get; protected set; }

        public decimal FactoryPrice { get; protected set; }

        public string FirstRegistration { get; protected set; }

        public decimal Price { get; protected set; }

        public string GearBox { get; protected set; }

        public uint Id { get; protected set; }

        public uint Mileage { get; protected set; }

        public string Model { get; protected set; }

        public uint HorsePower { get; protected set; }

        public string Brand { get; protected set; }

        public Designation Designation { get; protected set; }// rent, sale

        public FuelType FuelType { get; protected set; }// "Benz", "Diesel", "Gas"

        public VehicleState State { get; set; }// OnRent, Defect, Broken

        //Methods.
        public void GoService()
        {
            this.state = VehicleState.Available;
        }

        public void Crashed()
        {
            this.state = VehicleState.Broken;
        }

        public void Defected()
        {
            this.state = VehicleState.Defect;
        }

        public void GoTechnicalInspection()
        {
            this.state = VehicleState.Available;
        }

        public override string ToString()
        {
            return string.Format("{0}  ID: {1}  Brand: {2}   Model: {3}   Price: {4}", this.GetType().Name, this.Id, this.Brand, this.Model, this.Price);
        }
    }
}