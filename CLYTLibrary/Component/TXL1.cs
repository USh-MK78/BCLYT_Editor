using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class TXL1
    {
        public char[] TXL1_Header { get; set; }

        public int TXL1_Size { get; set; }

        public int TextureNameCount { get; set; }
        public List<TexNameList> TextureName_List { get; set; }
        public class TexNameList
        {
            public int TextureNameStringOffSet { get; set; } //From : TXL1
            public string TextureName { get; set; }

            public int GetSize()
            {
                return sizeof(int) + TextureName.Length;
            }

            public void ReadTextureName(BinaryReader br, byte[] BOM, long TextureNameOffset)
            {
                EndianConvert endianConvert = new EndianConvert(BOM);
                TextureNameStringOffSet = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
                if (TextureNameStringOffSet != 0)
                {
                    long CurrentPos = br.BaseStream.Position;

                    br.BaseStream.Position = TextureNameOffset;

                    br.BaseStream.Seek(TextureNameStringOffSet, SeekOrigin.Current);

                    //ReadString
                    ReadByteLine readByteLine = new ReadByteLine(new List<byte>());
                    readByteLine.ReadByte(br, 0x00);
                    TextureName = new string(readByteLine.ConvertToCharArray());

                    br.BaseStream.Position = CurrentPos;
                }
            }

            //public TexNameList(string Name)
            //{

            //}

            public TexNameList()
            {
                TextureNameStringOffSet = 0;
                TextureName = "";
            }
        }

        public char[] GetNameListStringToArray(string[] InputStrArray)
        {
            char[] CharArray = new List<char>().ToArray();
            foreach (var Name in InputStrArray)
            {
                char[] chars = Name.ToCharArray();
                chars.Concat(new char[] { '\0' });
                CharArray.Concat(chars);
            }

            //TODO : Calculate Odds

            return CharArray;
        }

        public int[] GetCharArrayStartPosList(string[] strings)
        {
            List<int> ints = new List<int>();
            int i = 0;
            foreach (var c in GetNameListStringToArray(strings))
            {
                if (c == 0x00)
                {
                    ints.Add((4 * TextureNameCount) + i++);
                }
            }

            return ints.ToArray();
        }

        public void Read_TXL1(BinaryReader br, byte[] BOM)
        {
            long TXL1_Pos = br.BaseStream.Position;

            TXL1_Header = br.ReadChars(4);
            if (new string(TXL1_Header) != "txl1") throw new Exception("TXL1 : 不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            TXL1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            TextureNameCount = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            if (TextureNameCount != 0)
            {
                long TextureNameOffset = br.BaseStream.Position;

                for (int i = 0; i < TextureNameCount; i++)
                {
                    TexNameList texNameList = new TexNameList();
                    texNameList.ReadTextureName(br, BOM, TextureNameOffset);
                    TextureName_List.Add(texNameList);
                }
            }

            //Move End of TXL1 Section
            br.BaseStream.Position = TXL1_Pos;
            br.BaseStream.Seek(TXL1_Size, SeekOrigin.Current);
        }

        public void Write_TXL1(BinaryWriter bw)
        {
            bw.Write(TXL1_Header);
            bw.Write(GetSize());
            bw.Write(TextureNameCount);

            foreach (var d in TextureName_List)
            {
                bw.Write(d.TextureNameStringOffSet);
            }

            string[] data = TextureName_List.Select(x => x.TextureName).ToArray();
            foreach (var str in data)
            {
                bw.Write(str.ToCharArray());
            }
        }

        public int GetSize()
        {
            int d = TXL1_Header.Length + sizeof(int) + sizeof(int);

            foreach (var f in TextureName_List)
            {
                d += f.GetSize();
            }

            return d;
        }

        public TXL1(string[] strings)
        {
            TXL1_Header = "txl1".ToCharArray();
            TXL1_Size = 0;
            TextureNameCount = strings.Length;

            #region InputStringArray
            List<TexNameList> texName_List = new List<TexNameList>();
            for (int j = 0; j < TextureNameCount; j++)
            {
                TexNameList texNameList = new TexNameList
                {
                    TextureNameStringOffSet = GetCharArrayStartPosList(strings)[j],
                    TextureName = strings[j]
                };

                texName_List.Add(texNameList);
            }
            #endregion

            TextureName_List = texName_List;
        }

        public TXL1()
        {
            TXL1_Header = "txl1".ToCharArray();
            TXL1_Size = 0;
            TextureNameCount = 0;
            TextureName_List = new List<TexNameList>();
        }
    }
}
