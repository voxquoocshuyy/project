using AutoMapper;
using webapi.Entities;

namespace webapi.ViewModel.Subjects;

public static class SubjectMapper
{
    public static void ConfigSubject(this IMapperConfigurationExpression configuration)
    {
        configuration.CreateMap<MonHoc, GetSubjectDetail>().ReverseMap();
        configuration.CreateMap<MonHoc, CreateSubject>().ReverseMap();
        configuration.CreateMap<MonHoc, SearchSubjectModel>().ReverseMap();
    }
}