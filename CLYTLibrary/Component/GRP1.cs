using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class GRS1
    {
        public char[] GRS1_Header { get; set; }
        public int GRS1_Size { get; set; }

        public void Read_GRS1(BinaryReader br, byte[] BOM)
        {
            EndianConvert endianConvert = new EndianConvert(BOM);

            GRS1_Header = br.ReadChars(4);
            if (new string(GRS1_Header) != "grs1") throw new Exception("GRS1 : 不明なフォーマットです");

            GRS1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
        }

        public void Write_GRS1(BinaryWriter bw)
        {
            bw.Write(GRS1_Header);
            bw.Write(GRS1_Size);
        }

        public GRS1 Default_GRS1()
        {
            return new GRS1(8);
        }

        public GRS1(int Size = 0)
        {
            GRS1_Header = "grs1".ToArray();
            GRS1_Size = Size;
        }
    }

    public class GRE1
    {
        public char[] GRE1_Header { get; set; }
        public int GRE1_Size { get; set; }

        public void Read_GRE1(BinaryReader br, byte[] BOM)
        {
            EndianConvert endianConvert = new EndianConvert(BOM);

            GRE1_Header = br.ReadChars(4);
            if (new string(GRE1_Header) != "gre1") throw new Exception("GRE1 : 不明なフォーマットです");

            GRE1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
        }

        public void Write_GRS1(BinaryWriter bw)
        {
            bw.Write(GRE1_Header);
            bw.Write(GRE1_Size);
        }

        public GRE1 Default_GRE1()
        {
            return new GRE1(8);
        }

        public GRE1(int Size = 0)
        {
            GRE1_Header = "gre1".ToArray();
            GRE1_Size = Size;
        }
    }

    public class GRP1
    {
        public char[] GRP1_Header { get; set; }
        public int GRP1_Size { get; set; }

        public char[] GRP1_NameCharArray { get; set; } //16 byte
        public string GRP1_Name => new string(GRP1_NameCharArray);

        public int SubGroupNameCount { get; set; }
        public List<SubGroupName> SubGroupNameList { get; set; }
        public class SubGroupName
        {
            public char[] SubNameCharArray { get; set; } //16Byte

            public string SubName => new string(SubNameCharArray);
            
            public void ReadSubGroupName(BinaryReader br)
            {
                SubNameCharArray = br.ReadChars(16);
            }

            public SubGroupName(string Name)
            {
                char[] InputCharAry = Name.ToArray();

                char[] SubNameCharArrayData = Enumerable.Repeat('\0', 16).ToArray();
                if (InputCharAry.Length <= 16)
                {
                    for(int i = 0; i < InputCharAry.Length; i++)
                    {
                        SubNameCharArrayData[i] = InputCharAry[i];
                    }
                }

                SubNameCharArray = SubNameCharArrayData;
            }

            public SubGroupName(char[] CharArray)
            {
                SubNameCharArray = CharArray;
            }

            public SubGroupName()
            {
                SubNameCharArray = new char[16];
            }
        }

        public GroupLayoutNode GroupLayoutNode { get; set; }

        public void Read_GRP1(BinaryReader br, byte[] BOM)
        {
            EndianConvert endianConvert = new EndianConvert(BOM);

            GRP1_Header = br.ReadChars(4);
            if (new string(GRP1_Header) != "grp1") throw new Exception("GRP1 : 不明なフォーマットです");

            GRP1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            GRP1_NameCharArray = br.ReadChars(16);

            SubGroupNameCount = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            if(SubGroupNameCount != 0)
            {
                for (int i = 0; i < SubGroupNameCount; i++)
                {
                    SubGroupName subGroupName = new SubGroupName();
                    subGroupName.ReadSubGroupName(br);
                    SubGroupNameList.Add(subGroupName);
                }
            }

            GroupLayoutNode.ReadGroupLayoutNode(br, BOM);
        }

        public GRP1()
        {
            GRP1_Header = "grp1".ToArray();
            GRP1_Size = 0;
            GRP1_NameCharArray = new char[16];

            SubGroupNameCount = 0;
            SubGroupNameList = new List<SubGroupName>();

            GroupLayoutNode = new GroupLayoutNode();
        }
    }

    /// <summary>
    /// GRP1 Layout Node
    /// </summary>
    public class GroupLayoutNode
    {
        public GRS1 GRS1 { get; set; }
        public Dictionary<int, GRP1> GRP1_Dictionary { get; set; }
        public GRE1 GRE1 { get; set; }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="br"></param>
        /// <param name="BOM"></param>
        public void ReadGroupLayoutNode(BinaryReader br, byte[] BOM)
        {
            long Pos = br.BaseStream.Position;
            char[] HeaderCheck = br.ReadChars(4);
            string HeaderString = new string(HeaderCheck);
            br.BaseStream.Position = Pos;

            if (HeaderString == "grs1")
            {
                GRS1 grs1 = new GRS1();
                grs1.Read_GRS1(br, BOM);
                GRS1 = grs1;

                int i = 0;
                while (HeaderString != "gre1")
                {
                    long CurPos = br.BaseStream.Position;
                    char[] HeaderCheck_Loop = br.ReadChars(4);
                    string HeaderString_Loop = new string(HeaderCheck_Loop);
                    br.BaseStream.Position = CurPos;

                    if (HeaderString_Loop == "grp1")
                    {
                        GRP1 grp1 = new GRP1();
                        grp1.Read_GRP1(br, BOM);

                        GRP1_Dictionary.Add(i, grp1);
                        i++;
                    }
                    else if (HeaderString_Loop == "gre1")
                    {
                        GRE1 gre1 = new GRE1();
                        gre1.Read_GRE1(br, BOM);
                        GRE1 = gre1;

                        break;
                    }
                }
            }
            else
            {
                GRS1 = null;
                GRP1_Dictionary = null;
                GRE1 = null;
                return;
            }
        }

        public GroupLayoutNode()
        {
            GRS1 = new GRS1();
            GRP1_Dictionary = new Dictionary<int, GRP1>();
            GRE1 = new GRE1();
        }
    }
}
