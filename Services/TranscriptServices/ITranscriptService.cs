using webapi.Transcripts;
using webapi.ViewModel.Transcripts;

namespace webapi.Services.TranscriptServices;

public interface ITranscriptService
{
    IList<GetTranscriptDetail> GetTranscriptPage(SearchTranscriptModel searchWeatherModel);

    public Task<GetTranscriptDetail> CreateTranscriptAsync(CreateTranscript requestBody);
}