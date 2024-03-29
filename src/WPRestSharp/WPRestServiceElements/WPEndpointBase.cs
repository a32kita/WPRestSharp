﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WPRestSharp.InternalImpls;

namespace WPRestSharp.WPRestServiceElements
{
    public abstract class WPEndpointBase
    {
        private HttpClient _httpClient;
        private WPRestConnectionInfo _connectionInfo;
        private JsonSerializerOptions _serializerOptions;

        internal static IReadOnlyDictionary<String, String> EmptyDictionary;


        internal WPEndpointBase(HttpClient httpClient, WPRestConnectionInfo connectionInfo)
        {
            this._httpClient = httpClient;
            this._connectionInfo = connectionInfo;
            this._serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                //PropertyNamingPolicy = new JsonSeparatedLowerNamingPolicyImpl('_'),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#if DEBUG
                WriteIndented = true,
#endif
            };

            this._serializerOptions.Converters.Add(new WPRestCategoryId.JsonConverter());
            this._serializerOptions.Converters.Add(new WPRestPostId.JsonConverter());
            this._serializerOptions.Converters.Add(new WPRestUserId.JsonConverter());
            this._serializerOptions.Converters.Add(new WPRestMediaId.JsonConverter());
            this._serializerOptions.Converters.Add(new WPRestStatus_Converter());
            this._serializerOptions.Converters.Add(new WPRestReactionStatus_Converter());
        }

        static WPEndpointBase()
        {
            EmptyDictionary = new Dictionary<String, String>();
        }


        private string _getFullUrl(string endpoint, IReadOnlyDictionary<String, String> queryParameter)
        {
            var uriParameterPart = String.Empty;
            if (queryParameter.Count > 0)
                uriParameterPart = "?" + String.Join("&", queryParameter.Select(kvp => kvp.Key + "=" + Uri.EscapeDataString(kvp.Value)));

            return this._connectionInfo.BaseUrl + "/wp-json/wp/v2/" + endpoint + uriParameterPart;
        }

        private async Task<StreamContent> _getStreamContent<T>(T obj)
        {
#if !DEBUG
            var ms = new MemoryStream();
            JsonSerializer.Serialize(ms, obj, this._serializerOptions);
#else
            var json = JsonSerializer.Serialize(obj, this._serializerOptions);
            var ms = new MemoryStream();
            using (var sw = new StreamWriter(ms, new UTF8Encoding(false), 512, true))
            {
                await sw.WriteAsync(json);
            }
#endif
            await ms.FlushAsync();
            ms.Position = 0;
            var stContent = new StreamContent(ms);
            stContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return stContent;
        }

        private void _addingAuthInfo(HttpRequestMessage hreq)
        {
            if (this._connectionInfo.IsAnonymous)
                return;

            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(this._connectionInfo.User + ":" + this._connectionInfo.ApplicationPassword));
            hreq.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
        }

        private async Task<TResp> _executeRequestAsync<TResp>(HttpRequestMessage hreq)
        {
            using (var hres = await this._httpClient.SendAsync(hreq))
            using (var respStream = await hres.Content.ReadAsStreamAsync())
            {
                if (hres.IsSuccessStatusCode == true)
                    return JsonSerializer.Deserialize<TResp>(respStream, this._serializerOptions);

                using (var sr = new StreamReader(respStream))
                {
                    var errorMessage = JsonSerializer.Deserialize<WPRestErrorMessage>(respStream, this._serializerOptions);
                    throw new WPRestException(errorMessage);
                }
            }
        }

        private async Task<TResp> _sendRequestAsync<TParam, TResp>(string endpoint, IReadOnlyDictionary<string, string> queryParameter, HttpMethod method, TParam param)
        {
            using (var reqContent = await this._getStreamContent(param))
            using (var hreq = new HttpRequestMessage(method, this._getFullUrl(endpoint, queryParameter)))
            {
                this._addingAuthInfo(hreq);
                if (param is WPVoidParameter == false)
                {
                    hreq.Content = reqContent;
                }

                return await this._executeRequestAsync<TResp>(hreq);
            }
        }

        private async Task<TResp> _sendFileAsync<TResp>(string endpoint, IReadOnlyDictionary<string, string> queryParameter, HttpMethod method, Stream contentStream, string contentType, string fileName)
        {
            using (var fileContent = new StreamContent(contentStream))
            using (var reqContent = new MultipartFormDataContent())
            {
                reqContent.Add(fileContent, "file", fileName);

                using (var hreq = new HttpRequestMessage(method, this._getFullUrl(endpoint, queryParameter)))
                {
                    this._addingAuthInfo(hreq);
                    hreq.Content = reqContent;

                    return await this._executeRequestAsync<TResp>(hreq);
                }
            }
        }

        protected async Task<TResp> HttpGetAsync<TParam, TResp>(string endpoint, IReadOnlyDictionary<string, string> queryParameter, TParam param)
        {
            return await this._sendRequestAsync<TParam, TResp>(endpoint, queryParameter, HttpMethod.Get, param);
        }

        protected async Task<TResp> HttpPostAsync<TParam, TResp>(string endpoint, IReadOnlyDictionary<string, string> queryParameter, TParam param)
        {
            return await this._sendRequestAsync<TParam, TResp>(endpoint, queryParameter, HttpMethod.Post, param);
        }

        protected async Task<TResp> HttpPostFileAsync<TResp>(string endpoint, IReadOnlyDictionary<string, string> queryParameter, WPRestMediaFile file)
        {
            return await this._sendFileAsync<TResp>(endpoint, queryParameter, HttpMethod.Post, file.BaseStream, file.ContentType, file.FileName);
        }
    }
}
