using Define.Common;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres.Context.DBContext
{
    public class NpgsqlContext : DbContext
    {
        public DbSet<AthletesEntity> AthletesInfoEntity { get; set; }

        public NpgsqlContext(DbContextOptions<NpgsqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AthletesEntity>()
                .HasData(
                new AthletesEntity
                {
                    AthletesId = 1,
                    Username = "user1",
                    Email = "user1@example.com",
                    Password = "password1",
                    Address = "123 Main St",
                    City = "City1",
                    PostalCode = 12345,
                    ChoosenActivity = "Running",
                    Role = Roles.User
                }               
           );
            base.OnModelCreating(modelBuilder);
        }
    }
}

