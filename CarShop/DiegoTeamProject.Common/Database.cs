using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public static class Database
    {
        public static List<Deal> deals = new List<Deal>();
        public static List<Rent> rents = new List<Rent>();
        public static List<Sale> sales = new List<Sale>();
        public static List<Upgrade> upgrades = new List<Upgrade>();
        public static List<Exchange> exchanges = new List<Exchange>();
        public static List<Client> clients = new List<Client>();
        public static List<Seller> sellers = new List<Seller>();
        public static List<Vehicle> vehicles = new List<Vehicle>();
        public static List<Car> cars = new List<Car>();
        public static List<Motorcycle> motorcycles = new List<Motorcycle>();
        public static List<OffRoad> offRoads = new List<OffRoad>();
        public static List<Truck> trucks = new List<Truck>();

        public static void Load()
        {
            deals.Clear();
            rents.Clear();
            sales.Clear();
            upgrades.Clear();
            exchanges.Clear();
            clients.Clear();
            sellers.Clear();
            vehicles.Clear();
            cars.Clear();
            motorcycles.Clear();
            offRoads.Clear();
            trucks.Clear();

            try
            {
                using (StreamReader read = new StreamReader("rents.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        rents.Add(new Rent(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), DateTime.Parse(values[3]), values[4], (PaymentMethods)Enum.Parse(typeof(PaymentMethods), values[5]), decimal.Parse(values[6]), int.Parse(values[7]), values[8], decimal.Parse(values[9])));
                    }
                }

                using (StreamReader read = new StreamReader("sales.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        sales.Add(new Sale(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), DateTime.Parse(values[3]), values[4], (PaymentMethods)Enum.Parse(typeof(PaymentMethods), values[5]), decimal.Parse(values[6]), int.Parse(values[7]), decimal.Parse(values[8])));
                    }
                }

                using (StreamReader read = new StreamReader("upgrades.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        upgrades.Add(new Upgrade(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), DateTime.Parse(values[3]), values[4], (PaymentMethods)Enum.Parse(typeof(PaymentMethods), values[5]), decimal.Parse(values[6]), int.Parse(values[7]), int.Parse(values[8]), values[9]));
                    }
                }

                using (StreamReader read = new StreamReader("exchanges.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        exchanges.Add(new Exchange(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), DateTime.Parse(values[3]), values[4], (PaymentMethods)Enum.Parse(typeof(PaymentMethods), values[5]), decimal.Parse(values[6]), int.Parse(values[7]), values[8]));
                    }
                }

                using (StreamReader read = new StreamReader("clients.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        clients.Add(new Client(int.Parse(values[0]), new PersonalDetails(int.Parse(values[1]), int.Parse(values[2]), values[3]), DateTime.Parse(values[4]), (ClientType)Enum.Parse(typeof(ClientType), values[5])));
                    }
                }

                using (StreamReader read = new StreamReader("sellers.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        sellers.Add(new Seller(int.Parse(values[0]), new PersonalDetails(int.Parse(values[1]), int.Parse(values[2]), values[3]), DateTime.Parse(values[4]), decimal.Parse(values[5])));
                    }
                }

                using (StreamReader read = new StreamReader("cars.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        cars.Add(new Car(decimal.Parse(values[0]), (CarType)Enum.Parse(typeof(CarType), values[1]), values[2], uint.Parse(values[3]), (Designation)Enum.Parse(typeof(Designation), values[4]), decimal.Parse(values[5]), values[6], (FuelType)Enum.Parse(typeof(FuelType), values[7]), decimal.Parse(values[8]), values[9], uint.Parse(values[10]), uint.Parse(values[11]), values[12], uint.Parse(values[13]), (VehicleState)Enum.Parse(typeof(VehicleState), values[14])));
                    }
                }

                using (StreamReader read = new StreamReader("motorcycles.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        motorcycles.Add(new Motorcycle(decimal.Parse(values[0]), (MotorcycleType)Enum.Parse(typeof(MotorcycleType), values[1]), values[2], uint.Parse(values[3]), (Designation)Enum.Parse(typeof(Designation), values[4]), decimal.Parse(values[5]), values[6], (FuelType)Enum.Parse(typeof(FuelType), values[7]), decimal.Parse(values[8]), values[9], uint.Parse(values[10]), uint.Parse(values[11]), values[12], uint.Parse(values[13]), (VehicleState)Enum.Parse(typeof(VehicleState), values[14])));
                    }
                }

                using (StreamReader read = new StreamReader("offRoads.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        offRoads.Add(new OffRoad((DrivingWheels)Enum.Parse(typeof(DrivingWheels), values[0]), (OffRoadType)Enum.Parse(typeof(OffRoadType), values[1]), values[2], uint.Parse(values[3]), (Designation)Enum.Parse(typeof(Designation), values[4]), decimal.Parse(values[5]), values[6], (FuelType)Enum.Parse(typeof(FuelType), values[7]), decimal.Parse(values[8]), values[9], uint.Parse(values[10]), uint.Parse(values[11]), values[12], uint.Parse(values[13]), (VehicleState)Enum.Parse(typeof(VehicleState), values[14])));
                    }
                }

                using (StreamReader read = new StreamReader("trucks.txt"))
                {
                    int size = int.Parse(read.ReadLine());
                    for (int y = 0; y < size; y++)
                    {
                        string[] values = read.ReadLine().Split('*');
                        trucks.Add(new Truck(int.Parse(values[0]), int.Parse(values[1]), (TruckType)Enum.Parse(typeof(TruckType), values[2]), values[3], uint.Parse(values[4]), (Designation)Enum.Parse(typeof(Designation), values[5]), decimal.Parse(values[6]), values[7], (FuelType)Enum.Parse(typeof(FuelType), values[8]), decimal.Parse(values[9]), values[10], uint.Parse(values[11]), uint.Parse(values[12]), values[13], uint.Parse(values[14]), (VehicleState)Enum.Parse(typeof(VehicleState), values[15])));
                    }
                }
            }
            catch (Exception)
            {
                throw new MissingDatabaseException();
            }

            Database.ReloadMainDB();
        }

        public static void Save()
        {
            try
            {
                using (StreamWriter write = new StreamWriter("clients.txt"))
                {
                    write.WriteLine(clients.Count);
                    foreach (var client in clients)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}", client.ID, client.PersonalDetails.PersonalID, client.PersonalDetails.DocumentID, client.PersonalDetails.Name, client.StartDate, client.Type);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("sellers.txt"))
                {
                    write.WriteLine(sellers.Count);
                    foreach (var client in sellers)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}", client.ID, client.PersonalDetails.PersonalID, client.PersonalDetails.DocumentID, client.PersonalDetails.Name, client.StartDate, client.Rate);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("rents.txt"))
                {
                    write.WriteLine(rents.Count);
                    foreach (var rent in rents)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}", rent.ID, rent.ClientID, rent.SellerID, rent.DateTime, rent.Vehicle, rent.PaymentMethod, rent.TotalSum, rent.Period, rent.Insurance, rent.DailyPrice);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("sales.txt"))
                {
                    write.WriteLine(sales.Count);
                    foreach (var sale in sales)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}", sale.ID, sale.ClientID, sale.SellerID, sale.DateTime, sale.Vehicle, sale.PaymentMethod, sale.TotalSum, sale.Warranty, sale.Price);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("upgrades.txt"))
                {
                    write.WriteLine(upgrades.Count);
                    foreach (var upgrade in upgrades)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}", upgrade.ID, upgrade.ClientID, upgrade.SellerID, upgrade.DateTime, upgrade.Vehicle, upgrade.PaymentMethod, upgrade.TotalSum, upgrade.Warranty, upgrade.SureCharge, upgrade.CurrentVehicle);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("exchanges.txt"))
                {
                    write.WriteLine(exchanges.Count);
                    foreach (var exchange in exchanges)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}", exchange.ID, exchange.ClientID, exchange.SellerID, exchange.DateTime, exchange.Vehicle, exchange.PaymentMethod, exchange.TotalSum, exchange.Discount, exchange.OldVehicle);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("cars.txt"))
                {
                    write.WriteLine(cars.Count);
                    foreach (var car in cars)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}*{10}*{11}*{12}*{13}*{14}", car.Torque, car.CarType, car.Brand, car.CubicCapacity, car.Designation, car.FactoryPrice, car.FirstRegistration, car.FuelType, car.Price, car.GearBox, car.Id, car.Mileage, car.Model, car.HorsePower, car.State);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("motorcycles.txt"))
                {
                    write.WriteLine(motorcycles.Count);
                    foreach (var motorcycle in motorcycles)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}*{10}*{11}*{12}*{13}*{14}", motorcycle.Torque, motorcycle.MotorcycleType, motorcycle.Brand, motorcycle.CubicCapacity, motorcycle.Designation, motorcycle.FactoryPrice, motorcycle.FirstRegistration, motorcycle.FuelType, motorcycle.Price, motorcycle.GearBox, motorcycle.Id, motorcycle.Mileage, motorcycle.Model, motorcycle.HorsePower, motorcycle.State);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("offRoads.txt"))
                {
                    write.WriteLine(offRoads.Count);
                    foreach (var offRoad in offRoads)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}*{10}*{11}*{12}*{13}*{14}", offRoad.DrivingWheels, offRoad.OffroadType, offRoad.Brand, offRoad.CubicCapacity, offRoad.Designation, offRoad.FactoryPrice, offRoad.FirstRegistration, offRoad.FuelType, offRoad.Price, offRoad.GearBox, offRoad.Id, offRoad.Mileage, offRoad.Model, offRoad.HorsePower, offRoad.State);
                        write.WriteLine(line);
                    }
                }

                using (StreamWriter write = new StreamWriter("trucks.txt"))
                {
                    write.WriteLine(trucks.Count);
                    foreach (var truck in trucks)
                    {
                        string line = string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}*{10}*{11}*{12}*{13}*{14}*{15}", truck.Load, truck.Axes, truck.TruckType, truck.Brand, truck.CubicCapacity, truck.Designation, truck.FactoryPrice, truck.FirstRegistration, truck.FuelType, truck.Price, truck.GearBox, truck.Id, truck.Mileage, truck.Model, truck.HorsePower, truck.State);
                        write.WriteLine(line);
                    }
                }
            }
            catch (Exception)
            {
                throw new MissingDatabaseException();
            }

            Database.Load();
        }

        public static void ReloadMainDB()
        {
            deals.Clear();
            deals.AddRange(rents);
            deals.AddRange(sales);
            deals.AddRange(upgrades);
            deals.AddRange(exchanges);
            vehicles.Clear();
            vehicles.AddRange(cars);
            vehicles.AddRange(motorcycles);
            vehicles.AddRange(offRoads);
            vehicles.AddRange(trucks);
        }
    }
}