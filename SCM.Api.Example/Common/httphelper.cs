using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCM.Api.Example.Common
{
    public class HttpHelper
    {
        Logger nlog = LogManager.GetCurrentClassLogger();
        int errorCount = 0;
        public T GetData<T>(string url, Dictionary<string, string> header = null)
        {
            return GetData<T>(new Uri(url), header);
        }
        public T PostData<T,T1>(string url, T1 Data, Dictionary<string, string> header = null)
        {
            return PostData<T, T1>(new Uri(url),  Data, header);
        }
        public string GetData(string url, Dictionary<string, string> header = null)
        {
            return GetData(new Uri(url), header);
        }


        #region 取得資料
        private T GetData<T>(Uri url, Dictionary<string, string> header = null)
        {
            try
            {
                string responseData = HttpGet(url, header);
                var Tobject = JsonConvert.DeserializeObject<T>(responseData); ;
                errorCount = 0;
                return Tobject;
            }
            catch (JsonException)
            {
                if (errorCount == 10) { return default(T); }
                errorCount++;
                return GetData<T>(url);
            }
        }
        private T PostData<T, T1>(Uri url, T1 Data, Dictionary<string, string> header = null)
        {
            try
            {
                string responseData = HttpPost<T1>(url,  Data, header);
                var Tobject = JsonConvert.DeserializeObject<T>(responseData); ;
                errorCount = 0;
                return Tobject;
            }
            catch (JsonException)
            {
                if (errorCount == 10) { return default(T); }
                errorCount++;
                return PostData<T, T1>(url ,Data, header);
            }
        }

        private string GetData(Uri url, Dictionary<string, string> header = null)
        {
            try
            {
                string responseData = HttpGet(url, header);
                errorCount = 0;
                return responseData;
            }
            catch
            {
                if (errorCount == 10) { return ""; }
                errorCount++;
                return GetData(url);
            }
        }

        private string HttpGet(Uri uri, Dictionary<string, string> header = null)
        {
            Thread.Sleep(1000);
            string responseData = "";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    SetHttpHeader(httpClient, header);
                    httpClient.Timeout = TimeSpan.FromSeconds(5);
                    var httpResponse = httpClient.GetAsync(uri).Result;
                    responseData = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (AggregateException ex)
            {
                nlog.Error(ex, $"{DateTime.Now }  error  get error {uri} ");
                Console.WriteLine(ex.Message);
            }
            return responseData;
        }

        private string HttpPost<T1>(Uri uri, T1 Data,  Dictionary<string, string> header = null)
        {
            Thread.Sleep(1000);
            string responseData = "";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    SetHttpHeader(httpClient, header);
                    httpClient.Timeout = TimeSpan.FromSeconds(5);
                    string json = JsonConvert.SerializeObject(Data);
                    HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync(uri, contentPost).GetAwaiter().GetResult();
                    responseData= response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (AggregateException ex)
            {
                nlog.Error(ex, $"{DateTime.Now }  error  get error {uri} ");
                Console.WriteLine(ex.Message);
            }
            return responseData;
        }
        private HttpClient SetHttpHeader(HttpClient httpClient, Dictionary<string, string> header = null)
        {
            if (header != null)
            {
                foreach (var d in header.Keys)
                {
                    httpClient.DefaultRequestHeaders.Add(d, header[d]);
                }
            }

            return httpClient;
        }
        #endregion

    }
}
