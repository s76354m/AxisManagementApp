using Microsoft.EntityFrameworkCore;
using AxisManagementApp.Models;  // Make sure this namespace is correct

namespace AxisManagementApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CSEXPProjectTranslation> ProjectTranslations { get; set; }
        public DbSet<YLineTranslation> YLineTranslations { get; set; }
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<ServiceAreaStage> ServiceAreaStages { get; set; }
        public DbSet<ProjectNote> ProjectNotes { get; set; }
        public DbSet<CompetitorTranslation> CompetitorTranslations { get; set; }
        public DbSet<SelPLProduct> SelPLProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSEXPProjectTranslation>().ToTable("CS_EXP_Project_Translation");
            modelBuilder.Entity<YLineTranslation>().ToTable("CS_EXP_YLine_Translation");
            modelBuilder.Entity<ServiceArea>().ToTable("CS_EXP_zTrxServiceArea");
            modelBuilder.Entity<ServiceAreaStage>().ToTable("CS_EXP_zTrxServiceArea_Stage");
            modelBuilder.Entity<ProjectNote>().ToTable("CS_EXP_ProjectNotes");
            modelBuilder.Entity<CompetitorTranslation>().ToTable("CS_EXP_Competitor_Translation");
            modelBuilder.Entity<SelPLProduct>().ToTable("CS_EXP_Sel_PLProducts");
        }
    }
}