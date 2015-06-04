using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Rent : Deal
    {
        //constructors
        public Rent(int id, int clientID, int sellerID, DateTime dateTime, string vehicle, PaymentMethods paymentMethod, decimal totalSum, int period, string insurance, decimal dailyPrice) : base(id, clientID, sellerID, dateTime, vehicle, paymentMethod, totalSum)
        {
            this.Period = period;
            this.Insurance = insurance;
            this.DailyPrice = dailyPrice;
        }

        public int Period { get; set; }

        public string Insurance { get; set; }

        public decimal DailyPrice { get; set; }

        public static void Add()
        {
            int id = 0;
            int clientID = 0;
            int sellerID = 0;
            DateTime date = new DateTime();
            string vehicle = string.Empty;
            PaymentMethods paymentMethod = new PaymentMethods();
            decimal totalSum = 0;
            int period = 0;
            string insurance = string.Empty;
            decimal dailyPrice = 0;

            id = ConsoleInput.GetData<int>("Please input rent ID: ");
            clientID = ConsoleInput.GetData<int>("Please input client ID: ");
            sellerID = ConsoleInput.GetData<int>("Please input seller ID: ");
            date = ConsoleInput.GetDateTime("Please input date :");
            vehicle = ConsoleInput.GetData<string>("Please input a vehicle: ");
            paymentMethod = ConsoleInput.GetEnum<PaymentMethods>("Please input payment method: ");
            totalSum = ConsoleInput.GetData<decimal>("Please input total sum: ");
            period = ConsoleInput.GetData<int>("Please input period: ");
            insurance = ConsoleInput.GetData<string>("Please input insurance: ");
            dailyPrice = ConsoleInput.GetData<decimal>("Please input dayly price: ");

            Rent rent = new Rent(id, clientID, sellerID, date, vehicle, paymentMethod, totalSum, period, insurance, dailyPrice);

            Database.Load();
            Database.rents.Add(rent);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Rent \n====================== \nID:{0}\nClientID:{1}\nSellerID:{2}\nDate and time:{3}\nVehicle:{4}\nPayment method:{5}\nTotal sum:{6}\nPeriod of rent:{7}\nInsurance:{8}\nPrice per day:{9}\n======================", this.ID, this.ClientID, this.SellerID, this.DateTime, this.Vehicle, this.PaymentMethod, this.TotalSum, this.Period, this.Insurance, this.DailyPrice);
        }

        public override string ToString()
        {
            return string.Format("Rent ---> ID: {0}  Client: {1}  Seller: {2}  Vehicle: {3}  Period: {4}", this.ID, this.ClientID, this.SellerID, this.Vehicle, this.Period);
        }
    }
}