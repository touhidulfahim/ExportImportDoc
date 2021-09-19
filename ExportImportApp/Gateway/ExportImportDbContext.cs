using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExportImportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExportImportApp.Gateway
{
    public class ExportImportDbContext : DbContext
    {
        public ExportImportDbContext()
        {
            
        }
        
        public ExportImportDbContext(DbContextOptions<ExportImportDbContext> options) : base(options)
        {

        }

        public virtual DbSet<CountryModel> CountryEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CountryModel>().ToTable("tb_Countries");
        }
    }
}
