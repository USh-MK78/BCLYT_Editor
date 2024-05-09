using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class MAT1
    {
        public char[] MAT1_Header { get; set; }
        public int MAT1_Size { get; set; }

        public int MatCount { get; set; }
        public List<MatLayoutData> MatLayoutData_List { get; set; }
        public class MatLayoutData
        {
            public int MatLayoutOffset { get; set; }

            public MatLayout Mat_Layout { get; set; }
            public class MatLayout
            {
                //0x20
                public char[] MatNameCharArray { get; set; }

                //0x4
                public TevColor TevColorData { get; set; }
                public class TevColor
                {
                    public byte Data1 { get; set; }
                    public byte Data2 { get; set; }
                    public byte Data3 { get; set; }
                    public byte Data4 { get; set; }

                    public void ReadTevColor(BinaryReader br)
                    {
                        Data1 = br.ReadByte();
                        Data2 = br.ReadByte();
                        Data3 = br.ReadByte();
                        Data4 = br.ReadByte();
                    }

                    public void WriteTevColor(BinaryWriter bw)
                    {
                        bw.Write(Data1);
                        bw.Write(Data2);
                        bw.Write(Data3);
                        bw.Write(Data4);
                    }

                    public int GetSize()
                    {
                        return sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte);
                    }

                    public TevColor(byte d1, byte d2, byte d3, byte d4)
                    {
                        Data1 = d1;
                        Data2 = d2;
                        Data3 = d3;
                        Data4 = d4;
                    }

                    public TevColor()
                    {
                        Data1 = 0x00;
                        Data2 = 0x00;
                        Data3 = 0x00;
                        Data4 = 0x00;
                    }
                }

                //0x24
                public TevConstantColor TevConstantColorData { get; set; }
                public class TevConstantColor
                {
                    public class ConstantColor
                    {
                        public byte Data1 { get; set; }
                        public byte Data2 { get; set; }
                        public byte Data3 { get; set; }
                        public byte Data4 { get; set; }

                        public void ReadConstantColor(BinaryReader br)
                        {
                            Data1 = br.ReadByte();
                            Data2 = br.ReadByte();
                            Data3 = br.ReadByte();
                            Data4 = br.ReadByte();
                        }

                        public void WriteConstantColor(BinaryWriter bw)
                        {
                            bw.Write(Data1);
                            bw.Write(Data2);
                            bw.Write(Data3);
                            bw.Write(Data4);
                        }

                        public int GetSize()
                        {
                            return sizeof(byte) + sizeof(byte) + sizeof(byte) + sizeof(byte);
                        }

                        public ConstantColor(byte d1, byte d2, byte d3, byte d4)
                        {
                            Data1 = d1;
                            Data2 = d2;
                            Data3 = d3;
                            Data4 = d4;
                        }

                        public ConstantColor()
                        {
                            Data1 = 0x00;
                            Data2 = 0x00;
                            Data3 = 0x00;
                            Data4 = 0x00;
                        }
                    }

                    public ConstantColor ConstantColor0 { get; set; }
                    public ConstantColor ConstantColor1 { get; set; }
                    public ConstantColor ConstantColor2 { get; set; }
                    public ConstantColor ConstantColor3 { get; set; }
                    public ConstantColor ConstantColor4 { get; set; }
                    public ConstantColor ConstantColor5 { get; set; }

                    public void Read_TevConstantColor(BinaryReader br)
                    {
                        ConstantColor0.ReadConstantColor(br);
                        ConstantColor1.ReadConstantColor(br);
                        ConstantColor2.ReadConstantColor(br);
                        ConstantColor3.ReadConstantColor(br);
                        ConstantColor4.ReadConstantColor(br);
                        ConstantColor5.ReadConstantColor(br);
                    }

                    public void Write_TevConstantColor(BinaryWriter bw)
                    {
                        ConstantColor0.WriteConstantColor(bw);
                        ConstantColor1.WriteConstantColor(bw);
                        ConstantColor2.WriteConstantColor(bw);
                        ConstantColor3.WriteConstantColor(bw);
                        ConstantColor4.WriteConstantColor(bw);
                        ConstantColor5.WriteConstantColor(bw);
                    }

                    public int GetSize()
                    {
                        return ConstantColor0.GetSize() + ConstantColor1.GetSize() + ConstantColor2.GetSize() + ConstantColor3.GetSize() + ConstantColor4.GetSize() + ConstantColor5.GetSize();
                    }

                    public TevConstantColor()
                    {
                        ConstantColor0 = new ConstantColor();
                        ConstantColor1 = new ConstantColor();
                        ConstantColor2 = new ConstantColor();
                        ConstantColor3 = new ConstantColor();
                        ConstantColor4 = new ConstantColor();
                        ConstantColor5 = new ConstantColor();
                    }
                }

                public int FlagOrBit { get; set; }
                public short TexIndex { get; set; }
                public byte Bitfield1 { get; set; }
                public byte Bitfield2 { get; set; }

                public LayoutTransform LayoutTransformData { get; set; }
                public class LayoutTransform
                {
                    public Translate TranslateXY { get; set; }
                    public class Translate
                    {
                        public float X { get; set; }
                        public float Y { get; set; }

                        public void ReadTranslate(BinaryReader br, byte[] BOM)
                        {
                            EndianConvert endianConvert = new EndianConvert(BOM);
                            X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                            Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                        }

                        public void WriteTranslate(BinaryWriter bw)
                        {
                            bw.Write(X);
                            bw.Write(Y);
                        }

                        public int GetSize()
                        {
                            return sizeof(float) + sizeof(float);
                        }

                        public Translate(float X, float Y)
                        {
                            this.X = X;
                            this.Y = Y;
                        }

                        public Translate()
                        {
                            X = 0;
                            Y = 0;
                        }
                    }

                    public float Rotation { get; set; }

                    public Scale ScaleXY { get; set; }
                    public class Scale
                    {
                        public float X { get; set; }
                        public float Y { get; set; }

                        public void ReadScale(BinaryReader br, byte[] BOM)
                        {
                            EndianConvert endianConvert = new EndianConvert(BOM);
                            X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                            Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                        }

                        public void WriteScale(BinaryWriter bw)
                        {
                            bw.Write(X);
                            bw.Write(Y);
                        }

                        public int GetSize()
                        {
                            return sizeof(float) + sizeof(float);
                        }

                        public Scale(float X, float Y)
                        {
                            this.X = X;
                            this.Y = Y;
                        }

                        public Scale()
                        {
                            X = 0;
                            Y = 0;
                        }
                    }

                    public void Read_LayoutTransform(BinaryReader br, byte[] BOM)
                    {
                        EndianConvert endianConvert = new EndianConvert(BOM);

                        TranslateXY.ReadTranslate(br, BOM);
                        Rotation = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
                        ScaleXY.ReadScale(br, BOM);
                    }

                    public void Write_LayoutTransform(BinaryWriter bw)
                    {
                        TranslateXY.WriteTranslate(bw);
                        bw.Write(Rotation);
                        ScaleXY.WriteScale(bw);
                    }

                    public int GetSize()
                    {
                        return TranslateXY.GetSize() + sizeof(float) + ScaleXY.GetSize();
                    }

                    public LayoutTransform(Translate translate, float Rotation, Scale scale)
                    {
                        TranslateXY = translate;
                        this.Rotation = Rotation;
                        ScaleXY = scale;
                    }

                    public LayoutTransform()
                    {
                        TranslateXY = new Translate(0, 0);
                        Rotation = 0;
                        ScaleXY = new Scale(0, 0);
                    }
                }

                public byte[] UnknownByteArray0 { get; set; } //0x4

                public void ReadMatLayout(BinaryReader br, byte[] BOM)
                {
                    MatNameCharArray = br.ReadChars(20);

                    TevColorData.ReadTevColor(br);
                    TevConstantColorData.Read_TevConstantColor(br);

                    EndianConvert endianConvert = new EndianConvert(BOM);
                    FlagOrBit = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
                    TexIndex = BitConverter.ToInt16(endianConvert.Convert(br.ReadBytes(2)), 0);
                    Bitfield1 = br.ReadByte();
                    Bitfield2 = br.ReadByte();
                    LayoutTransformData.Read_LayoutTransform(br, BOM);
                    UnknownByteArray0 = endianConvert.Convert(br.ReadBytes(4));
                }

                public void WriteMatLayout(BinaryWriter bw)
                {
                    bw.Write(MatNameCharArray);
                    TevColorData.WriteTevColor(bw);
                    TevConstantColorData.Write_TevConstantColor(bw);
                    bw.Write(FlagOrBit);
                    bw.Write(TexIndex);
                    bw.Write(Bitfield1);
                    bw.Write(Bitfield2);
                    LayoutTransformData.Write_LayoutTransform(bw);
                    bw.Write(UnknownByteArray0);
                }

                public int GetSize()
                {
                    int size = MatNameCharArray.Length +
                               TevColorData.GetSize() +
                               TevConstantColorData.GetSize() +
                               sizeof(int) + 
                               sizeof(short) + 
                               sizeof(byte) + 
                               sizeof(byte) +
                               LayoutTransformData.GetSize() + 
                               UnknownByteArray0.Length;

                    return size;
                }

                public MatLayout(string Name, TevColor tevColor, TevConstantColor tevConstantColor, int FlagOrBit, short TexIndex, byte Bit1, byte Bit2, LayoutTransform layoutTransform, byte[] UnknownByteArray0)
                {
                    char[] chars = Enumerable.Repeat('\0', 20).ToArray();

                    for (int i = 0; i < Name.ToCharArray().Length; i++)
                    {
                        chars[i] = Name.ToCharArray()[i];
                    }
                    MatNameCharArray = chars;

                    TevColorData = tevColor;
                    TevConstantColorData = tevConstantColor;
                    this.FlagOrBit = FlagOrBit;
                    this.TexIndex = TexIndex;
                    Bitfield1 = Bit1;
                    Bitfield2 = Bit2;

                    LayoutTransformData = layoutTransform;
                    this.UnknownByteArray0 = UnknownByteArray0;
                }

                public MatLayout()
                {
                    MatNameCharArray = new char[20];
                    TevColorData = new TevColor();
                    TevConstantColorData = new TevConstantColor();
                    FlagOrBit = 0;
                    TexIndex = 0;
                    Bitfield1 = 0x00;
                    Bitfield2 = 0x00;
                    LayoutTransformData = new LayoutTransform();
                    UnknownByteArray0 = new byte[4];
                }
            }

            public void Read_MatLayoutData(BinaryReader br, byte[] BOM, long MAT1_Pos)
            {
                EndianConvert endianConvert = new EndianConvert(BOM);
                MatLayoutOffset = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
                if (MatLayoutOffset != 0)
                {
                    long CurrentPos = br.BaseStream.Position;

                    br.BaseStream.Position = MAT1_Pos;

                    br.BaseStream.Seek(MatLayoutOffset, SeekOrigin.Current);

                    Mat_Layout.ReadMatLayout(br, BOM);

                    br.BaseStream.Position = CurrentPos;
                }
            }

            public void Write_MatLayoutData(BinaryWriter bw, long MAT1_Pos)
            {
                bw.Write(MatLayoutOffset);
                if (MatLayoutOffset != 0)
                {
                    long CurrentPos = bw.BaseStream.Position;

                    bw.BaseStream.Position = MAT1_Pos;

                    bw.BaseStream.Seek(MatLayoutOffset, SeekOrigin.Current);

                    Mat_Layout.WriteMatLayout(bw);

                    bw.BaseStream.Position = CurrentPos;
                }
            }

            public int GetSize()
            {
                return sizeof(int) + Mat_Layout.GetSize();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i">NumOfLoopCount</param>
            /// <param name="AllCount">All MAT1 Count</param>
            /// <param name="matLayout">MatLayout</param>
            public MatLayoutData(int i, int AllCount, MatLayout matLayout)
            {
                MatLayoutOffset = 4 + (4 * AllCount) + (i * GetSize());
                Mat_Layout = matLayout;
            }

            public MatLayoutData()
            {
                MatLayoutOffset = 0;
                Mat_Layout = new MatLayout();
            }
        }

        public void Read_MAT1(BinaryReader br, byte[] BOM)
        {
            long MAT1_Pos = br.BaseStream.Position;

            MAT1_Header = br.ReadChars(4);
            if (new string(MAT1_Header) != "mat1") throw new Exception("MAT1 : 不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            MAT1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);

            MatCount = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            if (MatCount != 0)
            {
                for (int i = 0; i < MatCount; i++)
                {
                    MatLayoutData matLayoutData = new MatLayoutData();
                    matLayoutData.Read_MatLayoutData(br, BOM, MAT1_Pos);
                    MatLayoutData_List.Add(matLayoutData);
                }
            }

            //Move End of MAT1 Section
            br.BaseStream.Position = MAT1_Pos;
            br.BaseStream.Seek(MAT1_Size, SeekOrigin.Current);
        }

        public void Write_MAT1(BinaryWriter bw)
        {
            long MAT1_Pos = bw.BaseStream.Position;

            bw.Write(MAT1_Header);
            bw.Write(GetSize());
            bw.Write(MatCount);

            if (MatCount != 0)
            {
                for (int i = 0; i < MatCount; i++)
                {
                    MatLayoutData_List[i].Write_MatLayoutData(bw, MAT1_Pos);
                }
            }

            //Move Current Position
            bw.BaseStream.Position = bw.BaseStream.Length;
        }

        public int GetSize()
        {
            int size = MAT1_Header.Length + sizeof(int) + sizeof(int);
            foreach (var item in MatLayoutData_List)
            {
                size += item.GetSize();
            }

            return size;
        }

        public MAT1()
        {
            MAT1_Header = "mat1".ToCharArray();
            MAT1_Size = 0;
            MatCount = 0;
            MatLayoutData_List = new List<MatLayoutData>();
        }
    }
}
