using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLoaderAva.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        public string LoginName { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginName = "";
            Password = "";
        }
    }
}