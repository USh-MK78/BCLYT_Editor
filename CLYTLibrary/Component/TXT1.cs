using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class TXT1
    {
        public char[] TXT1_Header { get; set; }
        public int TXT1_Size { get; set; }

        public byte UnknownByteData0 { get; set; }
        public byte UnknownByteData1 { get; set; }
        public byte UnknownByteData2 { get; set; }
        public byte UnknownByteData3 { get; set; }

        public char[] TXT1NameCharArray { get; set; } //24 byte

        public float UnknownFloatData0 { get; set; }
        public float UnknownFloatData1 { get; set; }
        public float UnknownFloatData2 { get; set; }
        public float UnknownFloatData3 { get; set; }
        public float UnknownFloatData4 { get; set; }
        public float UnknownFloatData5 { get; set; }
        public float UnknownFloatData6 { get; set; }
        public float UnknownFloatData7 { get; set; }
        public float UnknownFloatData8 { get; set; }
        public float UnknownFloatData9 { get; set; }


        public short UnknownShortData1 { get; set; }
        public short UnknownShortData2 { get; set; }

        public TXT1()
        {
            TXT1_Header = "txt1".ToArray();
        }
    }
}
