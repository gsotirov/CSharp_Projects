using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Exchange : Deal
    {
        //constructors
        public Exchange(int id, int clientID, int sellerID, DateTime dateTime, string vehicle, PaymentMethods paymentMethod, decimal totalSum, int discount, string oldVehicle) : base(id, clientID, sellerID, dateTime, vehicle, paymentMethod, totalSum)
        {
            this.Discount = discount;
            this.OldVehicle = oldVehicle;
        }

        public int Discount { get; set; }

        public string OldVehicle { get; set; }

        public static void Add()
        {
            int id = 0;
            int clientID = 0;
            int sellerID = 0;
            DateTime date = new DateTime();
            string vehicle = string.Empty;
            PaymentMethods paymentMethod = new PaymentMethods();
            decimal totalSum = 0;
            int discount = 0;
            string oldVehicle = string.Empty;

            id = ConsoleInput.GetData<int>("Please input sale ID: ");
            clientID = ConsoleInput.GetData<int>("Please input client ID: ");
            sellerID = ConsoleInput.GetData<int>("Please input seller ID: ");
            date = ConsoleInput.GetDateTime("Please input date : ");
            vehicle = ConsoleInput.GetData<string>("Please input a vehicle: ");
            paymentMethod = ConsoleInput.GetEnum<PaymentMethods>("Please input payment method: ");
            totalSum = ConsoleInput.GetData<decimal>("Please input total sum: ");
            discount = ConsoleInput.GetData<int>("Please input discount ");
            oldVehicle = ConsoleInput.GetData<string>("Please input old Vehicles: ");
            id = ConsoleInput.GetData<int>("Please input client ID: ");

            Exchange exchange = new Exchange(id, clientID, sellerID, date, vehicle, paymentMethod, totalSum, discount, oldVehicle);

            Database.Load();
            Database.exchanges.Add(exchange);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Exchange Vehicle \n====================== \nID:{0}\nClientID:{1}\nSellerID:{2}\nDate and time:{3}\nVehicle:{4}\nPayment method:{5}\nTotal sum:{6}\nDiscount:{7}\nOld Vehicle:{8}\n======================", this.ID, this.ClientID, this.SellerID, this.DateTime, this.Vehicle, this.PaymentMethod, this.TotalSum, this.Discount, this.OldVehicle);
        }

        public override string ToString()
        {
            return string.Format("Exchange ---> ID: {0}  Client: {1}  Seller: {2}  Vehicle: {3}  Old Vehicle: {4}", this.ID, this.ClientID, this.SellerID, this.Vehicle, this.OldVehicle);
        }
    }
}