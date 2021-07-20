using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using DFshareWPF.Interface;
using System.Windows.Controls;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class MainMenuItem : Model
    {
        private string title;
        private string address;
        private string permission;
        private int order;

        public MainMenuItem()
        {
            order = 0;
        }

        public int Order
        {
            get { return order; }
            set { 
                order = value;
                OnPropertyChanged("Order");
            }
        }

        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Address {
            get { return address; }
            set {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Permission {
            get { return permission; }
            set { permission = value;
                OnPropertyChanged("Permission");
            }
        }
          
    }
}
