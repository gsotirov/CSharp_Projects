using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Depot
    {
        public Depot(List<Vehicle> listOfVehicles)
        {
            this.VehicleDepot = new List<Vehicle>(listOfVehicles);
        }

        public List<Vehicle> VehicleDepot { get; set; }

        public List<Vehicle> StockForRent
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.Designation == Designation.ForRent && vehicle.State == VehicleState.Available);
                return stock.ToList<Vehicle>();
            }
        }

        public List<Vehicle> StockForSell
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.Designation == Designation.ForSale && vehicle.State == VehicleState.Available);
                return stock.ToList<Vehicle>();
            }
        }

        public List<Vehicle> StockForService
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.State == VehicleState.Broken);
                return stock.ToList<Vehicle>();
            }
        }

        public List<Vehicle> StockForScrap
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.State == VehicleState.TotalDamage);
                return stock.ToList<Vehicle>();
            }
        }

        public List<Vehicle> StockForInspection
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.State == VehicleState.ForInspection);
                return stock.ToList<Vehicle>();
            }
        }

        public List<Vehicle> Stock
        {
            get
            {
                return this.VehicleDepot;
            }
        }

        public List<Vehicle> StockForReplacement
        {
            get
            {
                var stock = this.VehicleDepot.Where(vehicle => vehicle.State == VehicleState.Defect);
                return stock.ToList<Vehicle>();
            }
        }

        public void TechnicalInspectionAll()
        {
            Vehicle[] workArray = Database.cars.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.ForInspection)
                {
                    workArray[i].State = VehicleState.Available;
                }
            }

            Database.cars = new List<Car>((Car[])workArray);

            workArray = Database.offRoads.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.ForInspection)
                {
                    workArray[i].State = VehicleState.Available;
                }
            }

            Database.offRoads = new List<OffRoad>((OffRoad[])workArray);

            workArray = Database.motorcycles.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.ForInspection)
                {
                    workArray[i].State = VehicleState.Available;
                }
            }

            Database.motorcycles = new List<Motorcycle>((Motorcycle[])workArray);

            workArray = Database.trucks.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.ForInspection)
                {
                    workArray[i].State = VehicleState.Available;
                }
            }

            Database.trucks = new List<Truck>((Truck[])workArray);

            Database.Save();
        }

        public void ServiceAll()
        {
            Vehicle[] workArray = Database.cars.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Broken)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.cars = new List<Car>((Car[])workArray);

            workArray = Database.offRoads.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Broken)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.offRoads = new List<OffRoad>((OffRoad[])workArray);

            workArray = Database.motorcycles.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Broken)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.motorcycles = new List<Motorcycle>((Motorcycle[])workArray);

            workArray = Database.trucks.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Broken)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.trucks = new List<Truck>((Truck[])workArray);

            Database.Save();
        }

        public void ReplaceAll()
        {
            Vehicle[] workArray = Database.cars.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Defect)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.cars = new List<Car>((Car[])workArray);

            workArray = Database.offRoads.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Defect)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.offRoads = new List<OffRoad>((OffRoad[])workArray);

            workArray = Database.motorcycles.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Defect)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.motorcycles = new List<Motorcycle>((Motorcycle[])workArray);

            workArray = Database.trucks.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.Defect)
                {
                    workArray[i].State = VehicleState.ForInspection;
                }
            }

            Database.trucks = new List<Truck>((Truck[])workArray);

            Database.Save();
        }

        public void ScrappingAll()
        {
            Vehicle[] workArray = Database.cars.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.TotalDamage)
                {
                    Database.cars.Remove((Car)workArray[i]);
                }
            }

            workArray = Database.offRoads.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.TotalDamage)
                {
                    Database.offRoads.Remove((OffRoad)workArray[i]);
                }
            }

            workArray = Database.motorcycles.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.TotalDamage)
                {
                    Database.motorcycles.Remove((Motorcycle)workArray[i]);
                }
            }

            workArray = Database.trucks.ToArray();
            for (int i = 0; i < workArray.Length; i++)
            {
                if (workArray[i].State == VehicleState.TotalDamage)
                {
                    Database.trucks.Remove((Truck)workArray[i]);
                }
            }

            Database.Save();
        }
    }
}