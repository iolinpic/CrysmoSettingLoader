using CrysmoSettingLoader.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.Services
{
    /// <summary>
    /// Singleton class used for storing and reading local file settings
    /// </summary>
    public class AppSettingsService
    {
        private const string FILENAME = @"settings.json";

        public AppSettingsService() {
            SettingsFileExistsOrCreate();
        }

        private void SettingsFileExistsOrCreate() {
            FileInfo fileInfo = new FileInfo(FILENAME);
            if (!fileInfo.Exists)
            {
                var filestream = fileInfo.Create();
                filestream.Close();
            }
        }

        public async Task<LocalSettings> readSettings()
        {
            using (StreamReader sr = new StreamReader(FILENAME, System.Text.Encoding.UTF8))
            {
                var json = await sr.ReadToEndAsync();
                sr.Close();
                LocalSettings settings = null;
                try
                {
                    settings = JsonConvert.DeserializeObject<LocalSettings>(json);
                    if (settings == null)
                    {
                        settings = new LocalSettings();
                    }
                    return settings;
                }
                catch
                {
                    return new LocalSettings();
                }
            }
        }
        public static async Task writeSettings(LocalSettings localSettings)
        {
            using (StreamWriter sw = new StreamWriter(FILENAME, false, System.Text.Encoding.UTF8))
            {
                var json = JsonConvert.SerializeObject(localSettings);
                await sw.WriteLineAsync(json);
                sw.Close();
            }
        }
    }
}
