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
        modelBuilder.Entity<ApplicationFileEntity>()
    .HasData(
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "hiking.jpg",
            SportId = 1,
            SportName = "hiking"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "basketball.jpg",
            SportId = 2,
            SportName = "basketball"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "chess.jpg",
            SportId = 3,
            SportName = "chess"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "bicycle.jpg",
            SportId = 4,
            SportName = "bicycle"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "billiards.jpg",
            SportId = 5,
            SportName = "billiards"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "roadtrip.jpg",
            SportId = 6,
            SportName = "roadtrip"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "running.jpg",
            SportId = 7,
            SportName = "running"
        },
        new ApplicationFileEntity
        {
            ContentType = "application/json",
            FileName = "tennis.jpg",
            SportId = 8,
            SportName = "tennis"
        }
    );
    }
}

