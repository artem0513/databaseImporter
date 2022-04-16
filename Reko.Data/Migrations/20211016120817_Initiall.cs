using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reko.Data.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Character = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CastId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Character = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CastId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestStars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    CreditId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestStars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AlsoKnownAs = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    IsAdultFilmStar = table.Column<bool>(type: "bit", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deathday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ParentCompanyName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ParentCompanyLogoPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvShowCreators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCreators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BackdropPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    EpisodeRunTime = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FirstAirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    InProduction = table.Column<bool>(type: "bit", nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LastAirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: true),
                    NumberOfSeasons = table.Column<int>(type: "int", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 7000, nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", maxLength: 7000, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HeTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsAdultThemed = table.Column<bool>(type: "bit", nullable: false),
                    BackdropPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 7000, nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", maxLength: 7000, nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsVideo = table.Column<bool>(type: "bit", nullable: false),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<int>(type: "int", nullable: true),
                    CollectionInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_CollectionInfos_CollectionInfoId",
                        column: x => x.CollectionInfoId,
                        principalTable: "CollectionInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosterPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsCastMembers",
                columns: table => new
                {
                    CastMembersId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsCastMembers", x => new { x.CastMembersId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsCastMembers_CastMembers_CastMembersId",
                        column: x => x.CastMembersId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsCastMembers_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsCrewMembers",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsCrewMembers", x => new { x.CrewMembersId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsCrewMembers_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsCrewMembers_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsGenres",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsGenres", x => new { x.GenresId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsGenres_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsGenres_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsKeywords",
                columns: table => new
                {
                    KeyWordsId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsKeywords", x => new { x.KeyWordsId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsKeywords_KeyWords_KeyWordsId",
                        column: x => x.KeyWordsId,
                        principalTable: "KeyWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsKeywords_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsNetworks",
                columns: table => new
                {
                    NetworksId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsNetworks", x => new { x.NetworksId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsNetworks_Networks_NetworksId",
                        column: x => x.NetworksId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsNetworks_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsProductionCompanies",
                columns: table => new
                {
                    ProductionCompaniesId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsProductionCompanies", x => new { x.ProductionCompaniesId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsProductionCompanies_ProductionCompanies_ProductionCompaniesId",
                        column: x => x.ProductionCompaniesId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsProductionCompanies_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowsTvShowCreators",
                columns: table => new
                {
                    TvShowCreatorsId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowsTvShowCreators", x => new { x.TvShowCreatorsId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowsTvShowCreators_TvShowCreators_TvShowCreatorsId",
                        column: x => x.TvShowCreatorsId,
                        principalTable: "TvShowCreators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowsTvShowCreators_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCastMembers",
                columns: table => new
                {
                    CastMembersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCastMembers", x => new { x.CastMembersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesCastMembers_CastMembers_CastMembersId",
                        column: x => x.CastMembersId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCastMembers_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCountries",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCountries", x => new { x.CountriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCrewMembers",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCrewMembers", x => new { x.CrewMembersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesCrewMembers_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCrewMembers_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesGenres",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesGenres", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesKeywords",
                columns: table => new
                {
                    KeyWordsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesKeywords", x => new { x.KeyWordsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesKeywords_KeyWords_KeyWordsId",
                        column: x => x.KeyWordsId,
                        principalTable: "KeyWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesKeywords_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesLanguages",
                columns: table => new
                {
                    LanguagesId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesLanguages", x => new { x.LanguagesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviesLanguages_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesLanguages_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesProductionCompanies",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    ProductionCompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesProductionCompanies", x => new { x.MoviesId, x.ProductionCompaniesId });
                    table.ForeignKey(
                        name: "FK_MoviesProductionCompanies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesProductionCompanies_ProductionCompanies_ProductionCompaniesId",
                        column: x => x.ProductionCompaniesId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Iso31661 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Site = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsOfficial = table.Column<bool>(type: "bit", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    TvShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    VoteCount = table.Column<int>(type: "int", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    VoteAverage = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StillPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ProductionCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EpisodesCrewMembers",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    EpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodesCrewMembers", x => new { x.CrewMembersId, x.EpisodesId });
                    table.ForeignKey(
                        name: "FK_EpisodesCrewMembers_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodesCrewMembers_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodesGuestStars",
                columns: table => new
                {
                    EpisodesId = table.Column<int>(type: "int", nullable: false),
                    GuestStarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodesGuestStars", x => new { x.EpisodesId, x.GuestStarsId });
                    table.ForeignKey(
                        name: "FK_EpisodesGuestStars_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodesGuestStars_GuestStars_GuestStarsId",
                        column: x => x.GuestStarsId,
                        principalTable: "GuestStars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodesCrewMembers_EpisodesId",
                table: "EpisodesCrewMembers",
                column: "EpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodesGuestStars_GuestStarsId",
                table: "EpisodesGuestStars",
                column: "GuestStarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CollectionInfoId",
                table: "Movies",
                column: "CollectionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCastMembers_MoviesId",
                table: "MoviesCastMembers",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCountries_MoviesId",
                table: "MoviesCountries",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCrewMembers_MoviesId",
                table: "MoviesCrewMembers",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenres_MoviesId",
                table: "MoviesGenres",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesKeywords_MoviesId",
                table: "MoviesKeywords",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesLanguages_MoviesId",
                table: "MoviesLanguages",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesProductionCompanies_ProductionCompaniesId",
                table: "MoviesProductionCompanies",
                column: "ProductionCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvShowId",
                table: "Seasons",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsCastMembers_TvShowsId",
                table: "TvShowsCastMembers",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsCrewMembers_TvShowsId",
                table: "TvShowsCrewMembers",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsGenres_TvShowsId",
                table: "TvShowsGenres",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsKeywords_TvShowsId",
                table: "TvShowsKeywords",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsNetworks_TvShowsId",
                table: "TvShowsNetworks",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsProductionCompanies_TvShowsId",
                table: "TvShowsProductionCompanies",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowsTvShowCreators_TvShowsId",
                table: "TvShowsTvShowCreators",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_MovieId",
                table: "Videos",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TvShowId",
                table: "Videos",
                column: "TvShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodesCrewMembers");

            migrationBuilder.DropTable(
                name: "EpisodesGuestStars");

            migrationBuilder.DropTable(
                name: "MoviesCastMembers");

            migrationBuilder.DropTable(
                name: "MoviesCountries");

            migrationBuilder.DropTable(
                name: "MoviesCrewMembers");

            migrationBuilder.DropTable(
                name: "MoviesGenres");

            migrationBuilder.DropTable(
                name: "MoviesKeywords");

            migrationBuilder.DropTable(
                name: "MoviesLanguages");

            migrationBuilder.DropTable(
                name: "MoviesProductionCompanies");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "TvShowsCastMembers");

            migrationBuilder.DropTable(
                name: "TvShowsCrewMembers");

            migrationBuilder.DropTable(
                name: "TvShowsGenres");

            migrationBuilder.DropTable(
                name: "TvShowsKeywords");

            migrationBuilder.DropTable(
                name: "TvShowsNetworks");

            migrationBuilder.DropTable(
                name: "TvShowsProductionCompanies");

            migrationBuilder.DropTable(
                name: "TvShowsTvShowCreators");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "GuestStars");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "CastMembers");

            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "KeyWords");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "ProductionCompanies");

            migrationBuilder.DropTable(
                name: "TvShowCreators");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "CollectionInfos");

            migrationBuilder.DropTable(
                name: "TvShows");
        }
    }
}
