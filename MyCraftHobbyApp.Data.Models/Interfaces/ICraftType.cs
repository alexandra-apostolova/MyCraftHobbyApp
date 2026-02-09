using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.Data.Models.Interfaces
{
    public interface ICraftType
    {
        int Id { get; }
        string Name { get; }
        string? ImgUrl { get; }
        ICollection<ProjectType> ProjectTypes { get; }
    }
}
