using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework
{
    public static class GenreFactory
    {
        public static GenreDto Action()
            => new GenreDto {Id = 28, Name = "Action"};

        public static GenreDto Adventure()
            => new GenreDto {Id = 12, Name = "Adventure"};

        public static GenreDto ActionAndAdventure()
            => new GenreDto {Id = 10759, Name = "Action & Adventure"};

        public static GenreDto Animation()
            => new GenreDto {Id = 16, Name = "Animation"};

        public static GenreDto Comedy()
            => new GenreDto {Id = 35, Name = "Comedy"};

        public static GenreDto Crime()
            => new GenreDto {Id = 80, Name = "Crime"};

        public static GenreDto Drama()
            => new GenreDto {Id = 18, Name = "Drama"};

        public static GenreDto Documentary()
            => new GenreDto {Id = 99, Name = "Documentary"};

        public static GenreDto Family()
            => new GenreDto {Id = 10751, Name = "Family"};

        public static GenreDto Fantasy()
            => new GenreDto {Id = 14, Name = "Fantasy"};

        public static GenreDto History()
            => new GenreDto {Id = 36, Name = "History"};

        public static GenreDto Horror()
            => new GenreDto {Id = 27, Name = "Horror"};

        public static GenreDto Kids()
            => new GenreDto {Id = 10762, Name = "Kids"};

        public static GenreDto Music()
            => new GenreDto {Id = 10402, Name = "Music"};

        public static GenreDto Mystery()
            => new GenreDto {Id = 9648, Name = "Mystery"};

        public static GenreDto News()
            => new GenreDto {Id = 10763, Name = "News"};

        public static GenreDto Reality()
            => new GenreDto {Id = 10764, Name = "Reality"};

        public static GenreDto Romance()
            => new GenreDto {Id = 10749, Name = "Romance"};

        public static GenreDto ScienceFiction()
            => new GenreDto {Id = 878, Name = "Science Fiction"};

        public static GenreDto SciFiAndFantasy()
            => new GenreDto {Id = 10765, Name = "Sci-Fi & Fantasy"};

        public static GenreDto Soap()
            => new GenreDto {Id = 10766, Name = "Soap"};

        public static GenreDto Talk()
            => new GenreDto {Id = 10767, Name = "Talk"};

        public static GenreDto Thriller()
            => new GenreDto {Id = 53, Name = "Thriller"};

        public static GenreDto TvMovie()
            => new GenreDto {Id = 10770, Name = "TV Movie"};

        public static GenreDto War()
            => new GenreDto {Id = 10752, Name = "War"};

        public static GenreDto WarAndPolitics()
            => new GenreDto {Id = 10768, Name = "War & Politics"};

        public static GenreDto Western()
            => new GenreDto {Id = 37, Name = "Western"};

        public static IReadOnlyList<GenreDto> GetAll()
            => LazyAll.Value;


        private static readonly Lazy<IReadOnlyList<GenreDto>> LazyAll = new Lazy<IReadOnlyList<GenreDto>>(() =>
        {
            var all = typeof(GenreFactory)
                .GetTypeInfo()
                .DeclaredMethods
                .Where(x => x.IsStatic)
                .Where(x => x.IsPublic)
                .Where(x => x.ReturnType == typeof(GenreDto))
                .Select(x => (GenreDto) x.Invoke(null, null))
                .ToList();

            return all.AsReadOnly();
        });
    }
}