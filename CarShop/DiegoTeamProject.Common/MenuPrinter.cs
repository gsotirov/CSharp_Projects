using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class MenuPrinter
    {
        private readonly ConsoleColor backgroundSelected;

        private readonly ConsoleColor foregroundSelected;

        public MenuPrinter(ConsoleColor backgroundColor = ConsoleColor.Blue, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            this.backgroundSelected = backgroundColor;
            this.foregroundSelected = foregroundColor;
        }

        public void Print(Menu menu)
        {
            int row = 3;
            string logo = " DIEGO VEHICLES ™";
            string allRights = "All rights reserved 2013 ©®";
            Console.SetCursorPosition(45 - (logo.Length / 2), 1);
            Console.WriteLine(logo);
            foreach (var menuItem in menu.MenuItems)
            {
                this.DefaultColor();
                Console.SetCursorPosition(5, row);
                Console.WriteLine(new string(' ', 80));
                if (menuItem.IsSelected)
                {
                    Console.BackgroundColor = this.backgroundSelected;
                    Console.ForegroundColor = this.foregroundSelected;
                }
                Console.SetCursorPosition(45 - (menuItem.ToString().Length / 2), row);
                Console.WriteLine(menuItem);
                row++;
                this.DefaultColor();
            }

            Console.SetCursorPosition(45 - (allRights.Length / 2), ++row);
            Console.WriteLine(allRights);
        }

        private void DefaultColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}