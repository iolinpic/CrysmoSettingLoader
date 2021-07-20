using CrysmoSettingLoader.Commands;
using CrysmoSettingLoader.Models;
using CrysmoSettingLoader.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace CrysmoSettingLoader.ViewModels
{
    class DashboardViewModel : ViewModel
    {
        
        private RelayCommand downloadCommand;
        private RelayCommand downloadAllCommand;
        public ObservableCollection<Category> Categories { get; set; }
        
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
        public RelayCommand DownloadAllCommand
        {
            get
            {
                return downloadAllCommand ??= new RelayCommand((obj) => {
                    foreach(var category in Categories)
                    {
                        DownloadCommand.Execute(category);
                    }
                });
            }
        }

        public RelayCommand DownloadCommand
        {
            get
            {
                return downloadCommand ??= new RelayCommand(async (obj) =>
                {
                    var category = obj as Category;
                    if (category != null)
                    {
                        category.IsActivated = true;
                        var archieveName = category.Subdir + ".zip";
                        archieveName =  await HttpService.DownloadAsync(category.RemotePath, archieveName);
                        category.Progress = 50;
                        //Switcher.addNotification("Архив конфигов " + category.Title + " скачан.");
                        /*if (Directory.Exists(category.Subdir))
                        {
                            try
                            {
                                Directory.Delete(category.Subdir, true);
                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }*/
                        




                        var targetDir = ResultDir + @"\" + category.Subdir;
                        DirectoryInfo dirInfo = new DirectoryInfo(category.Subdir);
                        if (Directory.Exists(targetDir)) {
                            try
                            {
                                Directory.Delete(targetDir, true);
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        try
                        {
                            ZipFile.ExtractToDirectory(archieveName, targetDir);
                            //Switcher.addNotification("Архив конфигов " + category.Title + " разорхивирован.");
                            var file = new FileInfo(archieveName);
                            if (file.Exists)
                            {
                                file.Delete();
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        /*                        if (dirInfo.Exists && Directory.Exists(targetDir) == false)
                                                {
                                                    try
                                                    {
                                                        dirInfo.MoveTo(ResultDir);
                                                        //Switcher.addNotification("Архив конфигов " + category.Title + " перемещен в папку назначения.");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }

                                                }*/

                        category.Progress = 100;
                        category.IsActivated = false;
                    }

                });
            }
        }

        public DashboardViewModel()
        {
            Categories = new ObservableCollection<Category>();
            Categories.Add(new Category {Title="Состояния",RemotePath= "/api/conditions/generate", Subdir="conditions" });
            Categories.Add(new Category {Title="Способности",RemotePath= "/api/abilities/generate", Subdir= "abilities" });
            Categories.Add(new Category {Title="NPC",RemotePath= "/api/actor/generate", Subdir= "actors" });
            Categories.Add(new Category {Title="Диалоги",RemotePath= "/api/dialog/generate", Subdir= "dialogs" });
            Categories.Add(new Category {Title="Карты",RemotePath= "/api/zone/generate", Subdir= "zones" });
            Categories.Add(new Category {Title="Комплекты способностей",RemotePath= "/api/pack/generate", Subdir= "abilityPacks" });
            Categories.Add(new Category {Title="Сундуки",RemotePath= "/api/spack/generate", Subdir= "storagePacks" });
            Categories.Add(new Category {Title="Кризмы",RemotePath= "/api/crysm/generate", Subdir= "crysms" });
            Categories.Add(new Category {Title="Предметы",RemotePath= "/api/item/generate", Subdir= "items" });
        }
    }
}
