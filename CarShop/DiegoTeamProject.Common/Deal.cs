using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public abstract class Deal
    {
        //constructors
        public Deal(int id, int clientID, int sellerID, DateTime dateTime, string vehicle, PaymentMethods paymentMethod, decimal totalSum)
        {
            this.ID = id;
            this.ClientID = clientID;
            this.SellerID = sellerID;
            this.DateTime = dateTime;
            this.Vehicle = vehicle;
            this.PaymentMethod = paymentMethod;
            this.TotalSum = totalSum;
        }

        public int ID { get; set; }

        public int ClientID { get; set; }

        public int SellerID { get; set; }

        public DateTime DateTime { get; set; }

        public string Vehicle { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public decimal TotalSum { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.ID, this.ClientID, this.SellerID, this.Vehicle);
        }
    }
}