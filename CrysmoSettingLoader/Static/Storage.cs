using CrysmoSettingLoader.Models;
using CrysmoSettingLoader.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.Static
{
    /// <summary>
    /// Class wich held state of application, used as singleton
    /// </summary>
    class Storage : INotifyPropertyChanged
    {
        private static Storage instance;
        public static Storage getInstance()
        {
            if (instance == null)
                instance = new Storage();
            return instance;
        }
        private LocalSettings localSettings;

        public Storage()
        {
            getLocalSettings();
            State = new AppState();
        }

        public AppState State
        {
            get; set;
        }

        public LocalSettings LocalSettings
        {
            get { return localSettings; }
            set
            {
                localSettings = value;
                OnPropertyChanged(nameof(LocalSettings));
            }
        }

        private void getLocalSettings()
        {
            AppSettingsService appSettingsService = new AppSettingsService();
            Task<LocalSettings> task = Task.Run(() => appSettingsService.readSettings());
            LocalSettings = task.Result;
            if(LocalSettings.Categories.Count == 0)
            {
                LocalSettings.initCategoryValues();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
}
}
