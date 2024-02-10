using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JimmInvoTest.Model
{
    public class TokenRequest
    {
        [Required]
        [JsonProperty("loginName")]
        [StringLength(250)]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}
