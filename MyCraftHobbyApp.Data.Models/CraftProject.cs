using MyCraftHobbyApp.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MyCraftHobbyApp.GCommon.EntityValidation;

namespace MyCraftHobbyApp.Data.Models
{
    public abstract class CraftProject : ICraftType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectNameMaxValue)]
        public string Name { get; set; } = null!;

        [MaxLength(ProjectDescriptionMaxValue)]
        public string? Description { get; set; }

        [MaxLength(ProjectImgUrlMaxValue)]
        public string? ImgUrl { get; set; }

        [ForeignKey(nameof(ProjectType))]
        public int ProjectTypeId { get; set; }

        [Required]
        public ProjectType ProjectType { get; set; } = null!;

        public ICollection<UserProject> UserProjects { get; set; }
                = new HashSet<UserProject>();

    }
}
