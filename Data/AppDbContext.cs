using Microsoft.EntityFrameworkCore;
using StudentManagementDotNet.Models;

namespace StudentManagementDotNet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Student> Students => Set<Student>();
}
