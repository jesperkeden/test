using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeGame.Navigation
{
    public class MenuItem
    {
        public string Title { get; }
        public List<MenuItem> SubItems { get; }
        public Action Action { get; }

        public MenuItem(string title, Action action = null)
        {
            Title = title;
            SubItems = new List<MenuItem>();
            Action = action;
        }

        public void AddSubItem (MenuItem item)
        {
            SubItems.Add(item);
        }
    }
}
