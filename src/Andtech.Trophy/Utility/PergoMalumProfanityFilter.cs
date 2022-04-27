using Flurl;
using Flurl.Http;

namespace Andtech.Trophy.Controllers
{
	internal class PergoMalumProfanityFilter : IAsyncProfanityFilter
	{

		public async Task<string> SanitizeAsync(string text, CancellationToken cancellationToken = default)
		{
			var response = await "https://www.purgomalum.com/service/plain"
				.SetQueryParams(new { text = text })
				.GetAsync(cancellationToken: cancellationToken)
				.ReceiveString();

			return response;
		}
	}
}