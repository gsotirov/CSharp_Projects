using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class DiegoSystemExceptions : System.Exception
    {
        public DiegoSystemExceptions() : base()
        {
            throw new DiegoSystemExceptions("Something bad happened");
        }

        public DiegoSystemExceptions(string message) : base(message)
        {
        }
    }
}