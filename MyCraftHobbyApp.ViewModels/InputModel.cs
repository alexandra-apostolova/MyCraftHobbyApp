using MyCraftHobbyApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MyCraftHobbyApp.GCommon.EntityValidation;
namespace MyCraftHobbyApp.ViewModels
{
    public class InputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectNameMaxValue)]
        [MinLength(ProjectNameMinValue)]
        public string Name { get; set; } = null!;

        [MaxLength(ProjectDescriptionMaxValue)]
        public string? Description { get; set; }

        [MaxLength(ProjectImgUrlMaxValue)]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImgUrl { get; set; }

        [Required]
        public int ProjectTypeId { get; set; }

        public IEnumerable<ProjectType>? ProjectTypes { get; set; }

        [Required]
        public int UserId { get; set; }
        public string CraftType { get; set; } = null!;
        public string CraftName =>
            CraftType == "KnitProject" ? "Knit" : "Crochet";
    }
}
