using CascadingDropdownLists.Models;
using Microsoft.EntityFrameworkCore;

namespace CascadingDropdownLists.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CourseLevel> CourseLevels { get; set; } = default!;
    public DbSet<Lesson> Lessons { get; set; } = default!;
}
