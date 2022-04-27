namespace Andtech.Trophy
{

	public class Session
	{
		public string ApiKey => Environment.GetEnvironmentVariable("AUTH_KEY") ?? string.Empty;
		public bool HasApiKey => !string.IsNullOrEmpty(ApiKey);

		public static Session Instance { get; set; }
	}
}
