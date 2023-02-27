using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Repositories.TranscriptRepositories;

public class TranscriptRepository: BaseRepository<BangDiem>, ITranscriptRepository
{
    public TranscriptRepository(DbContext context) : base(context)
    {
    }

    public TranscriptRepository(DbContext context, DbSet<BangDiem> dbsetExist) : base(context, dbsetExist)
    {
    }
}