using Define.Common;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.Entities;
using System.Reflection.Metadata;

namespace Postgres.Context.DBContext
{
    public class NpgsqlContext : DbContext
    {
        public DbSet<AthletesEntity> AthletesInfo { get; set; }
        public DbSet<ChosenActivityEntity> ChooseActivityInfo { get; set; }
        public DbSet<MatchModelEntity> MatchModels { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        public DbSet<FileEntity> AthleteImageProfile { get; set; }

        public NpgsqlContext(DbContextOptions<NpgsqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<AthletesEntity>()
                .HasMany(e => e.ChosenActivities)
                .WithOne(e => e.AthletesEntity)
                .HasForeignKey(e => e.ChosenActivityId)
                .HasPrincipalKey(e => e.AthletesId);

            modelBuilder.Entity<ChosenActivityEntity>()
                .HasOne(e => e.AthletesEntity)
                .WithMany(e => e.ChosenActivities)
                .HasForeignKey(e => e.AthletesEntityId)
                .HasPrincipalKey(e => e.AthletesId);
        }
    }
}

