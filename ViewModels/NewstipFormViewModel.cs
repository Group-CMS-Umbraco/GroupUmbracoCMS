using System.ComponentModel.DataAnnotations;

namespace GroupUmbracoCMS.ViewModels;

public class NewstipFormViewModel
{
    [Display(Name = "Email Address")]
    [EmailAddress(ErrorMessage = "Vänligen ange en giltig emailadress.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Vänligen välj en kategori!")]
    [Display(Name = "Category")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Vänligen fyll i beskrivning!")]
    [Display(Name = "Description")]
    public string Description { get; set; } = null!;

    [Display(Name = "Accept Terms and Conditions")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Vänligen godkänn villkoren!")]
    public bool AcceptTerms { get; set; }
}
