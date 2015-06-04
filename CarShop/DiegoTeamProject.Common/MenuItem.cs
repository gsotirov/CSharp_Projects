using System;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public struct MenuItem
    {
        private readonly int id;

        private readonly string title;

        public MenuItem(int id, string title, int position, string actionName, bool isSelected = false) : this()
        {
            this.id = id;
            this.title = title;
            this.Position = position;
            this.IsSelected = isSelected;
            this.ActionName = actionName;
        }

        public int Position { get; private set; }

        public bool IsSelected { get; set; }

        public string ActionName { get; set; }

        public override string ToString()
        {
            string stringItem = String.Format("{0,-19}", String.Format("{0," + ((19 + this.title.Length) / 2).ToString() + "}", this.title));
            return stringItem;
        }
    }
}