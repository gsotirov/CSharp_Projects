using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Upgrade : Deal
    {
        //constructors
        public Upgrade(int id, int clientID, int sellerID, DateTime dateTime, string vehicle, PaymentMethods paymentMethod, decimal totalSum, int warranty, int sureCharge, string currentVehicle) : base(id, clientID, sellerID, dateTime, vehicle, paymentMethod, totalSum)
        {
            this.Warranty = warranty;
            this.SureCharge = sureCharge;
            this.CurrentVehicle = currentVehicle;
        }

        public int Warranty { get; set; }

        public int SureCharge { get; set; }

        public string CurrentVehicle { get; set; }

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
            int sureCharge = 0;
            string currentVehicle = string.Empty;

            id = ConsoleInput.GetData<int>("Please input sell ID: ");
            clientID = ConsoleInput.GetData<int>("Please input client ID: ");
            sellerID = ConsoleInput.GetData<int>("Please input seller ID: ");
            date = ConsoleInput.GetDateTime("Please input date :");
            vehicle = ConsoleInput.GetData<string>("Please input a vehicle: ");
            paymentMethod = ConsoleInput.GetEnum<PaymentMethods>("Please input payment method: ");
            totalSum = ConsoleInput.GetData<decimal>("Please input total sum: ");
            warranty = ConsoleInput.GetData<int>("Please input warranty: ");
            sureCharge = ConsoleInput.GetData<int>("Please input charge: ");
            currentVehicle = ConsoleInput.GetData<string>("Please input a vehicle: ");

            Upgrade upgrade = new Upgrade(id, clientID, sellerID, date, vehicle, paymentMethod, totalSum, warranty, sureCharge, currentVehicle);

            Database.Load();
            Database.upgrades.Add(upgrade);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Upgrade Vehicle \n====================== \nID:{0}\nClientID:{1}\nSellerID:{2}\nDate and time:{3}\nVehicle:{4}\nPayment method:{5}\nTotal sum:{6}\nWarranty:{7}\nSure Charge:{8}\nCurrent Vehicle:{9}\n======================", this.ID, this.ClientID, this.SellerID, this.DateTime, this.Vehicle, this.PaymentMethod, this.TotalSum, this.Warranty, this.SureCharge, this.CurrentVehicle);
        }

        public override string ToString()
        {
            return string.Format("Upgrade ---> ID: {0}  Client: {1}  Seller: {2}  Current Vehicle: {3}  Vehicle: {4}", this.ID, this.ClientID, this.SellerID, this.CurrentVehicle, this.Vehicle);
        }
    }
}