using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Repositories.SubjectRepositories;

public class SubjectRepository : BaseRepository<MonHoc>, ISubjectRepository
{
    public SubjectRepository(DbContext context) : base(context)
    {
    }

    public SubjectRepository(DbContext context, DbSet<MonHoc> dbsetExist) : base(context, dbsetExist)
    {
    }
}