using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Seller : Person
    {
        public Seller(int id, PersonalDetails personalDetails, DateTime startDate, decimal rate) : base(id, personalDetails, startDate)
        {
            this.Rate = rate;
        }

        public decimal Rate { get; set; }

        public static void Add()
        {
            int personalDetailsID = 0;
            int personalDetailsDocID = 0;
            string personalDetailsName = string.Empty;

            int id = 0;
            DateTime date = new DateTime();
            ClientType type = new ClientType();
            decimal rate = 0;

            id = ConsoleInput.GetData<int>("Please input seller ID: ");
            personalDetailsID = ConsoleInput.GetData<int>("Please input personal details ID: ");
            personalDetailsDocID = ConsoleInput.GetData<int>("Please input personal details Document ID: ");
            personalDetailsName = ConsoleInput.GetData<string>("Please input personal details Name: ");
            date = ConsoleInput.GetDateTime("Please input date :");
            rate = ConsoleInput.GetData<decimal>("Please input seller rate: ");

            PersonalDetails personalDetails = new PersonalDetails(personalDetailsID, personalDetailsDocID, personalDetailsName);
            Seller seller = new Seller(id, personalDetails, date, rate);

            Database.Load();
            Database.sellers.Add(seller);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Seller \n====================== \nid:{0}\nPersonalDetails:{1}\nStartTime:{2}\nRate:{3}\n======================", this.ID, this.PersonalDetails, this.StartDate, this.Rate);
        }

        public override string ToString()
        {
            return string.Format("Seller ---> ID: {0}  Name: {1}  Rate: {2}", this.ID, this.PersonalDetails.Name, this.Rate);
        }
    }
}