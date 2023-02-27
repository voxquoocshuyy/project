using AutoMapper;
using webapi.Entities;
using webapi.Repositories.StudentRepositories;
using webapi.Students;
using webapi.ViewModel.Students;

namespace webapi.Services.StudentServices;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public IList<GetStudentDetail> GetStudentPage(SearchStudentModel searchStudentModel)
    {
        IQueryable<HocVien> queryStudent = _studentRepository.GetAll();
        if (searchStudentModel.Lop != "")
        {
            queryStudent = queryStudent.Where(x => x.Lop.Contains(searchStudentModel.Lop));
        }
        var result = _mapper.ProjectTo<GetStudentDetail>(queryStudent);
        return result.ToList();
    }
    public async Task<GetStudentDetail> CreateStudentAsync(CreateStudent requestBody)
    {
        var hocVien = _mapper.Map<HocVien>(requestBody);
        if (hocVien == null)
        {
            throw new Exception("Please enter the correct information!!! ");
        }
        await _studentRepository.InsertAsync(hocVien);
        await _studentRepository.SaveChangesAsync();
        GetStudentDetail weatherDetail = _mapper.Map<GetStudentDetail>(hocVien);
        return weatherDetail;
    }
}