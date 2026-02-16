
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCraftHobbyApp.Data.Models
{
    public class CrochetProject : CraftProject
    {
        [ForeignKey(nameof(StitchPattern))]
        public int StitchPatternId { get; set; }
        public StitchPattern StitchPattern { get; set; } = null!;
    }
}
