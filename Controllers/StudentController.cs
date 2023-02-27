using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services.StudentServices;
using webapi.Students;
using webapi.ViewModel.Students;

namespace webapi.Controllers;
[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ModelsResponse<GetStudentDetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllStudent([FromQuery]SearchStudentModel searchStudentModel)
    {
        IList<GetStudentDetail> result = _studentService.GetStudentPage(searchStudentModel);
        if (!result.Any())
        {
            return NoContent();
        } 
        return Ok(new ModelsResponse<GetStudentDetail>()
        {
            Code = StatusCodes.Status200OK,
            Data = result.ToList(),
            Msg = "Use API get student success!"
        });
    }
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<GetStudentDetail>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateWeather([FromBody] CreateStudent requestBody)
    {
        var result = await _studentService.CreateStudentAsync(requestBody);

        return Created(string.Empty, new BaseResponse<GetStudentDetail>()
        {
            Code = StatusCodes.Status201Created,
            Data = result,
            Msg = "Send Request Successful"
        });
    }
}