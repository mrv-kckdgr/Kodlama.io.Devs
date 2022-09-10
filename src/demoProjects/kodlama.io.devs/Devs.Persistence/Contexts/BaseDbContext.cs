using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguageEntity> ProgrammingLanguages { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguageEntity>(x =>
            {
                x.ToTable("ProgrammingLanguages").HasKey(y => y.Id);
                x.Property(z => z.Id).HasColumnName("Id");
                x.Property(z => z.Name).HasColumnName("Name");
            });

            ProgrammingLanguageEntity[] programmingLanguageEntitiySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguageEntity>().HasData(programmingLanguageEntitiySeeds);
        }


    }
}
