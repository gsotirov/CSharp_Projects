using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoTeamProject.Common
{
    class Test_Person_Client_Seller
    {
        static void Main(string[] args)
        {

            List<IPerson> persons = new List<IPerson>();
            Client client1 = new Client();
            client1.Type = ClientType.Silver;
            client1.StartDate = DateTime.Now.AddMonths(-9);
            client1.PersonalDetails = new PersonalDetails
            {
                Country = "Bulgaria",
                DateOfBirth = DateTime.Parse("10/10/1984"),
                DocumentID = 1,
                Name = "Detelina Tyurdieva",
                Nationality = "Bulgaria",
                PersonalID = 1
            };

            Client client2 = new Client();
            client2.Type = ClientType.Bronze;
            client2.StartDate = DateTime.Now.AddMonths(-2);
            client2.PersonalDetails = new PersonalDetails
            {
                Country = "Bulgaria",
                DateOfBirth = DateTime.Parse("13/04/1964"),
                DocumentID = 2,
                Name = "Elena Blagoeva",
                Nationality = "Bulgaria",
                PersonalID = 2
            };

            Client client3 = new Client();
            client3.Type = ClientType.Silver;
            client3.StartDate = DateTime.Now.AddMonths(-9);
            client3.PersonalDetails = new PersonalDetails
            {
                Country = "Bulgaria",
                DateOfBirth = DateTime.Parse("24/11/1990"),
                DocumentID = 3,
                Name = "Grigor Dimitrov",
                Nationality = "Bulgaria",
                PersonalID = 1
            };

            Seller seller1 = new Seller();
            seller1.Rate = 12;
            client1.StartDate = DateTime.Now.AddYears(-3);
            seller1.PersonalDetails = new PersonalDetails
            {
                Country = "Bulgaria",
                DateOfBirth = DateTime.Parse("08/12/1987"),
                DocumentID = 1,
                Name = "Todor Todorov",
                Nationality = "Bulgaria",
                PersonalID = 3
            };

            Seller seller2 = new Seller();
            seller2.Rate = 4;
            client1.StartDate = DateTime.Now.AddYears(-1);
            seller2.PersonalDetails = new PersonalDetails
            {
                Country = "Bulgaria",
                DateOfBirth = DateTime.Parse("18/06/1992"),
                DocumentID = 2,
                Name = "Milen Borisov",
                Nationality = "Bulgaria",
                PersonalID = 4
            };

            persons.Add(client1);
            persons.Add(client2);
            persons.Add(seller1);
            persons.Add(seller2);

            List<Deal> deals = new List<Deal>();
            Deal deal1 = new Deal();
            deal1.ID = 1;
            deal1.Client = client1;
            deal1.Seller = seller1;
            deal1.DateTime = DateTime.Now.AddDays(-10);
            deal1.Vehicle = "BMV";
            deal1.PaymentMethod = PaymentMethods.Cash;
            deal1.TotalSum = 15234;

            Deal deal2 = new Deal();
            deal2.ID = 2;
            deal2.Client = client2;
            deal2.Seller = seller2;
            deal2.DateTime = DateTime.Now.AddMonths(-3);
            deal2.Vehicle = "Mercedes";
            deal2.PaymentMethod = PaymentMethods.CreditCard;
            deal2.TotalSum = 12890;

            Deal deal3 = new Deal();
            deal3.ID = 3;
            deal3.Client = client1;
            deal3.Seller = seller2;
            deal3.DateTime = DateTime.Now.AddYears(-2);
            deal3.Vehicle = "Pejo";
            deal3.PaymentMethod = PaymentMethods.Check;
            deal3.TotalSum = 7890;

            Deal deal4 = new Deal();
            deal4.ID = 4;
            deal4.Client = client2;
            deal4.Seller = seller1;
            deal4.DateTime = DateTime.Now.AddYears(-5);
            deal4.Vehicle = "Reno";
            deal4.PaymentMethod = PaymentMethods.Check;
            deal4.TotalSum = 5650;

            deals.Add(deal1);
            deals.Add(deal2);
            deals.Add(deal3);
            deals.Add(deal4);

            try
            {
                Console.WriteLine(client1.History(deals));
                Console.WriteLine(client2.History(deals));
                Console.WriteLine(seller1.History(deals));
                Console.WriteLine(seller2.History(deals));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
