using webapi.ViewModel.Subjects;

namespace webapi.Services.SubjectServices;

public interface ISubjectService
{
    IList<GetSubjectDetail> GetSubjectPage(SearchSubjectModel searchWeatherModel);

    public Task<GetSubjectDetail> CreateSubjectAsync(CreateSubject requestBody);
}