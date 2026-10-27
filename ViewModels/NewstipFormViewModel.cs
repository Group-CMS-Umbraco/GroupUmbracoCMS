using System.ComponentModel.DataAnnotations;

namespace GroupUmbracoCMS.ViewModels;

public class NewstipFormViewModel
{
    [Display(Name = "Email Address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter a category.")]
    [Display(Name = "Category")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Please enter a description.")]
    [Display(Name = "Description")]
    public string Description { get; set; } = null!;

    [Display(Name = "Accept Terms and Conditions")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions.")]
    public bool AcceptTerms { get; set; }
}
