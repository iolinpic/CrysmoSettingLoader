//using DFshareWPF.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class AppState : Model
    {
        private bool _auth;       
        private CurrentUserModel _user;
        public CurrentUserModel User { 
            get { return _user; } 
            set {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public AppState()
        {
            _user = new CurrentUserModel();
            Auth = false;
        }

        public void resetDefault() {
            User = new CurrentUserModel();
            Auth = false;
        }

        public bool Auth
        {
            get { return _auth; }
            set
            {
                _auth = value;
                OnPropertyChanged("Auth");
            }
        }
    }
}
