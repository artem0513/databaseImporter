using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reko.Data.Migrations
{
    public partial class AddEntities : Migration
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
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlsoKnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdultFilmStar = table.Column<bool>(type: "bit", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deathday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCompanyLogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeRunTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InProduction = table.Column<bool>(type: "bit", nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: true),
                    NumberOfSeasons = table.Column<int>(type: "int", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdultThemed = table.Column<bool>(type: "bit", nullable: false),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "TvShowCastMember",
                columns: table => new
                {
                    CastMembersId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCastMember", x => new { x.CastMembersId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowCastMember_CastMembers_CastMembersId",
                        column: x => x.CastMembersId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowCastMember_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowCrewMember",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCrewMember", x => new { x.CrewMembersId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowCrewMember_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowCrewMember_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowGenre",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowGenre", x => new { x.GenresId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowGenre_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowKeyword",
                columns: table => new
                {
                    KeyWordsId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowKeyword", x => new { x.KeyWordsId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowKeyword_KeyWords_KeyWordsId",
                        column: x => x.KeyWordsId,
                        principalTable: "KeyWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowKeyword_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowNetwork",
                columns: table => new
                {
                    NetworksId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowNetwork", x => new { x.NetworksId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowNetwork_Networks_NetworksId",
                        column: x => x.NetworksId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowNetwork_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowProductionCompany",
                columns: table => new
                {
                    ProductionCompaniesId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowProductionCompany", x => new { x.ProductionCompaniesId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowProductionCompany_ProductionCompanies_ProductionCompaniesId",
                        column: x => x.ProductionCompaniesId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowProductionCompany_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShowTvShowCreator",
                columns: table => new
                {
                    TvShowCreatorsId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowTvShowCreator", x => new { x.TvShowCreatorsId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowTvShowCreator_TvShowCreators_TvShowCreatorsId",
                        column: x => x.TvShowCreatorsId,
                        principalTable: "TvShowCreators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowTvShowCreator_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCastMember",
                columns: table => new
                {
                    CastMembersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCastMember", x => new { x.CastMembersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieCastMember_CastMembers_CastMembersId",
                        column: x => x.CastMembersId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCastMember_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCountry",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCountry", x => new { x.CountriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieCountry_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCountry_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCrewMember",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCrewMember", x => new { x.CrewMembersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieCrewMember_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCrewMember_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieKeyword",
                columns: table => new
                {
                    KeyWordsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieKeyword", x => new { x.KeyWordsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieKeyword_KeyWords_KeyWordsId",
                        column: x => x.KeyWordsId,
                        principalTable: "KeyWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieKeyword_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguage",
                columns: table => new
                {
                    LanguagesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguage", x => new { x.LanguagesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProductionCompany",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    ProductionCompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProductionCompany", x => new { x.MoviesId, x.ProductionCompaniesId });
                    table.ForeignKey(
                        name: "FK_MovieProductionCompany_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProductionCompany_ProductionCompanies_ProductionCompaniesId",
                        column: x => x.ProductionCompaniesId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StillPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "EpisodeCrewMember",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false),
                    EpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeCrewMember", x => new { x.CrewMembersId, x.EpisodesId });
                    table.ForeignKey(
                        name: "FK_EpisodeCrewMember_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeCrewMember_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeGuestStar",
                columns: table => new
                {
                    EpisodesId = table.Column<int>(type: "int", nullable: false),
                    GuestStarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeGuestStar", x => new { x.EpisodesId, x.GuestStarsId });
                    table.ForeignKey(
                        name: "FK_EpisodeGuestStar_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeGuestStar_GuestStars_GuestStarsId",
                        column: x => x.GuestStarsId,
                        principalTable: "GuestStars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCrewMember_EpisodesId",
                table: "EpisodeCrewMember",
                column: "EpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeGuestStar_GuestStarsId",
                table: "EpisodeGuestStar",
                column: "GuestStarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCastMember_MoviesId",
                table: "MovieCastMember",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountry_MoviesId",
                table: "MovieCountry",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrewMember_MoviesId",
                table: "MovieCrewMember",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MoviesId",
                table: "MovieGenre",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyword_MoviesId",
                table: "MovieKeyword",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_MoviesId",
                table: "MovieLanguage",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProductionCompany_ProductionCompaniesId",
                table: "MovieProductionCompany",
                column: "ProductionCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CollectionInfoId",
                table: "Movies",
                column: "CollectionInfoId",
                unique: true,
                filter: "[CollectionInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvShowId",
                table: "Seasons",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowCastMember_TvShowsId",
                table: "TvShowCastMember",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowCrewMember_TvShowsId",
                table: "TvShowCrewMember",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowGenre_TvShowsId",
                table: "TvShowGenre",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowKeyword_TvShowsId",
                table: "TvShowKeyword",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowNetwork_TvShowsId",
                table: "TvShowNetwork",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowProductionCompany_TvShowsId",
                table: "TvShowProductionCompany",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowTvShowCreator_TvShowsId",
                table: "TvShowTvShowCreator",
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
                name: "EpisodeCrewMember");

            migrationBuilder.DropTable(
                name: "EpisodeGuestStar");

            migrationBuilder.DropTable(
                name: "MovieCastMember");

            migrationBuilder.DropTable(
                name: "MovieCountry");

            migrationBuilder.DropTable(
                name: "MovieCrewMember");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieKeyword");

            migrationBuilder.DropTable(
                name: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "MovieProductionCompany");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "TvShowCastMember");

            migrationBuilder.DropTable(
                name: "TvShowCrewMember");

            migrationBuilder.DropTable(
                name: "TvShowGenre");

            migrationBuilder.DropTable(
                name: "TvShowKeyword");

            migrationBuilder.DropTable(
                name: "TvShowNetwork");

            migrationBuilder.DropTable(
                name: "TvShowProductionCompany");

            migrationBuilder.DropTable(
                name: "TvShowTvShowCreator");

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
