
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class CurrentUserModel : Model
    {
        private int id;
        private string name;
        private string email;
       /* public PermissionModel[] permissions { get; set; }*/

        public CurrentUserModel()
        {
            name = "";
            email = "";
            id = 0;
            /*permissions = new PermissionModel[0];*/
        }
        public void UpdateUser(CurrentUserModel user) {
            Name = user.Name;
            Email = user.Email;
            Id = user.Id;
            /*permissions = user.permissions;*/
        }

        [JsonProperty("_id")]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        [JsonProperty("email")]
        public string Email {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged("Email");
            } }

        
    }
}
