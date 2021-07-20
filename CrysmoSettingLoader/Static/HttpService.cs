using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Printing;
using System.Net.WebSockets;
using System.Threading;
using CrysmoSettingLoader.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CrysmoSettingLoader.Static
{
    /// <summary>
    /// Data getter and serializer class, integrated with some routing functional, works as singleton mostly async
    /// </summary>
    public class HttpService
    {
        private static readonly HttpClient HttpClient;
        private const string AUTH = @"/api/auth/login";
        private const string CURRENTUSER = @"/api/auth/user";
        public static string serverPath;
        //private static HttpSettings settings;
        //private static AuthResponseModel authData;

        static HttpService() {
            HttpClient = new HttpClient();
            serverPath = "https://crysmo.neksys.ru";
        }

        private static string pathGenerator(string path)
        {
            return serverPath + path;
        }
        public static void UpdateBase(string server)
        {
            serverPath = server;
        }

        public static async Task<AuthResponseModel> login(LoginModel model)
        {
            try {
                var resp = await HttpClient.PostAsJsonAsync<LoginModel>(pathGenerator(AUTH), model);
                resp.EnsureSuccessStatusCode();
                var authData = await resp.Content.ReadFromJsonAsync<AuthResponseModel>();
                if (authData != null)
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authData.token);
                    return authData;
                }
                else
                {
                    return authData;
                }
            }
            catch
            {
                return default;
            }
        }
         public async static Task<CurrentUserModel> getCurrentUser() {
            try
            {
                return await HttpClient.GetFromJsonAsync<CurrentUserModel>(pathGenerator(CURRENTUSER));
            }
            catch 
            {
                return default;
            }
        }

        public static async Task DownloadAsync(string url, HttpContent content, string filename)
        {
            try {
              //  var uri = new Uri(generatePdfsRetrieveUrl + pdfGuid + ".pdf");
                var response = (await HttpClient.PostAsync(pathGenerator(url),content)).EnsureSuccessStatusCode();
                //var content = await response.Content.ReadAsStringAsync();
                if (File.Exists(filename)) {
                    File.Delete(filename);
                }
                using (var fs = new FileStream(
                    filename,
                    FileMode.OpenOrCreate))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Switcher.addNotification(ex.Message);
            }
        }
    }    
}
