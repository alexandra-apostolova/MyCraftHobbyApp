using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.GCommon.Enums;
using System.ComponentModel.DataAnnotations;
using static MyCraftHobbyApp.GCommon.EntityValidation;
namespace MyCraftHobbyApp.ViewModels
{
    public class InputModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose a name.")]
        [MaxLength(ProjectNameMaxValue)]
        [MinLength(ProjectNameMinValue)]
        public string Name { get; set; } = null!;

        [MaxLength(ProjectDescriptionMaxValue)]
        public string? Description { get; set; }

        [MaxLength(ProjectImgUrlMaxValue)]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImgUrl { get; set; }

        [Required(ErrorMessage = "Please select a project type.")]
        public int ProjectTypeId { get; set; }

        public IEnumerable<ProjectType>? ProjectTypes { get; set; }

        [Required]
        public int UserId { get; set; }
        public CraftType CraftType { get; set; }
        public string CraftName =>
            CraftType.ToString();
    }
}
