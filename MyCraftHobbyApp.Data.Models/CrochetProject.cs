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

        [ForeignKey(nameof(StitchPattern))]
        public int StitchPatternId { get; set; }

        [Required]
        public StitchPattern StitchPattern { get; set; } = null!;

        [ForeignKey(nameof(ProjectType))]
        public int ProjectTypeId { get; set; }

        [Required]
        public ProjectType ProjectType { get; set; } = null!;
    }
}
