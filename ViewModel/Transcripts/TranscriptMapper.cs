using AutoMapper;
using webapi.Entities;
using webapi.Transcripts;

namespace webapi.ViewModel.Transcripts;

public static class TranscriptMapper
{
    public static void ConfigTranscript(this IMapperConfigurationExpression configuration)
    {
        configuration.CreateMap<BangDiem, GetTranscriptDetail>().ReverseMap();
        configuration.CreateMap<BangDiem, CreateTranscript>().ReverseMap();
        configuration.CreateMap<BangDiem, SearchTranscriptModel>().ReverseMap();
    }
}