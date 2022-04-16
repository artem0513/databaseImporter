using System;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Video : IMappableEntity<Video, VideoDto, string>
    {
        public string Id { get; set; }
        public string Iso6391 { get; set; }
        public string Iso31661 { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Site { get; set; }
        public int? Size { get; set; }
        public string Type { get; set; }
        public bool IsOfficial { get; set; }
        public DateTime? PublishedAt { get; set; }
        public Movie Movie { get; set; }
        public int? MovieId { get; set; }
        public int? TvShowId { get; set; }
        public TvShow TvShow { get; set; }

        public VideoDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<VideoDto>(this);
        }

        public Video FromDto(VideoDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}