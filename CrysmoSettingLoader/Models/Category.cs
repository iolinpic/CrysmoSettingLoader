using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.Models
{
    class Category:Model
    {
        private string title;
        private string subdir;
        private string remotePath;

        public string Title {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Subdir {
            get { return subdir; }
            set
            {
                subdir = value;
                OnPropertyChanged(nameof(Subdir));
            }
        }
        public string RemotePath {
            get { return remotePath; }
            set
            {
                remotePath = value;
                OnPropertyChanged(nameof(RemotePath));
            }
        }
    }
}
