using System.Text.Json.Serialization;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class CurrentUserModel : Model
    {
        private string id;
        private string name;
        private string email;
        /* public PermissionModel[] permissions { get; set; }*/

        public CurrentUserModel()
        {
            name = "";
            email = "";
            id = "";
            /*permissions = new PermissionModel[0];*/
        }

        public void UpdateUser(CurrentUserModel user)
        {
            Name = user.Name;
            Email = user.Email;
            Id = user.Id;
            /*permissions = user.permissions;*/
        }

        [JsonPropertyName("_id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [JsonPropertyName("email")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
    }
}