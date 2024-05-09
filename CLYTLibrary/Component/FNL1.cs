using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class FNL1
    {
        public char[] FNL1_Header { get; set; }
        public int FNL1_Size { get; set; }
        public int FontCount { get; set; }

        public List<FontNameList> FontName_List { get; set; }
        public class FontNameList
        {
            public int FontNameCharOffSetPos { get; set; }

            public char[] FontNameCharArray { get; set; }
            public string FontName => new string(FontNameCharArray);

            public void Read_FontName(BinaryReader br, byte[] BOM, long FontNameOffsetPos)
            {
                EndianConvert endianConvert = new EndianConvert(BOM);
                FontNameCharOffSetPos = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
                if (FontNameCharOffSetPos != 0)
                {
                    long CurrentPos = br.BaseStream.Position;

                    br.BaseStream.Position = FontNameOffsetPos;

                    br.BaseStream.Seek(FontNameCharOffSetPos, SeekOrigin.Current);

                    //Read
                    ReadByteLine readByteLine = new ReadByteLine(new List<byte>());
                    readByteLine.ReadByte(br, 0x00);
                    FontNameCharArray = readByteLine.ConvertToCharArray();

                    br.BaseStream.Position = CurrentPos;
                }
            }

            public FontNameList()
            {
                FontNameCharOffSetPos = 0;
                FontNameCharArray = new List<char>().ToArray();
            }
        }

        public void Read_FNL1(BinaryReader br, byte[] BOM)
        {
            long FNL1_Pos = br.BaseStream.Position;

            EndianConvert endianConvert = new EndianConvert(BOM);

            FNL1_Header = br.ReadChars(4);
            if (new string(FNL1_Header) != "fnl1") throw new Exception("FNL1 : 不明なフォーマットです");

            FNL1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            FontCount = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            if (FontCount != 0)
            {
                long FontNameOffsetPos = br.BaseStream.Position;

                for (int i = 0; i < FontCount; i++)
                {
                    FontNameList fontNameList = new FontNameList();
                    fontNameList.Read_FontName(br, BOM, FontNameOffsetPos);
                    FontName_List.Add(fontNameList);
                }
            }

            //Move End of FNL1Data Position
            br.BaseStream.Position = FNL1_Pos;
            br.BaseStream.Seek(FNL1_Size, SeekOrigin.Current);
        }
        
        public FNL1()
        {
            FNL1_Header = "fnl1".ToCharArray();
            FNL1_Size = 0;
            FontCount = 0;
            FontName_List = new List<FontNameList>();
        }
    }


}
