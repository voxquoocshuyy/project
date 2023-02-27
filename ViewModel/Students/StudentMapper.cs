using AutoMapper;
using webapi.Entities;
using webapi.Students;

namespace webapi.ViewModel.Students;

public static class StudentMapper
{
    public static void ConfigStudent(this IMapperConfigurationExpression configuration)
    {
        configuration.CreateMap<HocVien, GetStudentDetail>().ReverseMap();
        configuration.CreateMap<HocVien, CreateStudent>().ReverseMap();
        configuration.CreateMap<HocVien, SearchStudentModel>().ReverseMap();
    }
}