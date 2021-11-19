using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BooksService.Models
{
    public class UserRegistrationResponse
    {
        public int Affected { get; set; }
        public bool IsCodeSentSuccess { get; set; }

        public RegistrationResponseCode ResponseCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum RegistrationResponseCode : int
        {
            Success = 0,
            [EnumMember(Value = "email_already_registered")]
            EmailAlreadyRegistered = 1,
            [EnumMember(Value = "validation_failed")]
            ValidationFailed = 2,
            [EnumMember(Value = "phone_number_already_registered")]
            PhoneNumberAlreadyRegistered = 4,
        }
    }
}
