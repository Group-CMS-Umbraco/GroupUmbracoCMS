using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace GroupUmbracoCMS.Services;

public class NewsTipComposer : IUserComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddScoped<INewsTipService, NewstipService>();
    }
}
