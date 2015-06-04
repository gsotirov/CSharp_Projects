using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiegoTeamProject.Common
{
    public abstract class Person : IPerson
    {
        public Person(int id, PersonalDetails personalDetails, DateTime startDate)
        {
            this.ID = id;
            this.PersonalDetails = personalDetails;
            this.StartDate = startDate;
        }

        public int ID { get; set; }

        public PersonalDetails PersonalDetails { get; set; }

        public DateTime StartDate { get; set; }

        public string History(List<Deal> deals) //Method History
        {
            StringBuilder sb = new StringBuilder();
            bool isClient = this.GetType() == typeof(Client);

            // Retreive all persons with the passed personal ID 
            foreach (Deal deal in deals)
            {
                if (deals == null || deals.Count == 0)
                {
                    throw new ArgumentNullException("The database is empty");
                }
                else
                {
                    if (deal.ClientID != null && deal.SellerID != null)
                    {
                        if (deal.ClientID == this.PersonalDetails.PersonalID ||
                            deal.SellerID == this.PersonalDetails.PersonalID)
                        {
                            Client client = Database.clients.Find(cl => cl.ID == deal.ClientID);
                            Client seller = Database.clients.Find(sl => sl.ID == deal.SellerID);
                            sb.AppendLine("--------- Deal Details ----------");
                            sb.AppendLine(string.Format("ID: {0}", deal.ID));
                            sb.AppendLine(string.Format("Client: {0}", client.PersonalDetails.Name));
                            sb.AppendLine(string.Format("Seller: {0}", seller.PersonalDetails.Name));
                            sb.AppendLine(string.Format("Deal date: {0}", deal.DateTime.ToShortDateString()));
                            sb.AppendLine(string.Format("Vehicle: {0}", deal.Vehicle));
                            sb.AppendLine(string.Format("PaymentMethod: {0}", deal.PaymentMethod.ToString()));
                            sb.AppendLine(string.Format("TotalSum: {0}", deal.TotalSum.ToString()));
                        }
                    }
                    else
                    {
                        throw new ArgumentException("The client or seller is not specified for the deal!");
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this.ID, this.PersonalDetails, this.StartDate);
        }
    }
}