
using static MyCraftHobbyApp.GCommon.EntityValidation;
using System.ComponentModel.DataAnnotations;

namespace MyCraftHobbyApp.Data.Models
{
    public class StitchPattern
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StitchPatternNameMaxValue)]
        public string Name { get; set; } = null!;
    }
}
