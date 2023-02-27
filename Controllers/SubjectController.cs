using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services.SubjectServices;
using webapi.ViewModel.Subjects;

namespace webapi.Controllers;
[ApiController]
[Route("api/subjects")]
public class SubjectController: ControllerBase
{
    private readonly ISubjectService _studentService;

    public SubjectController(ISubjectService subjectService)
    {
        _studentService = subjectService;
    }
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ModelsResponse<GetSubjectDetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSubject([FromQuery]SearchSubjectModel searchSubjectModel)
    {
        IList<GetSubjectDetail> result = _studentService.GetSubjectPage(searchSubjectModel);
        if (!result.Any())
        {
            return NoContent();
        } 
        return Ok(new ModelsResponse<GetSubjectDetail>()
        {
            Code = StatusCodes.Status200OK,
            Data = result.ToList(),
            Msg = "Use API get subject success!"
        });
    }
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<GetSubjectDetail>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateWeather([FromBody] CreateSubject requestBody)
    {
        var result = await _studentService.CreateSubjectAsync(requestBody);

        return Created(string.Empty, new BaseResponse<GetSubjectDetail>()
        {
            Code = StatusCodes.Status201Created,
            Data = result,
            Msg = "Send Request Successful"
        });
    }
}