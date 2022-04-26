using Andtech.Famehall.Models;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace Andtech.Famehall.Controllers
{

	[ApiController]
	[Route("api/leaderboards")]
	public class LeaderboardController : ControllerBase
	{
		private string databasePath = "players.db";
		private ProfanityFilter profanityFilter;

		public LeaderboardController()
		{
			profanityFilter = new ProfanityFilter();
		}

		[HttpGet]
		public IEnumerable<Score> GetScores(int count = 10)
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

		[HttpPost]
		public async Task<IActionResult> PutScore(ScoreRequest request)
		{
			var token = CancellationToken.None;

			var name = request.name;
			name = await profanityFilter.SanitizePurgoMalum(name, cancellationToken: token);
			Console.WriteLine("'" + name + "'");
			name = Regex.Replace(name, @"\s", string.Empty);
			name = Regex.Replace(name, @"\d", string.Empty);
			name = name.ToUpperInvariant();

			var score = new Score()
			{
				Name = name,
				Points = request.points,
				Timestamp = DateTime.UtcNow,
			};

			using (var connection = new SQLiteConnection(databasePath))
			{
				connection.CreateTable<Score>();

				connection.Insert(score);
			}

			return CreatedAtAction(nameof(PutScore), score);
		}
	}
}