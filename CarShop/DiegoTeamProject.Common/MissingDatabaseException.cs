using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class MissingDatabaseException : System.IO.IOException
    {
        public MissingDatabaseException() : base("Database files not found")
        {
            throw new MissingDatabaseException("Database files not found");
        }

        public MissingDatabaseException(string message) : base(message)
        {
        }
    }
}