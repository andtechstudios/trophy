namespace Andtech.Famehall.Middleware
{

	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string APIKEYNAME = "ApiKey";
		public ApiKeyMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var expectedKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");
				return;
			}

			if (string.IsNullOrEmpty(expectedKey))
			{
				await _next(context);
			}

			var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
			var apiKey = appSettings.GetValue<string>(APIKEYNAME);

			if (!apiKey.Equals(expectedKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
				return;
			}

			await _next(context);
		}
	}
}