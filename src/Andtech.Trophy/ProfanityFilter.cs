using Flurl;
using Flurl.Http;
using System.Text.RegularExpressions;

namespace Andtech.Trophy.Controllers
{
	internal class ProfanityFilter
	{

		public async Task<string> SanitizePurgoMalum(string text, CancellationToken cancellationToken = default)
		{
			var response = await "https://www.purgomalum.com/service/plain"
				.SetQueryParams(new { text = text })
				.GetAsync(cancellationToken: cancellationToken)
				.ReceiveString();

			return response;
		}
	}
}