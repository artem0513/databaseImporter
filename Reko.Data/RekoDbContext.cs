using Microsoft.EntityFrameworkCore;
using Reko.Data.Entities;

namespace Reko.Data
{
    public sealed class RekoDbContext : DbContext
    {
        public DbSet<CollectionInfo> CollectionInfos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GuestStar> GuestStars { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<TvShowCreator> TvShowCreators { get; set; }
        public DbSet<Video> Videos { get; set; }

        public RekoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasOne(x => x.CollectionInfo).WithMany(x => x.Movies).HasForeignKey(x => x.CollectionInfoId);
                b.HasMany(x => x.Genres).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesGenres"));
                b.HasMany(x => x.ProductionCompanies).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesProductionCompanies"));
                b.HasMany(x => x.Countries).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesCountries"));
                b.HasMany(x => x.Languages).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesLanguages"));
                b.HasMany(x => x.KeyWords).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesKeywords"));
                b.HasMany(x => x.CastMembers).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesCastMembers"));
                b.HasMany(x => x.CrewMembers).WithMany(x => x.Movies).UsingEntity(x => x.ToTable("MoviesCrewMembers"));
            });

            modelBuilder.Entity<TvShow>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasMany(x => x.TvShowCreators).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsTvShowCreators"));
                b.HasMany(x => x.Genres).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsGenres"));
                b.HasMany(x => x.ProductionCompanies).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsProductionCompanies"));
                b.HasMany(x => x.Networks).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsNetworks"));
                b.HasMany(x => x.KeyWords).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsKeywords"));
                b.HasMany(x => x.Seasons).WithOne(x => x.TvShow).HasForeignKey(x => x.TvShowId);
                b.HasMany(x => x.CrewMembers).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsCrewMembers"));
                b.HasMany(x => x.CastMembers).WithMany(x => x.TvShows).UsingEntity(x => x.ToTable("TvShowsCastMembers"));
            });

            modelBuilder.Entity<Video>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasOne(x => x.TvShow).WithMany(x => x.Videos).HasForeignKey(x => x.TvShowId);
                b.HasOne(x => x.Movie).WithMany(x => x.Videos).HasForeignKey(x => x.MovieId);
            });

            modelBuilder.Entity<TvShowCreator>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuestStar>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Episode>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasMany(x => x.GuestStars).WithMany(x => x.Episodes).UsingEntity(x => x.ToTable("EpisodesGuestStars"));
                b.HasMany(x => x.CrewMembers).WithMany(x => x.Episodes).UsingEntity(x => x.ToTable("EpisodesCrewMembers"));
            });

            modelBuilder.Entity<Season>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasMany(x => x.Episodes).WithOne(x => x.Season).HasForeignKey(x => x.SeasonId);
            });

            modelBuilder.Entity<ProductionCompany>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Network>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<KeyWord>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Genre>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Country>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CollectionInfo>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CastMember>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CrewMember>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}