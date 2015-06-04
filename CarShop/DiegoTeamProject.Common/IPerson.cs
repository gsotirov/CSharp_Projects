using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public interface IPerson //Type Person with method Hystory. All objects from this type inherit the method
    {
        string History(List<Deal> deals);
    }
}