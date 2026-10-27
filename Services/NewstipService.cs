using GroupUmbracoCMS.ViewModels;
using Umbraco.Cms.Core.Services;


namespace GroupUmbracoCMS.Services;

public class NewstipService : INewsTipService
{

    private readonly IContentService _contentService;
    private readonly ILogger<NewstipService> _logger;

    public NewstipService(IContentService contentService, ILogger<NewstipService> logger)
    {
        _contentService = contentService;
        _logger = logger;
    }

    public Task<bool> SaveTipAsync(NewstipFormViewModel model)
    {
        try
        {
            // Hämta rot-noden "Inskickade Tips" som har alias 'tipsContainer'
            var rootNodes = _contentService.GetRootContent();
            var containerNode = rootNodes.FirstOrDefault(x => x.ContentType.Alias == "tipsContainer");

            if (containerNode == null)
            {
                _logger.LogError("Tips Container med alias 'tipsContainer' hittades inte i Content-roten.");
                return Task.FromResult(false);
            }

            // Generera ett unikt och läsbart namn för noden i Backoffice
            var nodeName = $"Tip - {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";

            // Skapa noden som ett barn under Tips Container
            var tipNode = _contentService.Create(nodeName, containerNode.Id, "newsTip");

            // Mappa fälten mot egenskaperna vi skapade på 'newsTip'
            tipNode.SetValue("Email", string.IsNullOrWhiteSpace(model.Email) ? "Anonym" : model.Email);
            tipNode.SetValue("Category", model.Category);
            tipNode.SetValue("Description", model.Description);
            tipNode.SetValue("submittedDate", DateTime.UtcNow);

            // Spara noden som opublicerat utkast för redaktionen att hantera
            _contentService.Save(tipNode);

            _logger.LogInformation("Ett nytt tips har sparats framgångsrikt i Backoffice.");
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ett fel uppstod när tipset skulle sparas i Umbraco Backoffice.");
            return Task.FromResult(false);
        }
    }






















}
