using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary
{
    internal class CLYT_Enum
    {
        /// <summary>
        /// 0x36
        /// </summary>
        public enum Enlarge
        {
            Near_Clamp_U = 0,
            Near_Repeat_U = 1,
            Near_Mirror_U = 2,
            Linear_Clamp_U = 4,
            Linear_Repeat_U = 5,
            Linear_Mirror_U = 6
        }

        /// <summary>
        /// 0x37
        /// </summary>
        public enum Minimize
        {
            Near_Clamp_V = 0,
            Near_Repeat_V = 1,
            Near_Mirror_V = 2,
            Linear_Clamp_V = 4,
            Linear_Repeat_V = 5,
            Linear_Mirror_V = 6
        }

        /// <summary>
        /// String Layout Position Type (0x54) 
        /// </summary>
        public enum StringLayoutPositionType
        {
            Left_Top = 0,
            Center_Top = 1,
            Right_Top = 2,
            Center_Left = 3,
            Center = 4,
            Center_Right = 5,
            Left_Bottom = 6,
            Center_Bottom = 7,
            Right_Bottom = 8
        }

        /// <summary>
        /// String Alignment Type (0x55)
        /// </summary>
        public enum StringAlignmentType
        {
            None = 0,
            Left = 1,
            Center = 2,
            Right = 3
        }
    }
}
