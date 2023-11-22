using ChooseActivity.Info.Model;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MatchActivity.Info.Model
{
    public record MatchModelInfo
    {
        [Required]
        public bool LikeTheUser { get; set; }

        [Required]
        public IEnumerable<ChooseActivityInfo> ChooseActivityInfo { get; set; }
    }
}
