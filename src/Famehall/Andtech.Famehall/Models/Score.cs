using SQLite;

namespace Andtech.Famehall.Models
{

	[Table("scores")]
	public class Score
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Timestamp { get; set; }
		[Indexed]
		public long Points { get; set; }
	}
}
