using MyCraftHobbyApp.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MyCraftHobbyApp.GCommon.EntityValidation;

namespace MyCraftHobbyApp.Data.Models
{
    public class CrochetProject : ICraftType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectNameMaxValue)]
        public string Name { get; set; } = null!;

        [MaxLength(ProjectImgUrlMaxValue)]
        public string? ImgUrl { get; set; }

        [ForeignKey(nameof(StitchPatterns))]
        public int StitchPatternId { get; set; }
        public virtual ICollection<StitchPattern> StitchPatterns { get; set; } 
            = new List<StitchPattern>();

        [ForeignKey(nameof(ProjectTypes))]
        public int ProjectTypeId { get; set; }
        public virtual ICollection<ProjectType> ProjectTypes { get; set; }
            = new List<ProjectType>();
    }
}
