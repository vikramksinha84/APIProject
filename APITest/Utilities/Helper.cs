using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;

namespace APITest.Utilities
{
    internal class Helper
    {
        /// <summary>
        /// Get Request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns>RestRequest</returns>
        public RestRequest? GetRequest(string url, Method method)
        {
            switch(method)
            {
                case Method.Get:
                    return new RestRequest(url, Method.Get);
                case Method.Post:
                    return new RestRequest(url, Method.Post);
                case Method.Put:
                    return new RestRequest(url, Method.Put);
                case Method.Patch:
                    return new RestRequest(url, Method.Patch);
                case Method.Delete:
                    return new RestRequest(url, Method.Delete);
                default:
                    return null;
            }

        }

        /// <summary>
        /// Add Path Parameter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pathParams"></param>
        public void AddPathParameter(RestRequest request, Dictionary<String, String> pathParams)
        {
            foreach (var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);
        }

        /// <summary>
        /// Add Query Parameter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pathParams"></param>
        public void AddQueryParameter(RestRequest request, Dictionary<String, String> pathParams)
        {
            foreach (var param in pathParams)
                request.AddQueryParameter(param.Key, param.Value);
        }

        /// <summary>
        /// Add Post Request Body
        /// </summary>
        /// <param name="request"></param>
        /// <param name="addBody"></param>
        public void AddPostRequestBody(RestRequest request, string addBody)
        {
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", addBody, ParameterType.RequestBody);
        }

        /// <summary>
        /// Add Headers ForGetPost
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        public void AddHeadersForGetPost(RestRequest request, Dictionary<String, String> headers)
        {
            request.RequestFormat = DataFormat.Json;
            request.AddHeaders(headers);
        }

        /// <summary>
        /// Get Response Object
        /// </summary>
        /// <param name="response"></param>
        /// <param name="responseObject"></param>
        /// <returns></returns>
        public string? GetResponseObject(RestResponse? response, string responseObject)
        {
            JObject? obs = null;
            if (response?.Content != null)
            obs = JObject.Parse(response.Content);
            return obs?[responseObject]?.ToString();
        }

        /// <summary>
        /// Json File Read
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public Dictionary<string, string>? JsonFileRead(string Path)
        {
            if (File.Exists(Path))
            {
                using StreamReader r = new StreamReader(Path);
                string jsonString = r.ReadToEnd();
                JObject? jsonObj = JObject.Parse(jsonString);
                Dictionary<string, string>? dictObj = jsonObj?.ToObject<Dictionary<string ,string>>();
                return dictObj;
            }
            else
                throw new FileNotFoundException("Either file does not exist OR file path is not valid.");
        }

        /// <summary>
        /// Solution Path
        /// </summary>
        /// <returns></returns>
        public string? SolutionPath()
        {
            var folderName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (folderName != null)
            {
                return folderName.Substring(0, folderName.LastIndexOf("\\bin"));
            }
            return null;
        }

        /// <summary>
        /// Asset
        /// </summary>
        /// <param name="ActualValue"></param>
        /// <param name="ExpectedValue"></param>
        public void AssetTrue(string ActualValue, string ExpectedValue)
        {
            try
            {
                Assert.True(ActualValue.Equals(ExpectedValue, StringComparison.OrdinalIgnoreCase), $"{ActualValue} actual value not matched with expected value {ExpectedValue}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ActualValue} actual value not matched with expected value {ExpectedValue } Exception message : {ex}");
            }
        }

        /// <summary>
        /// Perform Request
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public RestClient? PerformRequest(string BaseUrl)
        {
            try
            {
                return new RestClient(BaseUrl);
            }
            catch { return null; }
        }

        /// <summary>
        /// Serialize Json
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string SerializeJson(dynamic payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);
        }

        /// <summary>
        /// Perse Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public T? PerseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

    }
}
