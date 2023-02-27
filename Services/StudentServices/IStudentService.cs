using webapi.Entities;
using webapi.Students;
using webapi.ViewModel.Students;

namespace webapi.Services.StudentServices;

public interface IStudentService
{
    IList<GetStudentDetail> GetStudentPage(SearchStudentModel searchWeatherModel);

    public Task<GetStudentDetail> CreateStudentAsync(CreateStudent requestBody);
}