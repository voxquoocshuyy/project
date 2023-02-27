using System.ComponentModel;

namespace webapi.ViewModel.Transcripts;

public class SearchTranscriptModel
{
    [DefaultValue("")]
    public int? MaHp { get; set; } = null;

    public float? Diem { get; set; } = null;

    public int? HeSo { get; set; } = null;

    public int? NamHoc { get; set; } = null;

    public int? MaHv { get; set; } = null;

    public int? MaMh { get; set; } = null;
}