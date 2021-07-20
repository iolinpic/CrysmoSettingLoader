//using DFshareWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using CrysmoSettingLoader.Services;
using System.IO;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Data structure used for interpret api loaded data, with some additional utilize methods
    /// </summary>
    public class LocalSettings : Model
    {
        private string _server;
        private bool saved;
        private string token;
        private string resultDir;

        [JsonProperty("Server")]
        public string Server
        {
            get { return _server; }
            set
            {
                _server = value;
                OnPropertyChanged(nameof(Server));
                saveChanges();
            }
        }

        [JsonProperty("ResultDir")]
        public string ResultDir
        {
            get { return resultDir; }
            set
            {
                resultDir = value;
                OnPropertyChanged(nameof(ResultDir));
                saveChanges();
            }
        }

        [JsonProperty("Token")]
        public string Token
        {
            get { return token; }
            set
            {
                token = value;
                OnPropertyChanged(nameof(Token));
                saveChanges();
            }
        }
        [JsonProperty("Saved")]
        public bool Saved
        {
            get { return saved; }
            set
            {
                saved = value;
                OnPropertyChanged(nameof(Saved));
                saveChanges();
            }
        }

        private const string BASE = @"https://crysmo.neksys.ru";

       /* public void Update(LocalSettings localSettings)
        {
            Printer = localSettings.Printer;
            Server = localSettings.Server;
        }*/

        private void saveChanges() {
            Task.Run(() => AppSettingsService.writeSettings(this));
        }

        public LocalSettings()
        {
            _server = BASE;
            saved = false;
            token = "";
            resultDir = Directory.GetCurrentDirectory();
        }
    }
}
