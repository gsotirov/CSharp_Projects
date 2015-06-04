using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Client : Person
    {
        public Client(int id, PersonalDetails personalDetails, DateTime startDate, ClientType clientType) : base(id, personalDetails, startDate)
        {
            this.Type = clientType;
        }

        public ClientType Type { get; set; }

        public static void Add()
        {
            int personalDetailsID = 0;
            int personalDetailsDocID = 0;
            string personalDetailsName = string.Empty;

            int id = 0;
            DateTime date = new DateTime();
            ClientType type = new ClientType();

            id = ConsoleInput.GetData<int>("Please input client ID: ");
            personalDetailsID = ConsoleInput.GetData<int>("Please input personal details ID: ");
            personalDetailsDocID = ConsoleInput.GetData<int>("Please input personal details Document ID: ");
            personalDetailsName = ConsoleInput.GetData<string>("Please input personal details Name: ");
            date = ConsoleInput.GetDateTime("Please input date :");
            type = ConsoleInput.GetEnum<ClientType>("Please input client type: ");

            PersonalDetails personalDetails = new PersonalDetails(personalDetailsID, personalDetailsDocID, personalDetailsName);
            Client client = new Client(id, personalDetails, date, type);

            Database.Load();
            Database.clients.Add(client);
            Database.Save();
            Console.Clear();
        }

        public string ExtendedToString()
        {
            return string.Format("Client \n====================== \nId:{0}\nPersonalDetails:{1}\nClientType:{2}\n======================", this.ID, this.PersonalDetails, this.Type);
        }

        public override string ToString()
        {
            return string.Format("Client ---> ID: {0}  Name: {1}  Type: {2}", this.ID, this.PersonalDetails.Name, this.Type);
        }
    }
}