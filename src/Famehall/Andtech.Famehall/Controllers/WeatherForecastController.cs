using Andtech.Famehall.Models;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System.IO;

namespace Andtech.Famehall.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private string databasePath = "players.db";

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<Score> GetWeatherForecast(int count = 10)
		{
			if (!System.IO.File.Exists(databasePath))
			{
				return Enumerable.Empty<Score>();
			}

			Score[] scores = new Score[0];
			using (var connection = new SQLiteConnection(databasePath))
			{
				scores = connection.Table<Score>()
					.Take(count)
					.ToArray();
			}

			return scores;
		}

		[HttpPost(Name = "PutScore")]
		public async Task<IActionResult> PutScore(ScoreRequest request)
		{
			var score = new Score()
			{
				Name = request.name.ToUpperInvariant(),
				Points = request.points,
				Timestamp = DateTime.UtcNow,
			};

			var token = CancellationToken.None;
			using (var connection = new SQLiteConnection(databasePath))
			{
				connection.CreateTable<Score>();

				connection.Insert(score);
			}

			return CreatedAtAction(nameof(PutScore), score);
		}
	}
}