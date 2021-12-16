 using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
//using DFshareWPF.Interface;

namespace CrysmoSettingLoader.Models 
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class LoginModel 
    {
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
    }
}
