
using MyCraftHobbyApp.GCommon.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCraftHobbyApp.Data.Models
{
    public class CrochetProject : CraftProject
    {
        public CrochetProject()
        {
            Type = CraftType.Crochet;
        }

        [ForeignKey(nameof(StitchPattern))]
        public int StitchPatternId { get; set; }
        public StitchPattern StitchPattern { get; set; } = null!;
    }
}
