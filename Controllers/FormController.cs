using GroupUmbracoCMS.Services;
using GroupUmbracoCMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace GroupUmbracoCMS.Controllers
{
    public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, NewstipSubmissionService newstipSubmissions) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        private readonly NewstipSubmissionService _newstipSubmissions = newstipSubmissions;

        public IActionResult HandleNewstipForm(NewstipFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                
                return CurrentUmbracoPage();
            }

            var result = _newstipSubmissions.SaveNewstipRequest(model);
            if (!result)
            {
                TempData["NewstipFormError"] = "There was an error processing your request. Please try again later.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["NewstipFormSuccess"] = "Thank you for your submission! We will review your request and get back to you if necessary.";

            return RedirectToCurrentUmbracoPage();
        }
    }
}
