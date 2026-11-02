using GroupUmbracoCMS.ViewModels;
using Umbraco.Cms.Core.Services;


namespace GroupUmbracoCMS.Services;

public class NewstipSubmissionService(IContentService contentService)
{

    private readonly IContentService _contentService = contentService;

    public bool SaveNewstipRequest(NewstipFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "newstipSubmissions");
            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH-mm} - {model.Email}";
            var request = _contentService.Create(requestName, container, "newstipRequest");

            request.SetValue("newstipRequestEmail", model.Email);
            request.SetValue("newstipRequestSubject", model.Category);
            request.SetValue("newstipRequestDescription", model.Description);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {

            return false;
        }

    }
   
}
