using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reko.Business.ApiRequestFramework.ApiResponse;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.JsonConverters;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public abstract class ApiRequestBase
    {
        private readonly IMovieDbSettings _settings;

        protected ApiRequestBase(IMovieDbSettings settings)
        {
            _settings = settings;
        }

        public async Task<ApiQueryResponse<T>> QueryAsync<T>(string command)
            => await QueryAsync<T>(command, new Dictionary<string, string>());

        public async Task<ApiQueryResponse<T>> QueryAsync<T>(string command, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };
            settings.Converters.Add(new IsoDateTimeConverterEx());

            T Deserializer(string json) => JsonConvert.DeserializeObject<T>(json, settings);

            return await QueryAsync(command, parameters, Deserializer);
        }

        public async Task<ApiQueryResponse<T>> QueryAsync<T>(string command, Func<string, T> deserializer)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            return await QueryAsync(command, new Dictionary<string, string>(), deserializer);
        }

        public async Task<ApiQueryResponse<T>> QueryAsync<T>(string command, IDictionary<string, string> parameters, Func<string, T> deserializer)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var client = CreateClient();
            var cmd = CreateCommand(command, parameters);

            var response = await client.GetAsync(cmd).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var error = new ApiQueryResponse<T>
                {
                    Error = JsonConvert.DeserializeObject<ApiError>(json),
                    CommandText = response.RequestMessage.RequestUri.ToString(),
                    Json = json,
                };

                return error;
            }

            var result = new ApiQueryResponse<T>
            {
                CommandText = response.RequestMessage.RequestUri.ToString(),
                Json = json,
            };

            var item = deserializer(json);
            result.Item = item;
            return result;
        }

        public async Task<ApiSearchResponse<T>> SearchAsync<T>(string command)
            => await SearchAsync<T>(command, 1);

        public async Task<ApiSearchResponse<T>> SearchAsync<T>(string command, int pageNumber)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            return await SearchAsync<T>(command, pageNumber, new Dictionary<string, string>());
        }

        public async Task<ApiSearchResponse<T>> SearchAsync<T>(string command, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await SearchAsync<T>(command, 1, parameters);
        }

        public async Task<ApiSearchResponse<T>> SearchAsync<T>(string command, int pageNumber, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException(nameof(command));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageNumber = pageNumber > 1000 ? 1000 : pageNumber;

            if (!parameters.Keys.Contains("page", StringComparer.OrdinalIgnoreCase))
            {
                parameters.Add("page", pageNumber.ToString());
            }

            using var client = CreateClient();
            var cmd = CreateCommand(command, parameters);

            var response = await client.GetAsync(cmd).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var error = new ApiSearchResponse<T>
                {
                    Error = JsonConvert.DeserializeObject<ApiError>(json),
                    CommandText = response.RequestMessage.RequestUri.ToString(),
                    Json = json,
                };

                return error;
            }

            var result = JsonConvert.DeserializeObject<ApiSearchResponse<T>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            result.CommandText = response.RequestMessage.RequestUri.ToString();
            result.Json = json;

            return result;
        }

        protected HttpClient CreateClient()
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseCookies = false,
                UseDefaultCredentials = true,
                AutomaticDecompression = DecompressionMethods.GZip,
            };

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_settings.ApiUrl);

            return client;
        }

        protected string CreateCommand(string rootCommand)
            => CreateCommand(rootCommand, new Dictionary<string, string>());

        protected string CreateCommand(string rootCommand, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(rootCommand))
            {
                throw new ArgumentException(nameof(rootCommand));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var command = $"{rootCommand}?api_key={_settings.ApiKey}";

            var tokens = parameters.Any()
                ? string.Join("&", parameters.Select(x => x.Key + "=" + x.Value))
                : string.Empty;

            if (string.IsNullOrWhiteSpace(tokens) == false)
            {
                command = $"{command}&{tokens}";
            }

            return command;
        }
    }
}