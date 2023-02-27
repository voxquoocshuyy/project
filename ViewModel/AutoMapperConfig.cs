using AutoMapper;
using webapi.ViewModel.Students;
using webapi.ViewModel.Subjects;
using webapi.ViewModel.Transcripts;

namespace webapi;

public static class AutoMapperConfig
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.ConfigStudent();
            mc.ConfigSubject();
            mc.ConfigTranscript();
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}