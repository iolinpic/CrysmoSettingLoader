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
  /*      private Field[] eventFields;
        private Field[] participantFields;
        private Zone[] zones;*/

        public Storage()
        {
            getLocalSettings();
            State = new AppState();
        }

        public AppState State
        {
            get; set;
        }

       /* public Field[] EventFields {
            get { return eventFields; }
            set
            {
                eventFields = value;
                OnPropertyChanged(nameof(EventFields));
            }
        }
        public Field[] ParticipantFields {
            get { return participantFields; }
            set {
                participantFields = value;
                OnPropertyChanged(nameof(ParticipantFields));
            }
        }
        public Zone[] Zones { 
            get { return zones; }
            set
            {
                zones = value;
                OnPropertyChanged(nameof(Zones));
            }
        }*/
        public LocalSettings LocalSettings
        {
            get { return localSettings; }
            set
            {
                localSettings = value;
                OnPropertyChanged(nameof(LocalSettings));
                //Task.Run(() => AppSettingsService.writeSettings(value));
            }
        }

        private void getLocalSettings()
        {
            AppSettingsService appSettingsService = new AppSettingsService();
            Task<LocalSettings> task = Task.Run(() => appSettingsService.readSettings());
            LocalSettings = task.Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
}
}
