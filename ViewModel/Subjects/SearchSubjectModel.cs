using System.ComponentModel;

namespace webapi.ViewModel.Subjects;

public class SearchSubjectModel
{
    [DefaultValue("")]
    public string? TenMh { get; set; } = "";
}