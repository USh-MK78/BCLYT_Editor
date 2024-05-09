using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class PAS1
    {
        public char[] PAS1_Header { get; set; }
        public int PAS1_Size { get; set; }

        public void ReadPAS1(BinaryReader br, byte[] BOM)
        {
            //long PAS1_Pos = br.BaseStream.Position;

            PAS1_Header = br.ReadChars(4);
            if (new string(PAS1_Header) != "pas1") throw new Exception("不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            PAS1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
        }

        public void WritePAS1(BinaryWriter bw)
        {
            bw.Write(PAS1_Header);
            bw.Write(GetSize());
        }

        public int GetSize()
        {
            return PAS1_Header.Length + sizeof(int);
        }

        public PAS1 Default()
        {
            return new PAS1 { PAS1_Header = "pas1".ToCharArray(), PAS1_Size = GetSize() };
        }

        public PAS1()
        {
            PAS1_Header = "pas1".ToCharArray();
            PAS1_Size = 0;
        }
    }
}
