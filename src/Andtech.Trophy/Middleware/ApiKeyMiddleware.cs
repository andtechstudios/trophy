namespace Andtech.Trophy.Middleware
{

	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;

		public ApiKeyMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (Session.Instance.HasApiKey)
			{
				if (!context.Request.Headers.TryGetValue("ApiKey", out var requestApiKey))
				{
					context.Response.StatusCode = 401;
					await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");
					return;
				}

				if (!requestApiKey.Equals(Session.Instance.ApiKey))
				{
					context.Response.StatusCode = 401;
					await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
					return;
				}
			}

			await _next(context);
		}
	}
}