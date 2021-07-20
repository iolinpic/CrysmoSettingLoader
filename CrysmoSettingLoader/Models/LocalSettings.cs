//using DFshareWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using CrysmoSettingLoader.Services;
using System.IO;
using CrysmoSettingLoader.Static;

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

        [JsonProperty("Categories")]
        public List<Category> Categories { get; set; }
        
        
        /*public List<Category> Categories{
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }*/

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
            Categories = new List<Category>();
            
        }

        public void initCategoryValues() {
            Categories.Add(new Category { Title = "Состояния", RemotePath = "/api/conditions/generate", Subdir = "Conditions" });
            Categories.Add(new Category { Title = "Способности", RemotePath = "/api/abilities/generate", Subdir = "Abilities" });
            Categories.Add(new Category { Title = "NPC", RemotePath = "/api/actor/generate", Subdir = "NPC" });
            Categories.Add(new Category { Title = "Диалоги", RemotePath = "/api/dialog/generate", Subdir = "Dialogs" });
            Categories.Add(new Category { Title = "Карты", RemotePath = "/api/zone/generate", Subdir = "Map" });
            Categories.Add(new Category { Title = "Комплекты способностей", RemotePath = "/api/pack/generate", Subdir = "AbilityPacks" });
            Categories.Add(new Category { Title = "Сундуки", RemotePath = "/api/spack/generate", Subdir = "LootPacks" });
            Categories.Add(new Category { Title = "Кризмы", RemotePath = "/api/crysm/generate", Subdir = "Crysms" });
            Categories.Add(new Category { Title = "Предметы", RemotePath = "/api/item/generate", Subdir = "Items" });
            Categories.Add(new Category { Title = "Квесты", RemotePath = "/api/quest/generate", Subdir = "Quests" });
            saveChanges();

        }
    }
}
