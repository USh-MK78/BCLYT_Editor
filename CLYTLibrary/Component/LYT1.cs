using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    /// <summary>
    /// CLYT Layout Resource Class
    /// </summary>
    public class LayoutResource
    {
        public enum LayoutResourceType
        {
            TXL1,
            FNL1,
            MAT1,
            PAN1,
            GRP1,
            EMPTY
        }

        public LayoutResourceType LayoutResource_Type { get; set; }
        public object LayoutResourceData { get; set; }

        public LayoutResource(LayoutResourceType layoutResourceType, object LayoutResourceObj)
        {
            LayoutResource_Type = layoutResourceType;
            LayoutResourceData = LayoutResourceObj;
        }

        public LayoutResource()
        {
            LayoutResource_Type = LayoutResourceType.EMPTY;
            LayoutResourceData = new object();
        }
    }

    public class LYT1
    {
        public char[] LYT1_Header { get; set; }
        public int LYT1_Size { get; set; }

        //0=Classic(クラシック)
        //1=Normal(ノーマル)
        public enum OriginType
        {
            Classic = 0,
            Normal = 1
        }

        public int OriginTypeNum { get; set; }
        public OriginType Origin_Type
        {
            get
            {
                return GetOriginType();
            }
            set
            {
                OriginTypeNum = (int)value;
            }
        }

        public OriginType GetOriginType()
        {
            return (OriginType)Enum.ToObject(typeof(OriginType), OriginTypeNum);
        }

        public float Canvas_XSize { get; set; } //0x4
        public float Canvas_YSize { get; set; } //0x4

        public Dictionary<int, LayoutResource> LayoutResourceDictionary { get; set; }

        public void ReadLYT1(BinaryReader br, byte[] BOM)
        {
            //long LYT1_Pos = br.BaseStream.Position;

            LYT1_Header = br.ReadChars(4);
            if (new string(LYT1_Header) != "lyt1") throw new Exception("LYT1 : 不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            LYT1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            OriginTypeNum = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            Canvas_XSize = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
            Canvas_YSize = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);

            int i = 0;
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                long Pos = br.BaseStream.Position;
                char[] HeaderCheck = br.ReadChars(4);
                string HeaderString = new string(HeaderCheck);
                br.BaseStream.Position = Pos;

                if (HeaderString == "txl1")
                {
                    TXL1 tXL1 = new TXL1();
                    tXL1.Read_TXL1(br, BOM);

                    LayoutResource layoutResource = new LayoutResource(LayoutResource.LayoutResourceType.TXL1, tXL1);
                    LayoutResourceDictionary.Add(i, layoutResource);
                    i++;
                }
                else if (HeaderString == "mat1")
                {
                    MAT1 mAT1 = new MAT1();
                    mAT1.Read_MAT1(br, BOM);

                    LayoutResource layoutResource = new LayoutResource(LayoutResource.LayoutResourceType.MAT1, mAT1);
                    LayoutResourceDictionary.Add(i, layoutResource);
                    i++;
                }
                else if (HeaderString == "fnl1")
                {
                    FNL1 fNL1 = new FNL1();
                    fNL1.Read_FNL1(br, BOM);

                    LayoutResource layoutResource = new LayoutResource(LayoutResource.LayoutResourceType.FNL1, fNL1);
                    LayoutResourceDictionary.Add(i, layoutResource);
                    i++;
                }
                else if (HeaderString == "pan1")
                {
                    //long pan1Pos = br.BaseStream.Position;

                    PAN1 pAN1 = new PAN1();
                    pAN1.Read_PAN1(br, BOM);

                    LayoutResource layoutResource = new LayoutResource(LayoutResource.LayoutResourceType.PAN1, pAN1);
                    LayoutResourceDictionary.Add(i, layoutResource);
                    i++;

                    long CurrentPos_Debug = br.BaseStream.Position;
                }
                else if (HeaderString == "grp1")
                {
                    //long grp1Pos = br.BaseStream.Position;

                    GRP1 grp1 = new GRP1();
                    grp1.Read_GRP1(br, BOM);

                    LayoutResource layoutResource = new LayoutResource(LayoutResource.LayoutResourceType.GRP1, grp1);
                    LayoutResourceDictionary.Add(i, layoutResource);
                    i++;

                    long CurrentPos_Debug = br.BaseStream.Position;
                }

            }
        }

        public void Write_LYT1(BinaryWriter bw)
        {
            bw.Write(LYT1_Header);
            bw.Write(GetSize());
            bw.Write(OriginTypeNum);
            bw.Write(Canvas_XSize);
            bw.Write(Canvas_YSize);

            if (LayoutResourceDictionary != null)
            {
                foreach (var item in LayoutResourceDictionary)
                {
                    if (item.Value.LayoutResource_Type == LayoutResource.LayoutResourceType.TXL1)
                    {
                        TXL1 tXL1 = (TXL1)item.Value.LayoutResourceData;
                        tXL1.Write_TXL1(bw);
                    }
                    else if (item.Value.LayoutResource_Type == LayoutResource.LayoutResourceType.MAT1)
                    {
                        MAT1 mAT1 = (MAT1)item.Value.LayoutResourceData;
                        mAT1.Write_MAT1(bw);
                    }
                    else if (item.Value.LayoutResource_Type == LayoutResource.LayoutResourceType.PAN1)
                    {
                        PAN1 pan1 = (PAN1)item.Value.LayoutResourceData;
                        pan1.Write_PAN1(bw);
                    }
                }
            }
        }

        public int GetSize()
        {
            return LYT1_Header.Length + sizeof(int) + sizeof(int) + sizeof(float) + sizeof(float);
        }

        public LYT1(float Size_X, float Size_Y, OriginType OriginType, Dictionary<int, LayoutResource> LayoutResourceDict = null)
        {
            LYT1_Header = "lyt1".ToArray();
            LYT1_Size = GetSize();
            this.Origin_Type = OriginType;
            Canvas_XSize = Size_X;
            Canvas_YSize = Size_Y;

            if (LayoutResourceDict != null)
            {
                LayoutResourceDictionary = LayoutResourceDict;
            }
            else if (LayoutResourceDict == null)
            {
                LayoutResourceDictionary = new Dictionary<int, LayoutResource>();
            }
        }

        public LYT1()
        {
            LYT1_Header = "lyt1".ToArray();
            LYT1_Size = 0;
            OriginTypeNum = 0;
            Canvas_XSize = 0;
            Canvas_YSize = 0;
            LayoutResourceDictionary = new Dictionary<int, LayoutResource>();
        }
    }
}
