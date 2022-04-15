using SQLite;

namespace Andtech.Famehall.Models
{

	[Table("scores")]
	public class Score
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string name { get; set; }
		public DateTime timestamp { get; set; }
		[Indexed]
		public long score { get; set; }
	}
}
