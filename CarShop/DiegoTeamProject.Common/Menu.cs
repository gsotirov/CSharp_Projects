using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public class Menu
    {
        public Menu(List<MenuItem> menuItems)
        {
            this.MenuItems = menuItems.OrderBy(item => item.Position).ToArray();
        }

        public MenuItem[] MenuItems { get; private set; }

        public static Menu Create(List<Vehicle> list)
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            int id = 0;
            bool state = true;
            foreach (var item in list)
            {
                if (id != 0)
                {
                    state = false;
                }
                listMenu.Add(new MenuItem(id, item.ToString(), id, "Vehicle", state));
                id++;
            }

            listMenu.Add(new MenuItem(id, "Return To Main Menu", id, "Main", state));
            Menu outputMenu = new Menu(listMenu);
            return outputMenu;
        }

        public static Menu Create(List<Person> list)
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            int id = 0;
            bool state = true;
            foreach (var item in list)
            {
                if (id != 0)
                {
                    state = false;
                }
                listMenu.Add(new MenuItem(id, item.ToString(), id, "Person", state));
                id++;
            }

            listMenu.Add(new MenuItem(id, "Return To Main Menu", id, "Main", state));
            Menu outputMenu = new Menu(listMenu);
            return outputMenu;
        }

        public static Menu Create(List<Deal> list)
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            int id = 0;
            bool state = true;
            foreach (var item in list)
            {
                if (id != 0)
                {
                    state = false;
                }
                listMenu.Add(new MenuItem(id, item.ToString(), id, "Deal", state));
                id++;
            }

            listMenu.Add(new MenuItem(id, "Return To Main Menu", id, "Main", state));
            Menu outputMenu = new Menu(listMenu);
            return outputMenu;
        }

        public static Menu Create(List<Seller> list)
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            int id = 0;
            bool state = true;
            foreach (var item in list)
            {
                if (id != 0)
                {
                    state = false;
                }
                listMenu.Add(new MenuItem(id, item.ToString(), id, "Seller", state));
                id++;
            }

            listMenu.Add(new MenuItem(id, "Return To Main Menu", id, "Main", state));
            Menu outputMenu = new Menu(listMenu);
            return outputMenu;
        }

        public static Menu Create(List<Client> list)
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            int id = 0;
            bool state = true;
            foreach (var item in list)
            {
                if (id != 0)
                {
                    state = false;
                }
                listMenu.Add(new MenuItem(id, item.ToString(), id, "Client", state));
                id++;
            }

            listMenu.Add(new MenuItem(id, "Return To Main Menu", id, "Main", state));
            Menu outputMenu = new Menu(listMenu);
            return outputMenu;
        }

        public void MoveUp()
        {
            for (int i = 0; i < this.MenuItems.Length; i++)
            {
                if (this.MenuItems[i].IsSelected && i != 0)
                {
                    this.MenuItems[i].IsSelected = false;
                    this.MenuItems[i - 1].IsSelected = true;
                }
            }
        }

        public void MoveDown()
        {
            for (int i = 0; i < this.MenuItems.Length; i++)
            {
                if (this.MenuItems[i].IsSelected && i < this.MenuItems.Length - 1)
                {
                    this.MenuItems[i].IsSelected = false;
                    this.MenuItems[i + 1].IsSelected = true;
                    return;
                }
            }
        }

        public string Action()
        {
            for (int i = 0; i < this.MenuItems.Length; i++)
            {
                if (this.MenuItems[i].IsSelected)
                {
                    return this.MenuItems[i].ActionName;
                }
            }

            return string.Empty;
        }
    }
}