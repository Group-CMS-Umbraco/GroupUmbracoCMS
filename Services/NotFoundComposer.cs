using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Routing;

namespace GroupUmbracoCMS.Services;

public class NotFoundComposer : IComposer
{
    // Registrerar NotFoundFinderbför att hantera 404-sidor
    public void Compose(IUmbracoBuilder builder)
    {
         // Hanterar felaktiga URL:er och visar vår 404-sida
        builder.SetContentLastChanceFinder<NotFoundFinder>();
    }
}