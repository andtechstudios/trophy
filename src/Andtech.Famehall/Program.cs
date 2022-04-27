using Andtech.Famehall;
using Andtech.Famehall.Middleware;

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
app.UseMiddleware<ApiKeyMiddleware>();

if (Session.Instance.HasApiKey)
{
	Console.WriteLine("Api Key detected. Authentication is enabled!");
}
else
{
	Console.WriteLine("No api key detected. Authentication disabled!");
}

app.Run();
