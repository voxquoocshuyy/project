using AutoMapper;
using webapi.Entities;
using webapi.Repositories.SubjectRepositories;
using webapi.ViewModel.Subjects;

namespace webapi.Services.SubjectServices;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;

    public SubjectService(ISubjectRepository studentRepository, IMapper mapper)
    {
        _subjectRepository = studentRepository;
        _mapper = mapper;
    }
    public IList<GetSubjectDetail> GetSubjectPage(SearchSubjectModel searchSubjectModel)
    {
        IQueryable<MonHoc> querySubject = _subjectRepository.GetAll();
        if (searchSubjectModel.TenMh != "")
        {
            querySubject = querySubject.Where(x => x.TenMh.Contains(searchSubjectModel.TenMh));
        }
        var result = _mapper.ProjectTo<GetSubjectDetail>(querySubject);
        return result.ToList();
    }
    public async Task<GetSubjectDetail> CreateSubjectAsync(CreateSubject requestBody)
    {
        var monHoc = _mapper.Map<MonHoc>(requestBody);
        if (monHoc == null)
        {
            throw new Exception("Please enter the correct information!!! ");
        }
        await _subjectRepository.InsertAsync(monHoc);
        await _subjectRepository.SaveChangesAsync();
        GetSubjectDetail weatherDetail = _mapper.Map<GetSubjectDetail>(monHoc);
        return weatherDetail;
    }
}