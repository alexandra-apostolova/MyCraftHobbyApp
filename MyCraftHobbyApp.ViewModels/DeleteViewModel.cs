
using MyCraftHobbyApp.GCommon.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class DeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CraftType CraftType { get; set; }
        public string CraftName =>
            CraftType.ToString();
    }
}
