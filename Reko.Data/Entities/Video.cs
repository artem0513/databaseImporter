using System;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Video : IMappableEntity<Video, VideoDto, string>
    {
        [MaxLength(60)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Iso6391 { get; set; }

        [MaxLength(50)]
        public string Iso31661 { get; set; }

        [MaxLength(700)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Key { get; set; }

        [MaxLength(2048)]
        public string Site { get; set; }

        public int? Size { get; set; }

        [MaxLength(400)]
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