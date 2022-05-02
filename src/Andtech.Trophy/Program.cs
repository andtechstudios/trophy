using Andtech.Common.Http;
using Andtech.Trophy;

Session.Instance = new Session();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Require authorization
if (Session.Instance.HasApiKey)
{
	app.UseMiddleware<ApiKeyMiddleware>();
	ApiKeyMiddleware.TestApiKey = x => x == Session.Instance.ApiKey;
	Console.WriteLine("Api Key detected. Authentication is enabled!");
}
else
{
	Console.WriteLine("No api key detected. Authentication disabled!");
}

app.Run();
