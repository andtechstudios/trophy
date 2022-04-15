using System.Text.RegularExpressions;

namespace Andtech.Famehall.Controllers
{
	internal class ProfanityFilter
	{
		private Regex[] regexes;

		public ProfanityFilter(string path = "profanity.txt")
		{
			regexes = File.ReadAllLines(path)
				.Select(x => new Regex(x, RegexOptions.IgnoreCase))
				.ToArray();
		}

		public string Cleanse(string text)
		{
			for (int i = 0; i < regexes.Length; i++)
			{
				var regex = regexes[i];
				text = regex.Replace(text, "*");
			}

			return text;
		}
	}
}