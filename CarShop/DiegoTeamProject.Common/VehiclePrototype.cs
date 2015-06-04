using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class VehiclePrototype<T> : ICloneable
    {
        public VehiclePrototype(T vehicle)
        {
            this.vehicle = vehicle;
        }

        public T vehicle { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}