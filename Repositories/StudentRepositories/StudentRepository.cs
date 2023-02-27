using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Repositories.StudentRepositories;

public class StudentRepository : BaseRepository<HocVien>, IStudentRepository
{
    public StudentRepository(DbContext context) : base(context)
    {
    }

    public StudentRepository(DbContext context, DbSet<HocVien> dbsetExist) : base(context, dbsetExist)
    {
    }
}
