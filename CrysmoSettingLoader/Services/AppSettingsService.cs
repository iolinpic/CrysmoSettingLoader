using CrysmoSettingLoader.Models;

//using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.Services
{
    /// <summary>
    /// Singleton class used for storing and reading local file settings
    /// </summary>
    public class AppSettingsService
    {
        private const string FILENAME = @"settings.json";

        public AppSettingsService()
        {
            SettingsFileExistsOrCreate();
        }

        private void SettingsFileExistsOrCreate()
        {
            FileInfo fileInfo = new FileInfo(FILENAME);
            if (!fileInfo.Exists)
            {
                var filestream = fileInfo.Create();
                filestream.Close();
            }
        }

        public async Task<LocalSettings> readSettings()
        {
            using (FileStream sr = new FileStream(FILENAME, FileMode.OpenOrCreate))
            {
                /*var json = await sr.ReadToEndAsync();
                sr.Close();*/
                //LocalSettings settings = null;
                try
                {
                    //settings = JsonConvert.DeserializeObject<LocalSettings>(json);
                    LocalSettings settings = await JsonSerializer.DeserializeAsync<LocalSettings>(sr);
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
            using (FileStream sw = new FileStream(FILENAME, FileMode.OpenOrCreate))
            {
                /*var json = JsonConvert.SerializeObject(localSettings);
                await sw.WriteLineAsync(json);*/
                //sw.Close();
                await JsonSerializer.SerializeAsync<LocalSettings>(sw, localSettings);
                /*JsonSerializer.Serialize(sw, localSettings,LocalSettings);*/
            }
        }
    }
}