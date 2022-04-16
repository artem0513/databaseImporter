using System;
using System.Collections.Generic;
using System.Linq;
using Reko.Contracts.Containers;
using Reko.Models.Dto;

namespace Reko.Business.Containers
{
    public sealed class UniqueTvShowDataContainer : UniqueContainerBase<TVShowDto>, IUniqueTvShowDataContainer
    {
        public ICollection<EpisodeDto> Episodes { get; private set; }
        public ICollection<GuestStarDto> GuestStars { get; private set; }
        public ICollection<TVShowCreatorDto> TVShowCreators { get; private set; }
        public ICollection<TVShowCreatorDto> CreatedBy { get; private set; }
        public ICollection<NetworkDto> Networks { get; private set; }
        public ICollection<SeasonDto> Seasons { get; private set; }

        protected override void RemoveDuplicatesForEachElements(ICollection<TVShowDto> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            foreach (var tvShowDto in data)
            {
                if (tvShowDto.Credit != null)
                {
                    tvShowDto.Credit.CrewMembers = tvShowDto.Credit.CrewMembers.Distinct();
                    tvShowDto.Credit.CastMembers = tvShowDto.Credit.CastMembers.Distinct();
                }

                if (tvShowDto.Videos != null)
                {
                    tvShowDto.Videos.Videos = tvShowDto.Videos.Videos.Distinct();
                }

                tvShowDto.Seasons = tvShowDto.Seasons.Distinct().ToArray();
                foreach (var seasonDto in tvShowDto.Seasons)
                {
                    seasonDto.Episodes = seasonDto.Episodes.Distinct().ToArray();
                    foreach (var seasonDtoEpisode in seasonDto.Episodes)
                    {
                        seasonDtoEpisode.GuestStars = seasonDtoEpisode.GuestStars.Distinct();
                        seasonDtoEpisode.CrewMembers = seasonDtoEpisode.CrewMembers.Distinct();
                    }
                }

                tvShowDto.ProductionCompanies = tvShowDto.ProductionCompanies.Distinct();
                tvShowDto.Networks = tvShowDto.Networks.Distinct();
                tvShowDto.Genres = tvShowDto.Genres.Distinct();
                tvShowDto.Keywords = tvShowDto.Keywords.Distinct();
                tvShowDto.CreatedBy = tvShowDto.CreatedBy.Distinct();
            }
        }

        protected override void SetUniqueData(ICollection<TVShowDto> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            CreatedBy = data.SelectMany(x => x.CreatedBy).Distinct().ToArray();
            Seasons = data.SelectMany(x => x.Seasons).Distinct().ToArray();
            Episodes = Seasons.SelectMany(x => x.Episodes).Distinct().ToArray();
            ProductionCompanies = data.SelectMany(x => x.ProductionCompanies).Distinct().ToArray();
            Networks = data.SelectMany(x => x.Networks).Distinct().ToArray();
            TVShowCreators = data.SelectMany(x => x.CreatedBy).Distinct().ToArray();
            CrewMembers = data.SelectMany(x => x.Credit?.CrewMembers)
                .Concat(Episodes.SelectMany(x => x.CrewMembers)).Distinct().ToArray();
            CastMembers = data.SelectMany(x => x.Credit?.CastMembers).Distinct().ToArray();
            GuestStars = Episodes.SelectMany(x => x.GuestStars).Distinct().ToArray();
            Genres = data.SelectMany(x => x.Genres).Distinct().ToArray();
            Videos = data.SelectMany(x => x.Videos?.Videos).Distinct().ToArray();
            Keywords = data.SelectMany(x => x.Keywords).Distinct().ToArray();
        }
    }
}