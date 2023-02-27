using System.ComponentModel;

namespace webapi.ViewModel.Students;

public class SearchStudentModel
{
    [DefaultValue("")]
    public string? TenHv { get; set; } = "";

    public string? Lop { get; set; } = "";
}