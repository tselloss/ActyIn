using Microsoft.EntityFrameworkCore;
using Postgres.Context.Entities;

namespace Postgres.Context.DBContext;

public class NpgsqlContext : DbContext
{
    public DbSet<AthletesEntity> AthletesInfo { get; set; }
    public DbSet<ChosenActivityEntity> ChooseActivityInfo { get; set; }
    public DbSet<MatchModelEntity> MatchModels { get; set; }
    public DbSet<BookingEntity> Bookings { get; set; }

    public DbSet<FileEntity> AthleteImageProfile { get; set; }
    public DbSet<ApplicationFileEntity> ApplicationImages { get; set; }

    public NpgsqlContext(DbContextOptions<NpgsqlContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

