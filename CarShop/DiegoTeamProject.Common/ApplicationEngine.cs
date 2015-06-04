using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class ApplicationEngine
    {
        private static bool termSignal = false;
        private static bool inputTermSignal = false;

        private readonly MenuPrinter printer = new MenuPrinter();
        private readonly IUserInterface keyboard = new KeyboardInterface();
        private Depot depot;
        private Menu dealsDataBaseMenu;
        private Menu vehiclesDataBaseMenu;
        private Menu clientsDataBaseMenu;
        private Menu sellersDataBaseMenu;
        private Menu vehForRent;
        private Menu vehForSale;
        private Menu damagedVeh;
        private Menu totalDamagedVeh;
        private Menu defectVeh;
        private Menu vehForInspection;
        private Menu currentMenu;

        public static void PrepareConsole()
        {
            int width = 90;
            int height = 30;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "DIEGO VEHICLES™";
            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.BufferWidth = width;
            Console.WindowHeight = height;
            ////Console.BufferHeight = height;
        }

        public static void PrintStartScreen()
        {
            ConsoleColor[] colorsArray = new ConsoleColor[]
            {
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green,
                ConsoleColor.Magenta,
                ConsoleColor.Red,
                ConsoleColor.Yellow
            };

            for (int i = 1; i < 90; i++)
            {
                System.Threading.Thread.Sleep(70);

                Random randomNumber = new Random();
                Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(
                    @"                     ________ __________________________________              
                     ___  __ \____  _/___  ____/__  ____/__  __ \             
                     __  / / / __  /  __  __/   _  / __  _  / / /             
                     _  /_/ / __/ /   _  /___   / /_/ /  / /_/ /              
                     /_____/  /___/   /_____/   \____/   \____/               
                                                                              
       ___    __________________  _________________________ __________________
       __ |  / /___  ____/___  / / /____  _/__  ____/___  / ___  ____/__  ___/
       __ | / / __  __/   __  /_/ /  __  /  _  /     __  /  __  __/   _____ \ 
       __ |/ /  _  /___   _  __  /  __/ /   / /___   _  /____  /___   ____/ / 
       _____/   /_____/   /_/ /_/   /___/   \____/   /_____//_____/   /____/  
                                                                              ");
                if (i < 40)
                {
                    Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                    Console.SetCursorPosition(i - 1, 15);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(i, 15);
                    Console.WriteLine("Zenny");

                    Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                    Console.SetCursorPosition(77 - i + 1, 17);
                    Console.WriteLine("        ");
                    Console.SetCursorPosition(77 - i, 17);
                    Console.WriteLine("GOODJEFF");

                    Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                    Console.SetCursorPosition(i - 1, 19);
                    Console.WriteLine("        ");
                    Console.SetCursorPosition(i, 19);
                    Console.WriteLine("cortez ™");

                    Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                    Console.SetCursorPosition(78 - i + 1, 21);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(78 - i, 21);
                    Console.WriteLine("KaLiN");
                }

                if (i < 39)
                {
                    Console.ForegroundColor = colorsArray[randomNumber.Next(0, 11)];
                    Console.SetCursorPosition(i - 1, 23);
                    Console.WriteLine("        ");
                    Console.SetCursorPosition(i, 23);
                    Console.WriteLine("Stoyanov");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void Initialization()
        {
            PrepareConsole();

            Database.Load();

            this.depot = new Depot(Database.vehicles);

            this.dealsDataBaseMenu = Menu.Create(Database.deals);
            this.vehiclesDataBaseMenu = Menu.Create(Database.vehicles);
            this.clientsDataBaseMenu = Menu.Create(Database.clients);
            this.sellersDataBaseMenu = Menu.Create(Database.sellers);
            this.vehForRent = Menu.Create(this.depot.StockForRent);
            this.vehForSale = Menu.Create(this.depot.StockForSell);
            this.damagedVeh = Menu.Create(this.depot.StockForService);
            this.totalDamagedVeh = Menu.Create(this.depot.StockForScrap);
            this.defectVeh = Menu.Create(this.depot.StockForReplacement);
            this.vehForInspection = Menu.Create(this.depot.StockForInspection);

            ////          Main Menu
            MenuItem makeDeal = new MenuItem(1, "Make Deal", 1, "Make Deal", true); ////
            MenuItem addClient = new MenuItem(2, "Add Client", 2, "Add Client"); ////
            MenuItem addSeller = new MenuItem(3, "Add Seller", 3, "Add Seller"); ////
            MenuItem addVehicle = new MenuItem(4, "Add Vehicle", 4, "Add Vehicle"); ////
            MenuItem dataBase = new MenuItem(4, "DataBase", 4, "DataBase"); ////
            MenuItem stock = new MenuItem(5, "Stock", 5, "Stock"); ////
            MenuItem depotMenuItem = new MenuItem(6, "Depot", 6, "Depot"); ////
            MenuItem exit = new MenuItem(999999999, "Exit", 999999999, "Exit");
            List<MenuItem> mainMenuList = new List<MenuItem>()
            {
                makeDeal,
                addClient,
                addSeller,
                addVehicle,
                dataBase,
                stock,
                depotMenuItem,
                exit
            };
            Menu mainMenu = new Menu(mainMenuList);

            ////          Make Deal Menu
            MenuItem makeSale = new MenuItem(1, "Make Sale", 1, "Make Sale", true); ////
            MenuItem makeRent = new MenuItem(2, "Make Rent", 2, "Make Rent"); ////
            MenuItem makeExchange = new MenuItem(3, "Make Exchange", 3, "Make Exchange"); ////
            MenuItem makeUpgrade = new MenuItem(4, "Make Upgrade", 4, "Make Upgrade"); ////
            MenuItem back = new MenuItem(999999999, "Back", 999999999, "Main"); ////
            List<MenuItem> makeDealMenuList = new List<MenuItem>()
            {
                makeSale,
                makeRent,
                makeExchange,
                makeUpgrade,
                back
            };
            Menu makeDealMenu = new Menu(makeDealMenuList);

            ////           Make Depot Menu
            MenuItem allService = new MenuItem(1, "Service All Damaged Vehicles", 1, "Service All Vehicles", true); ////
            MenuItem allInspect = new MenuItem(2, "Inspect All Vehicles for Inspection", 2, "Inspect All Vehicles"); ////
            MenuItem allReplace = new MenuItem(3, "Exchange All Defect Vehicles", 3, "Exchange All Defect Vehicles"); ////
            MenuItem allScrap = new MenuItem(4, "Scrap All Total Damaged Vehicles", 4, "Scrap All Total Damaged Vehicles"); ////
            List<MenuItem> depotMenuList = new List<MenuItem>()
            {
                allService,
                allInspect,
                allScrap,
                allReplace,
                back
            };
            Menu depotMenu = new Menu(depotMenuList);

            ////         Add Vehicle Menu
            MenuItem addCar = new MenuItem(1, "Add Car", 1, "Add Car", true); ////
            MenuItem addMotorcycle = new MenuItem(2, "Add Motorcycle", 2, "Add Motorcycle"); ////
            MenuItem addOffRoad = new MenuItem(3, "Add OffRoad", 3, "Add OffRoad"); ////
            MenuItem addTruck = new MenuItem(4, "Add Truck", 4, "Add Truck"); ////
            List<MenuItem> addVehicleMenuList = new List<MenuItem>()
            {
                addCar,
                addMotorcycle,
                addOffRoad,
                addTruck,
                back
            };
            Menu addVehicleMenu = new Menu(addVehicleMenuList);

            ////          DataBase Menu
            MenuItem clientsDataBase = new MenuItem(1, "Clients DataBase", 1, "Clients DataBase", true); ////
            MenuItem sellersDataBase = new MenuItem(2, "Sellers DataBase", 2, "Sellers DataBase"); ////
            MenuItem vehiclesDataBase = new MenuItem(3, "Vehicles DataBase", 3, "Vehicles DataBase"); ////
            MenuItem dealsDataBase = new MenuItem(4, "Deals DataBase", 4, "Deals DataBase"); ////
            List<MenuItem> dataBaseMenuList = new List<MenuItem>()
            {
                clientsDataBase,
                sellersDataBase,
                vehiclesDataBase,
                dealsDataBase,
                back
            };
            Menu dataBaseMenu = new Menu(dataBaseMenuList);

            ////          Stock Menu
            MenuItem vehiclesForRent = new MenuItem(1, "Vehicles for Rent", 1, "Vehicles for Rent", true);
            MenuItem vehiclesForSell = new MenuItem(2, "Vehicles for Sell", 2, "Vehicles for Sell");
            MenuItem damagedVehicles = new MenuItem(3, "Damaged Vehicles", 3, "Damaged Vehicles");
            MenuItem totalDamagedVehicles = new MenuItem(4, "Total Damaged Vehicles", 4, "Total Damaged Vehicles");
            MenuItem defectVehicles = new MenuItem(5, "Defect Vehicles", 5, "Defect Vehicles");
            MenuItem vehiclesForInspection = new MenuItem(6, "Vehicles for Inspection", 6, "Vehicles for Inspection");
            List<MenuItem> stockMenuList = new List<MenuItem>()
            {
                vehiclesForRent,
                vehiclesForSell,
                vehiclesForInspection,
                damagedVehicles,
                totalDamagedVehicles,
                defectVehicles,
                back
            };
            Menu stockMenu = new Menu(stockMenuList);

            this.currentMenu = mainMenu;

            this.keyboard.UpPress += (sender, eventInfo) =>
            {
                inputTermSignal = true;
                this.currentMenu.MoveUp();
            };

            this.keyboard.DownPress += (sender, eventInfo) =>
            {
                inputTermSignal = true;
                this.currentMenu.MoveDown();
            };

            this.keyboard.SelectPress += (sender, eventInfo) =>
            {
                inputTermSignal = true;

                Console.Clear();
                switch (this.currentMenu.Action())
                {
                    case "Main":
                        this.currentMenu = mainMenu;
                        break;
                    case "Make Deal":
                        this.currentMenu = makeDealMenu;
                        break;
                    case "Make Sale":
                        Sale.Add();
                        Database.Save();
                        this.currentMenu = makeDealMenu;
                        break;
                    case "Make Rent":
                        Rent.Add();
                        Database.Save();
                        this.currentMenu = makeDealMenu;
                        break;
                    case "Make Exchange":
                        Exchange.Add();
                        Database.Save();
                        this.currentMenu = makeDealMenu;
                        break;
                    case "Make Upgrade":
                        Upgrade.Add();
                        Database.Save();
                        this.currentMenu = makeDealMenu;
                        break;
                    case "Add Client":
                        Client.Add();
                        Database.Save();
                        this.currentMenu = mainMenu;
                        break;
                    case "Add Seller":
                        Seller.Add();
                        Database.Save();
                        this.currentMenu = mainMenu;
                        break;
                    case "Add Vehicle":
                        this.currentMenu = addVehicleMenu;
                        break;
                    case "Add Car":
                        Car.Add();
                        Database.Save();
                        this.currentMenu = addVehicleMenu;
                        break;
                    case "Add Motorcycle":
                        Motorcycle.Add();
                        Database.Save();
                        this.currentMenu = addVehicleMenu;
                        break;
                    case "Add OffRoad":
                        OffRoad.Add();
                        Database.Save();
                        this.currentMenu = addVehicleMenu;
                        break;
                    case "Add Truck":
                        Truck.Add();
                        Database.Save();
                        this.currentMenu = addVehicleMenu;
                        break;
                    case "Stock":
                        this.currentMenu = stockMenu;
                        break;
                    case "Vehicles for Rent":
                        this.currentMenu = this.vehForRent;
                        break;
                    case "Vehicles for Sell":
                        this.currentMenu = this.vehForSale;
                        break;
                    case "Damaged Vehicles":
                        this.currentMenu = this.damagedVeh;
                        break;
                    case "Total Damaged Vehicles":
                        this.currentMenu = this.totalDamagedVeh;
                        break;
                    case "Defect Vehicles":
                        this.currentMenu = this.defectVeh;
                        break;
                    case "Vehicles for Inspection":
                        this.currentMenu = this.vehForInspection;
                        break;
                    case "DataBase":
                        this.currentMenu = dataBaseMenu;
                        break;
                    case "Deals DataBase":
                        this.currentMenu = this.dealsDataBaseMenu;
                        break;
                    case "Clients DataBase":
                        this.currentMenu = this.clientsDataBaseMenu;
                        break;
                    case "Sellers DataBase":
                        this.currentMenu = this.sellersDataBaseMenu;
                        break;
                    case "Vehicles DataBase":
                        this.currentMenu = this.vehiclesDataBaseMenu;
                        break;
                    case "Depot":
                        this.currentMenu = depotMenu;
                        break;
                    case "Service All Vehicles":
                        Console.Clear();
                        this.depot.ServiceAll();
                        Database.Save();
                        Console.WriteLine("Done!");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "Exchange All Defect Vehicles":
                        Console.Clear();
                        this.depot.ReplaceAll();
                        Database.Save();
                        Console.WriteLine("Done!");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "Scrap All Total Damaged Vehicles":
                        Console.Clear();
                        this.depot.ScrappingAll();
                        Database.Save();
                        Console.WriteLine("Done!");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "Inspect All Vehicles":
                        Console.Clear();
                        this.depot.TechnicalInspectionAll();
                        Database.Save();
                        Console.WriteLine("Done!");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "Exit":
                        termSignal = true;
                        break;
                    default:
                        break;
                }
            };

            PrintStartScreen();
        }

        public void Run()
        {
            while (!termSignal)
            {
                Database.ReloadMainDB();

                this.depot = new Depot(Database.vehicles);

                this.dealsDataBaseMenu = Menu.Create(Database.deals);
                this.vehiclesDataBaseMenu = Menu.Create(Database.vehicles);
                this.clientsDataBaseMenu = Menu.Create(Database.clients);
                this.sellersDataBaseMenu = Menu.Create(Database.sellers);
                this.vehForRent = Menu.Create(this.depot.StockForRent);
                this.vehForSale = Menu.Create(this.depot.StockForSell);
                this.damagedVeh = Menu.Create(this.depot.StockForService);
                this.totalDamagedVeh = Menu.Create(this.depot.StockForScrap);
                this.defectVeh = Menu.Create(this.depot.StockForReplacement);
                this.vehForInspection = Menu.Create(this.depot.StockForInspection);

                System.Threading.Thread.Sleep(100);
                this.printer.Print(this.currentMenu);
                while (!inputTermSignal)
                {
                    this.keyboard.TakeInput();
                }

                inputTermSignal = false;
            }
        }
    }
}