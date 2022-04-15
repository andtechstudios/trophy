using Andtech.Famehall.Models;
using Microsoft.AspNetCore.Mvc;
using SQLite;

namespace Andtech.Famehall.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<Score> GetWeatherForecast()
		{
			Score[] scores = new Score[0];
			using (var connection = new SQLiteConnection("players.db"))
			{
				scores = connection.Table<Score>().ToArray();
			}

			return scores;
		}

		[HttpPost(Name = "PutScore")]
		public async Task<IActionResult> PutScore(Score score)
		{
			var token = CancellationToken.None;
			score.timestamp = DateTime.UtcNow;

			using (var connection = new SQLiteConnection("players.db"))
			{
				connection.CreateTable<Score>();

				connection.Insert(score);
			}

			return CreatedAtAction(nameof(PutScore), new { }, score);
		}
	}
}