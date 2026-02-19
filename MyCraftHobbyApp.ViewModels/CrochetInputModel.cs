
using MyCraftHobbyApp.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyCraftHobbyApp.ViewModels
{
    public class CrochetInputModel : InputModel
    {
        [Required]
        public int StitchPatternId { get; set; }
        public IEnumerable<StitchPattern>? StitchPatterns { get; set; }
    }
}
