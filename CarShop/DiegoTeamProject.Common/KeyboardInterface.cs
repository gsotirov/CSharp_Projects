using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class KeyboardInterface : IUserInterface
    {
        public event EventHandler UpPress;

        public event EventHandler DownPress;

        public event EventHandler SelectPress;

        public void TakeInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.UpPress != null)
                    {
                        this.UpPress(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.DownPress != null)
                    {
                        this.DownPress(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Enter))
                {
                    if (this.SelectPress != null)
                    {
                        this.SelectPress(this, new EventArgs());
                    }
                }
            }
        }
    }
}