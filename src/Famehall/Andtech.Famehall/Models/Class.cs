﻿namespace Andtech.Famehall.Models
{

	public class ScoreResponse
	{
		public long rank { get; set; }
		public string name { get; set; }
		public long points { get; set; }
	}

	public class ScoreRequest
	{
		public string name { get; set; }
		public long points { get; set; }
	}
}
