using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Sale : Deal
    {
        //constructors
        public Sale(int id, int clientID, int sellerID, DateTime dateTime, string vehicle, PaymentMethods paymentMethod, decimal totalSum, int warranty, decimal price) : base(id, clientID, sellerID, dateTime, vehicle, paymentMethod, totalSum)
        {
            this.Warranty = warranty;
            this.Price = price;
        }

        public int Warranty { get; set; }

        public decimal Price { get; set; }

        public static void Add()
        {
            int id = 0;
            int clientID = 0;
            int sellerID = 0;
            DateTime date = new DateTime();
            string vehicle = string.Empty;
            PaymentMethods paymentMethod = new PaymentMethods();
            decimal totalSum = 0;
            int warranty = 0;
            decimal price = 0;

            id = ConsoleInput.GetData<int>("Please input sell ID: ");
            clientID = ConsoleInput.GetData<int>("Please input client ID: ");
            sellerID = ConsoleInput.GetData<int>("Please input seller ID: ");
            date = ConsoleInput.GetDateTime("Please input date :");
            vehicle = ConsoleInput.GetData<string>("Please input a vehicle: ");
            paymentMethod = ConsoleInput.GetEnum<PaymentMethods>("Please input payment method: ");
            totalSum = ConsoleInput.GetData<decimal>("Please input total sum: ");
            warranty = ConsoleInput.GetData<int>("Please input warranty: ");
            price = ConsoleInput.GetData<decimal>("Please input price: ");

            Sale sale = new Sale(id, clientID, sellerID, date, vehicle, paymentMethod, totalSum, warranty, price);

            Database.Load();
            Database.sales.Add(sale);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Sell \n====================== \nID:{0}\nClientID:{1}\nSellerID:{2}\nDate and time:{3}\nVehicle:{4}\nPayment method:{5}\nTotal sum:{6}\nWarranty:{7}\nPrice:{9}\n======================", this.ID, this.ClientID, this.SellerID, this.DateTime, this.Vehicle, this.PaymentMethod, this.TotalSum, this.Warranty, this.Price);
        }

        public override string ToString()
        {
            return string.Format("Sale ---> ID: {0}  Client: {1}  Seller: {2}  Vehicle: {3}  Price: {4}", this.ID, this.ClientID, this.SellerID, this.Vehicle, this.Price);
        }
    }
}