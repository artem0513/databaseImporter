using System;
using System.Runtime.Serialization;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Enums;

namespace Reko.Business.ApiRequestFramework.ApiResponse
{
    [DataContract]
    public class ApiError : IApiError
    {
        private int _statusCode;

        [DataMember(Name = "status_code")]
        public int StatusCode
        {
            get => _statusCode;
            private set
            {
                _statusCode = value;

                TmdbStatusCode = Enum.IsDefined(typeof(TmdbStatusCode), _statusCode)
                    ? (TmdbStatusCode) _statusCode
                    : TmdbStatusCode.Unknown;
            }
        }

        [DataMember(Name = "status_message")]
        public string Message { get; private set; }

        public TmdbStatusCode TmdbStatusCode { get; private set; }

        public override string ToString() => $"Status: {StatusCode}: {Message}";
    }
}