using AutoMapper;
using webapi.Entities;
using webapi.Repositories.TranscriptRepositories;
using webapi.Transcripts;
using webapi.ViewModel.Transcripts;

namespace webapi.Services.TranscriptServices;

public class TranscriptService : ITranscriptService
{
    private readonly ITranscriptRepository _subjectRepository;
    private readonly IMapper _mapper;

    public TranscriptService(ITranscriptRepository studentRepository, IMapper mapper)
    {
        _subjectRepository = studentRepository;
        _mapper = mapper;
    }
    public IList<GetTranscriptDetail> GetTranscriptPage(SearchTranscriptModel searchTranscriptModel)
    {
        IQueryable<BangDiem> queryTranscript = _subjectRepository.GetAll();
        if (searchTranscriptModel.NamHoc != null)
        {
            queryTranscript = queryTranscript.Where(x => x.NamHoc.Equals(searchTranscriptModel.NamHoc));
        }
        var result = _mapper.ProjectTo<GetTranscriptDetail>(queryTranscript);
        return result.ToList();
    }
    public async Task<GetTranscriptDetail> CreateTranscriptAsync(CreateTranscript requestBody)
    {
        var bangDiem = _mapper.Map<BangDiem>(requestBody);
        if (bangDiem == null)
        {
            throw new Exception("Please enter the correct information!!! ");
        }
        await _subjectRepository.InsertAsync(bangDiem);
        await _subjectRepository.SaveChangesAsync();
        GetTranscriptDetail weatherDetail = _mapper.Map<GetTranscriptDetail>(bangDiem);
        return weatherDetail;
    }
}