using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class PAE1
    {
        public char[] PAE1_Header { get; set; }
        public int PAE1_Size { get; set; }

        public void ReadPAE1(BinaryReader br, byte[] BOM)
        {
            PAE1_Header = br.ReadChars(4);
            if (new string(PAE1_Header) != "pae1") throw new Exception("不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            PAE1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
        }

        public void WritePAE1(BinaryWriter bw)
        {
            bw.Write(PAE1_Header);
            bw.Write(GetSize());
        }

        public int GetSize()
        {
            return PAE1_Header.Length + sizeof(int);
        }

        public PAE1 Default()
        {
            return new PAE1 { PAE1_Header = "pae1".ToCharArray(), PAE1_Size = GetSize() };
        }

        public PAE1()
        {
            PAE1_Header = "pae1".ToCharArray();
            PAE1_Size = 0;
        }
    }
}
