using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace CatBoardApi.Models
{
  [JsonObject("tokenManagement")]
  public class TokenManagement
  {
    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("issuer")]
    public string Issuer { get; set; }

    [JsonProperty("audience")]
    public string Audience { get; set; }

    [JsonProperty("accessExpiration")]
    public int AccessExpiration { get; set; }

    [JsonProperty("refreshExpiration")]
    public int RefreshExpiration { get; set; }
  }

  public class TokenRequest
  {
    [Required]
    [JsonProperty("name")]
    public string Username { get; set; }


    [Required]
    [JsonProperty("password")]
    public string Password { get; set; }
  }
}