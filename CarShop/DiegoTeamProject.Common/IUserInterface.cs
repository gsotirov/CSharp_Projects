using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public interface IUserInterface
    {
        event EventHandler UpPress;

        event EventHandler DownPress;

        event EventHandler SelectPress;

        void TakeInput();
    }
}