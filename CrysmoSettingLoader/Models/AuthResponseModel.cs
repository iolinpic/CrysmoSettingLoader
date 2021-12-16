namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class AuthResponseModel
    {
        public string token { get; set; }
        public CurrentUserModel user { get; set; }
    }
}