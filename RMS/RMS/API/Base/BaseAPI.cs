﻿using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API.Base
{
    public class BaseAPI<T>
    {

        #region Local
        private HttpClient _httpClient;

        public string End_Interno { get; set; }
        public string End_Externo { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        #endregion

        #region Construtor
        public BaseAPI(string _Controller, string _Empresa)
        {
            Controller = _Controller;

            End_Externo = vAmbiente + _Empresa + $"/{Controller}/";


            _httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(End_Externo),
                Timeout = TimeSpan.FromSeconds(1000)
            };

        }
        #endregion


        #region UrlHelper
        public async Task<string> UrlHelper(string action, string metodo = "GET", HttpContent _httpContent = null)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = metodo.Equals("GET") ? await _httpClient.GetAsync($"{_httpClient.BaseAddress}{action}").ConfigureAwait(false)
                                                    : await _httpClient.PostAsync($"{_httpClient.BaseAddress}{action}", _httpContent).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                    string contents;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        contents = reader.ReadToEnd();
                    }

                    if (!string.IsNullOrEmpty(contents) && !(contents == "null" || string.IsNullOrEmpty(contents.Replace("[", "").Replace("]", ""))))
                    {
                        return contents;
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion

        #region Get

        public async Task<T> Get(string action, HttpContent httpContent = null)
        {
            using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
            {
                _httpClient.BaseAddress = new Uri($"{End_Externo}");

                string contents = await UrlHelper(action, "GET", httpContent);

                return JsonConvert.DeserializeObject<T>(contents);
            }
        }

        public async Task<object> GetObject(string action, HttpContent httpContent = null)
        {
            using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
            {
                _httpClient.BaseAddress = new Uri($"{End_Externo}");

                string contents = await UrlHelper(action, "GET", httpContent);

                return JsonConvert.DeserializeObject<object>(contents);
            }
        }

        public async Task<ICollection<T>> GetList(string action, HttpContent httpContent = null)
        {
            try
            {
                using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    _httpClient.BaseAddress = new Uri(End_Externo);

                    string contents = await UrlHelper(action, "GET", httpContent);

                    return JsonConvert.DeserializeObject<ObservableCollection<T>>(contents);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Post
        public static HttpContent GetHttpContent(object obj)
        {
            HttpContent httpContent;
            var objSerialized = JsonConvert.SerializeObject(obj);

            httpContent = new StringContent(objSerialized, Encoding.UTF8, "application/json");
            return httpContent;
        }


        public async Task Post(string action, HttpContent httpContent = null)
        {
            using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
            {
                _httpClient.BaseAddress = new Uri($"{End_Externo}");

                string contents = await UrlHelper(action, "POST", httpContent);
            }
        }

        public async Task<T> PostWithReturn(string action, HttpContent httpContent = null)
        {
            using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
            {
                _httpClient.BaseAddress = new Uri($"{End_Externo}");

                string contents = await UrlHelper(action, "POST", httpContent);

                return JsonConvert.DeserializeObject<T>(contents);
            }
        }

        public async Task<object> PostObject(string action, HttpContent httpContent = null)
        {
            try
            {
                using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    _httpClient.BaseAddress = new Uri($"{End_Externo}");

                    var contents = await UrlHelper(action, "POST", httpContent);

                    return JsonConvert.DeserializeObject<object>(contents);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<string>> GetListString(string action, HttpContent httpContent = null)
        {
            try
            {
                using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    _httpClient.BaseAddress = new Uri(End_Externo);

                    string contents = await UrlHelper(action, "GET", httpContent);

                    return JsonConvert.DeserializeObject<List<string>>(contents);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ICollection<T>> PostList(string action, HttpContent httpContent = null)
        {
            using (HttpClient _httpClient = new HttpClient(new NativeMessageHandler()))
            {
                _httpClient.BaseAddress = new Uri($"{End_Externo}");

                string contents = await UrlHelper(action, "POST", httpContent);

                return JsonConvert.DeserializeObject<ObservableCollection<T>>(contents);
            }
        }
    }
}