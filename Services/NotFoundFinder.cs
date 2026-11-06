using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Web.Common;

namespace GroupUmbracoCMS.Services;

// Implementerar IContentFinder för att hantera 404-sidor, det är en del av Umbraco CMS
// som används för att hitta innehåll baserat på URL:er.
public class NotFoundFinder : IContentLastChanceFinder
{  // Lagrar en referens till UmbracoContextAccessor som används för att få tillgång till Umbraco-kontent.
    private readonly IUmbracoHelperAccessor _umbracoHelperAccessor;
    // Initierar instansen av UmbracoHelperAccessor via konstruktorn.
    public NotFoundFinder(IUmbracoHelperAccessor umbracoHelperAccessor)
    {
        _umbracoHelperAccessor = umbracoHelperAccessor;
    }




    // Implementerar metoden TryFindContent som försöker hitta innehåll baserat på den aktuella begäran
    public Task<bool> TryFindContent(IPublishedRequestBuilder request)
    {
        // Säkerställer att UmbracoHelper är tillgänglig i aktuell HTTP-kontext
        // // Hjälpklass för att hämta och navigera publicerat innehåll direkt från Umbracos minnescache
        if (!_umbracoHelperAccessor.TryGetUmbracoHelper(out var umbracoHelper))
        {
            return Task.FromResult(false);
        }

        // Hämta rot-noden via UmbracoHelper
        var rootNode = umbracoHelper.ContentAtRoot().FirstOrDefault();

        // Letar upp undersidan som har dokumenttypen 'notFoundPage'
        var errorPage = rootNode?.Children()
            .FirstOrDefault(c => c.ContentType.Alias.Equals("pageNotFound", StringComparison.OrdinalIgnoreCase));

        // Om felsidan hittas kopplas den till anropet med HTTP-statuskod 404
        if (errorPage != null)
        {
            request.SetPublishedContent(errorPage);
            request.SetResponseStatus(404);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}