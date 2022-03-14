using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ViewModels;

namespace DataServices
{

    public enum AUTHSTATUS { NONE, OK, INVALID, FAILED }
    public class HttpClientService : IHttpClientService, IDisposable
    {
        private readonly HttpClient _httpClient;
       
        public HttpClientService(HttpClient httpClient
            )
        {
            _httpClient = httpClient;
            
        }

        public Token Token_held { get ; private set; }
        public string UserToken { get ; set; }
        public AUTHSTATUS UserStatus { get ; set; }

        public void Dispose()
        {
            
        }

        public async Task<List<T>> getCollection<T>(string EndPoint)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
           _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // New Blazor Get
            try
            {
                JsonSerializerOptions options = new()
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                var response = await _httpClient.GetFromJsonAsync<List<T>>(EndPoint,options);
                return response;
            }

            catch(Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
                return new List<T>();
            }
        }

        public async Task<T>  getSingle<T>(string Endpoint, int id)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // New Blazor Get
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            var pureRepsonse = await _httpClient.GetStringAsync(Endpoint + id.ToString());
            Console.WriteLine(pureRepsonse);

            var response = await _httpClient.GetFromJsonAsync<T>(Endpoint +id.ToString(),options );
            return response;
        }

        public async Task<bool> login(string username, string password)
        {
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new LoginViewModel { Username = username, Password = password, RememberMe = true };
            var result = await _httpClient.PostAsJsonAsync("Token", content);
            try
            {
                var resultContent = result.Content.ReadAsAsync<Token>(
                        new[] { new JsonMediaTypeFormatter() }
                        ).Result;
                string ServerError = string.Empty;
                if (!(String.IsNullOrEmpty(resultContent.AccessToken)))
                {
                    Console.WriteLine(resultContent.AccessToken);
                    UserToken = resultContent.AccessToken;
                    UserStatus = AUTHSTATUS.OK;
                    return true;
                }
                else
                {
                    UserToken = "Invalid Login";
                    UserStatus = AUTHSTATUS.INVALID;
                    Console.WriteLine("Invalid credentials");
                    return false;
                }
            }
            catch (Exception ex)
            {
                UserStatus = AUTHSTATUS.FAILED;
                UserToken = "Server Error -> " + ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async void Post<T>(string EndPoint, T p)
        {
            
       
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            await _httpClient.PostAsJsonAsync(EndPoint, p,options:options);

        }

        public async void Put<T>(string EndPoint, T p)
        {
            
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            await _httpClient.PutAsJsonAsync(EndPoint, p,options:options);
        }
    }
}
