namespace SushiRest.Api.Tools;

public class JsonWebTokenOptions
{
	public string? SecretKey { get; set; }
	public string? Issuer  { get; set; }
	public string? Audience  { get; set; }
}