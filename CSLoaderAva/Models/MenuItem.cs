using CSLoaderAva.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLoaderAva.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string ClassName { get; set; }

        public MenuItem()
        {
            Name = "MenuItem";
            Order = 0;
            ClassName = "";
        }
    }
}