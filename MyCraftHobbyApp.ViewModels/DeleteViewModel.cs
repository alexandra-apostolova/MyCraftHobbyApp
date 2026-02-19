
namespace MyCraftHobbyApp.ViewModels
{
    public class DeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CraftType { get; set; } = null!;
        public string CraftName =>
            CraftType == "KnitProject" ? "Knit" : "Crochet";
    }
}
