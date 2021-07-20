 using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
//using DFshareWPF.Interface;

namespace CrysmoSettingLoader.Models 
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class LoginModel 
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
