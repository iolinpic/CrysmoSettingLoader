//using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CrysmoSettingLoader.Models
{
    public class Category : Model
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

        [JsonIgnore]
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

        [JsonIgnore]
        public bool IsActivatable
        {
            get { return !isActivated; }
        }

        [JsonIgnore]
        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                if (value < 0)
                {
                    progress = 0;
                }
                if (value > 100)
                {
                    progress = 100;
                }
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Subdir
        {
            get { return subdir; }
            set
            {
                subdir = value;
                OnPropertyChanged(nameof(Subdir));
            }
        }

        public string RemotePath
        {
            get { return remotePath; }
            set
            {
                remotePath = value;
                OnPropertyChanged(nameof(RemotePath));
            }
        }
    }
}