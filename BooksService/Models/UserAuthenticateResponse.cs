using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BooksService.Models
{
    public class UserAuthenticateResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsCodeSentSuccess { get; set; }

        public AuthenticateResponseCode ResponseCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AuthenticateResponseCode : int
        {
            Success = 0,
            [EnumMember(Value = "user_name_not_found")]
            UserNameNotFound = 1,
            [EnumMember(Value = "validation_failed")]
            ValidationFailed = 2,
            [EnumMember(Value = "wrong_input")]
            WrongInput = 3,
        }
    }
}
