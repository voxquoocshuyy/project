using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services.TranscriptServices;
using webapi.Transcripts;
using webapi.ViewModel.Transcripts;

namespace webapi.Controllers;
[ApiController]
[Route("api/transcripts")]
public class TranscriptController: ControllerBase
{
    private readonly ITranscriptService _transcriptService;

    public TranscriptController(ITranscriptService transcriptService)
    {
        _transcriptService = transcriptService;
    }
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ModelsResponse<GetTranscriptDetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllTranscript([FromQuery]SearchTranscriptModel searchTranscriptModel)
    {
        IList<GetTranscriptDetail> result = _transcriptService.GetTranscriptPage(searchTranscriptModel);
        if (!result.Any())
        {
            return NoContent();
        } 
        return Ok(new ModelsResponse<GetTranscriptDetail>()
        {
            Code = StatusCodes.Status200OK,
            Data = result.ToList(),
            Msg = "Use API get transcript success!"
        });
    }
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<GetTranscriptDetail>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateWeather([FromBody] CreateTranscript requestBody)
    {
        var result = await _transcriptService.CreateTranscriptAsync(requestBody);

        return Created(string.Empty, new BaseResponse<GetTranscriptDetail>()
        {
            Code = StatusCodes.Status201Created,
            Data = result,
            Msg = "Send Request Successful"
        });
    }
}