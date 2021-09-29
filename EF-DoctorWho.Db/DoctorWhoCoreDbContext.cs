using System;
using Microsoft.EntityFrameworkCore;


namespace EF_DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {

        public DbSet<tblEnemy> tblEnemy { get; set; }
        public DbSet<tblAuthor> tblAuthor { get; set; }
        public DbSet<tblCompanion> tblCompanion { get; set; }
        public DbSet<tblDoctor> tblDoctor { get; set; }
        public DbSet<tblEpisode> tblEpisode { get; set; }
        public DbSet<tblEpisodeCompanion> tblEpisodeCompanion { get; set; }
        public DbSet<tblEpisodeEnemy> tblEpisodeEnemy { get; set; }
        public DbSet<EpisodesView> viewEpisodes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=localhost,1433; Database=DoctorWhoCore;User=sa; Password=NaserSQL123");
        }


        public string CompanionsFunctionResult(int customerId)
                => throw new NotSupportedException();

        public string EnemiesFunctionResult(int customerId)
                => throw new NotSupportedException();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodesView>()
                        .HasNoKey()
                        .ToView("viewEpisodes");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                        .GetMethod(nameof(CompanionsFunctionResult), new[] { typeof(int) }))
                        .HasName("fnCompanions");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                        .GetMethod(nameof(EnemiesFunctionResult), new[] { typeof(int) }))
                        .HasName("fnEnemies");


        }



    }
}