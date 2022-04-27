
namespace Andtech.Trophy
{
	public interface IAsyncProfanityFilter
	{

		Task<string> SanitizeAsync(string text, CancellationToken cancellationToken = default);
	}
}
