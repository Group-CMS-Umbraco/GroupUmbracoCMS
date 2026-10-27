using GroupUmbracoCMS.ViewModels;

namespace GroupUmbracoCMS.Services;

public interface INewsTipService
{
    Task<bool> SaveTipAsync (NewstipFormViewModel model);
}
