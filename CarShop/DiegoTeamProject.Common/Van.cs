using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Van : Vehicle
    {
        public Van(int capacity, VanType vanType)//:(base)
        {
            this.Capacity = capacity;
            this.Vantype = vanType;
        }

        public VanType Vantype { get; set; }

        public int Capacity { get; set; }
    }
}