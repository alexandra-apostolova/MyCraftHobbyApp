using System.ComponentModel.DataAnnotations;
using static MyCraftHobbyApp.GCommon.EntityValidation;

namespace MyCraftHobbyApp.Data.Models
{
    public class ProjectType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectTypeNameMaxValue)]
        public string Name { get; set; } = null!;
    }
}
