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
        private bool isActivated;
        private int progress;

        public Category()
        {
            isActivated = false;
            progress = 0;
        }

        public bool IsActivated
        {
            get { return isActivated; }
            set
            {
                isActivated = value;
                if (isActivated)
                {
                    Progress = 0;
                }
                OnPropertyChanged(nameof(isActivated));
                OnPropertyChanged(nameof(IsActivatable));
            }
        }
        public bool IsActivatable
        {
            get { return !isActivated; }
        }

        public int Progress {
            get { return progress; }
            set
            {
                progress = value;
                if (value < 0)
                {
                    progress = 0;
                }
                if( value > 100)
                {
                    progress = 100;
                }
                OnPropertyChanged(nameof(Progress));

            }
        }

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
