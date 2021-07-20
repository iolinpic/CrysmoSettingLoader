using CrysmoSettingLoader.Commands;
using CrysmoSettingLoader.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.ViewModels
{
    class DashboardViewModel : ViewModel
    {
        
        private RelayCommand downloadCommand;
        
        public string ResultDir
        {
            get { return Storage.getInstance().LocalSettings.ResultDir; }
            set
            {
                if (Directory.Exists(value)) {
                    Storage.getInstance().LocalSettings.ResultDir = value;
                    OnPropertyChanged(nameof(ResultDir));
                }
                else
                {
                    Switcher.addNotification("Директории не существует");
                }
            }
        }

        public RelayCommand DownloadCommand
        {
            get
            {
                return downloadCommand ??= new RelayCommand(async (obj) =>
                {
                    var pbox = obj as System.Windows.Controls.PasswordBox;

                });
            }
        }

        public DashboardViewModel()
        {

        }
    }
}
