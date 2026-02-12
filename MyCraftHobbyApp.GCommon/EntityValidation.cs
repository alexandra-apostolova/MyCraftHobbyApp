using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.GCommon
{
    public static class EntityValidation
    {
        public const int ProjectNameMinValue = 2;
        public const int ProjectNameMaxValue = 50;
        public const int ProjectDescriptionMaxValue = 1000;
        public const int ProjectImgUrlMinValue = 9;
        public const int ProjectImgUrlMaxValue = 200;

        public const int ProjectTypeNameMinValue = 2;
        public const int ProjectTypeNameMaxValue = 50;

        public const int StitchPatternNameMinValue = 3;
        public const int StitchPatternNameMaxValue = 20;
    }
}
