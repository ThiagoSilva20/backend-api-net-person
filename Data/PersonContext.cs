using backend_api_net.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api_net.Data;

public class PersonContext : DbContext
{
    public DbSet<PersonModel> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}
