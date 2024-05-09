using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary
{
    public class CLYT_Math
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StringLength">StringLength</param>
        /// <returns>Padding char array</returns>
        public static char[] GenPadding(int StringLength)
        {
            List<char> PaddingChars = new List<char>();
            if (StringLength % 4 == 0) PaddingChars = Enumerable.Repeat('\0', 4).ToList();
            else
            {
                PaddingChars = Enumerable.Repeat('\0', 4 - (StringLength % 4)).ToList();
            }

            return PaddingChars.ToArray();
        }
    }
}
