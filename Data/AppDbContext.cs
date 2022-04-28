using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}