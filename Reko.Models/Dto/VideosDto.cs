using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class VideosDto : BaseDto<int>
    {
        [DataMember(Name = "results")]
        public IEnumerable<VideoDto> Videos { get; set; }
    }
}