//using Newtonsoft.Json;
using CrysmoSettingLoader.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        static HttpService()
        {
            var handler = new HttpClientHandler();
            handler.MaxConnectionsPerServer = int.MaxValue;
            HttpClient = new HttpClient(handler);
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

        public static void setToken(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<AuthResponseModel> login(LoginModel model)
        {
            try
            {
                var resp = await HttpClient.PostAsJsonAsync(pathGenerator(AUTH), model);
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

        public static async Task<CurrentUserModel> getCurrentUser()
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<CurrentUserModel>(pathGenerator(CURRENTUSER));
            }
            catch
            {
                return default;
            }
        }

        public static async Task<string> DownloadAsync(string url, string filename)
        {
            try
            {
                var response = (await HttpClient.GetAsync(pathGenerator(url))).EnsureSuccessStatusCode();
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                using (var fs = new FileStream(
                    filename,
                    FileMode.OpenOrCreate))
                {
                    await response.Content.CopyToAsync(fs);
                }
                return filename;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}