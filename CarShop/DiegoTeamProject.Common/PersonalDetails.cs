using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public struct PersonalDetails
    {
        public PersonalDetails(int personalID, int documentID, string name) : this()
        {
            this.PersonalID = personalID;
            this.DocumentID = documentID;
            this.Name = name;
        }

        public int DocumentID { get; set; }

        public string Name { get; set; }

        public int PersonalID { get; set; }
    }
}