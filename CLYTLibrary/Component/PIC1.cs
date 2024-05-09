using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLYTLibrary.Component
{
    public class PIC1
    {
        public char[] PIC1_Header { get; set; }
        public int PIC1_Size { get; set; }

        public byte UnknownByte1 { get; set; }
        public byte UnknownByte2 { get; set; }
        public byte UnknownByte3 { get; set; }
        public byte UnknownByte4 { get; set; }

        public char[] PIC1NameCharArray { get; set; } //24 byte
        public string PIC1Name => new string(PIC1NameCharArray);

        public PIC1_Transform PIC1_TransformData { get; set; }
        public class PIC1_Transform
        {
            public Translate TranslateData { get; set; }
            public class Translate
            {
                public float X { get; set; }
                public float Y { get; set; }
                public float Z { get; set; }

                public void Read_Translate(BinaryReader br, byte[] BOM)
                {
                    EndianConvert endianConvert = new EndianConvert(BOM);
                    X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Z = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                }

                public void Write_Translate(BinaryWriter bw)
                {
                    bw.Write(X);
                    bw.Write(Y);
                    bw.Write(Z);
                }

                public int GetSize()
                {
                    return sizeof(float) + sizeof(float) + sizeof(float);
                }

                public Translate(float X, float Y, float Z)
                {
                    this.X = X;
                    this.Y = Y;
                    this.Z = Z;
                }

                public Translate()
                {
                    X = 0;
                    Y = 0;
                    Z = 0;
                }
            }

            public Rotate RotateData { get; set; }
            public class Rotate
            {
                public float X { get; set; }
                public float Y { get; set; }
                public float Z { get; set; }

                public void Read_Rotate(BinaryReader br, byte[] BOM)
                {
                    EndianConvert endianConvert = new EndianConvert(BOM);
                    X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Z = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                }

                public void Write_Rotate(BinaryWriter bw)
                {
                    bw.Write(X);
                    bw.Write(Y);
                    bw.Write(Z);
                }

                public int GetSize()
                {
                    return sizeof(float) + sizeof(float) + sizeof(float);
                }

                public Rotate(float X, float Y, float Z)
                {
                    this.X = X;
                    this.Y = Y;
                    this.Z = Z;
                }

                public Rotate()
                {
                    X = 0;
                    Y = 0;
                    Z = 0;
                }
            }

            public Scale ScaleData { get; set; }
            public class Scale
            {
                public float X { get; set; }
                public float Y { get; set; }

                public void Read_Scale(BinaryReader br, byte[] BOM)
                {
                    EndianConvert endianConvert = new EndianConvert(BOM);
                    X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                }

                public void Write_Scale(BinaryWriter bw)
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

            public Size SizeData { get; set; }
            public class Size
            {
                public float X { get; set; }
                public float Y { get; set; }

                public void Read_Size(BinaryReader br, byte[] BOM)
                {
                    EndianConvert endianConvert = new EndianConvert(BOM);
                    X = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                    Y = BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0);
                }

                public void Write_Size(BinaryWriter bw)
                {
                    bw.Write(X);
                    bw.Write(Y);
                }

                public int GetSize()
                {
                    return sizeof(float) + sizeof(float);
                }

                public Size(float X, float Y)
                {
                    this.X = X;
                    this.Y = Y;
                }

                public Size()
                {
                    X = 0;
                    Y = 0;
                }
            }

            public void Read_PIC1_Transform(BinaryReader br, byte[] BOM)
            {
                TranslateData.Read_Translate(br, BOM);
                RotateData.Read_Rotate(br, BOM);
                ScaleData.Read_Scale(br, BOM);
                SizeData.Read_Size(br, BOM);
            }

            public void Write_PIC1_Transform(BinaryWriter bw)
            {
                TranslateData.Write_Translate(bw);
                RotateData.Write_Rotate(bw);
                ScaleData.Write_Scale(bw);
                SizeData.Write_Size(bw);
            }

            public int GetSize()
            {
                return TranslateData.GetSize() + RotateData.GetSize() + ScaleData.GetSize() + SizeData.GetSize();
            }

            public PIC1_Transform(Translate translate, Rotate rotate, Scale scale, Size size)
            {
                TranslateData = translate;
                RotateData = rotate;
                ScaleData = scale;
                SizeData = size;
            }

            public PIC1_Transform()
            {
                TranslateData = new Translate();
                RotateData = new Rotate();
                ScaleData = new Scale();
                SizeData = new Size();
            }
        }

        public PIC1_VertexColorSet VertexColorSet { get; set; }
        public class PIC1_VertexColorSet
        {
            public byte[] Top_Left_Color { get; set; }
            public byte[] Top_Right_Color { get; set; }
            public byte[] Bottom_Left_Color { get; set; }
            public byte[] Bottom_Right_Color { get; set; }

            public void ReadVertexColorSet(BinaryReader br, byte[] BOM)
            {
                EndianConvert endianConvert = new EndianConvert(BOM);
                Top_Left_Color = endianConvert.Convert(br.ReadBytes(4));
                Top_Right_Color = endianConvert.Convert(br.ReadBytes(4));
                Bottom_Left_Color = endianConvert.Convert(br.ReadBytes(4));
                Bottom_Right_Color = endianConvert.Convert(br.ReadBytes(4));
            }

            public void WriteVertexColorSet(BinaryWriter bw)
            {
                bw.Write(Top_Left_Color);
                bw.Write(Top_Right_Color);
                bw.Write(Bottom_Left_Color);
                bw.Write(Bottom_Right_Color);
            }

            public int GetSize()
            {
                return Top_Left_Color.Length + Top_Right_Color.Length + Bottom_Left_Color.Length + Bottom_Right_Color.Length;
            }

            public PIC1_VertexColorSet(byte[] TopLeft, byte[] TopRight, byte[] BottomLeft, byte[] BottomRight)
            {
                Top_Left_Color = TopLeft;
                Top_Right_Color = TopRight;
                Bottom_Left_Color = BottomLeft;
                Bottom_Right_Color = BottomRight;
            }

            public PIC1_VertexColorSet()
            {
                Top_Left_Color = new byte[4];
                Top_Right_Color = new byte[4];
                Bottom_Left_Color = new byte[4];
                Bottom_Right_Color = new byte[4];
            }
        }

        public short Material_ID { get; set; }
        public short Nr_Texture_Coordinates { get; set; }

        public List<Layout2DTextureCoordinate> Layout2DTextureCoordinate_List { get; set; }
        public class Layout2DTextureCoordinate
        {
            public struct Layout2D
            {
                public float X { get; set; }
                public float Y { get; set; }

                public int Size
                {
                    get
                    {
                        return sizeof(float) + sizeof(float);
                    }
                }

                public Layout2D(float X, float Y)
                {
                    this.X = X;
                    this.Y = Y;
                }
            }

            public Layout2D TopLeft { get; set; }
            public Layout2D TopRight { get; set; }
            public Layout2D BottomLeft { get; set; }
            public Layout2D BottomRight { get; set; }

            public void Read_Layout2D_TextureCoordinate(BinaryReader br, byte[] BOM)
            {
                EndianConvert endianConvert = new EndianConvert(BOM);
                TopLeft = new Layout2D(BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0), BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0));
                TopRight = new Layout2D(BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0), BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0));
                BottomLeft = new Layout2D(BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0), BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0));
                BottomRight = new Layout2D(BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0), BitConverter.ToSingle(endianConvert.Convert(br.ReadBytes(4)), 0));
            }

            public void Write_Layout2D_TextureCoordinate(BinaryWriter bw)
            {
                bw.Write(TopLeft.X);
                bw.Write(TopLeft.Y);
                bw.Write(TopRight.X);
                bw.Write(TopRight.Y);
                bw.Write(BottomLeft.X);
                bw.Write(BottomLeft.Y);
                bw.Write(BottomRight.X);
                bw.Write(BottomRight.Y);
            }

            public int GetSize()
            {
                return TopLeft.Size + TopRight.Size + BottomLeft.Size + BottomRight.Size;
            }

            public Layout2DTextureCoordinate(Layout2D TopLeft, Layout2D TopRight, Layout2D BottomLeft, Layout2D BottomRight)
            {
                this.TopLeft = TopLeft;
                this.TopRight = TopRight;
                this.BottomLeft = BottomLeft;
                this.BottomRight = BottomRight;
            }

            public Layout2DTextureCoordinate()
            {
                TopLeft = new Layout2D(0, 0);
                TopRight = new Layout2D(0, 0);
                BottomLeft = new Layout2D(0, 0);
                BottomRight = new Layout2D(0, 0);
            }
        }

        public void Read_PIC1(BinaryReader br, byte[] BOM)
        {
            //long PIC1_Pos = br.BaseStream.Position;

            PIC1_Header = br.ReadChars(4);
            if (new string(PIC1_Header) != "pic1") throw new Exception("不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);
            PIC1_Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);

            UnknownByte1 = br.ReadByte();
            UnknownByte2 = br.ReadByte();
            UnknownByte3 = br.ReadByte();
            UnknownByte4 = br.ReadByte();

            PIC1NameCharArray = br.ReadChars(24);

            PIC1_TransformData.Read_PIC1_Transform(br, BOM);

            VertexColorSet.ReadVertexColorSet(br, BOM);

            Material_ID = BitConverter.ToInt16(endianConvert.Convert(br.ReadBytes(2)), 0);
            Nr_Texture_Coordinates = BitConverter.ToInt16(endianConvert.Convert(br.ReadBytes(2)), 0);
            if (Nr_Texture_Coordinates != 0)
            {
                for (int i = 0; i < Nr_Texture_Coordinates; i++)
                {
                    Layout2DTextureCoordinate layout2DTextureCoordinate = new Layout2DTextureCoordinate();
                    layout2DTextureCoordinate.Read_Layout2D_TextureCoordinate(br, BOM);
                    Layout2DTextureCoordinate_List.Add(layout2DTextureCoordinate);
                }
            }
        }

        public void Write_PIC1(BinaryWriter bw)
        {
            bw.Write(PIC1_Header);
            bw.Write(GetSize());
            bw.Write(UnknownByte1);
            bw.Write(UnknownByte2);
            bw.Write(UnknownByte3);
            bw.Write(UnknownByte4);

            bw.Write(PIC1NameCharArray);
            PIC1_TransformData.Write_PIC1_Transform(bw);
            VertexColorSet.WriteVertexColorSet(bw);
            bw.Write(Material_ID);
            bw.Write(Nr_Texture_Coordinates);

            for (int i = 0; i < Nr_Texture_Coordinates; i++)
            {
                Layout2DTextureCoordinate_List[i].Write_Layout2D_TextureCoordinate(bw);
            }

            long debugPos = bw.BaseStream.Position;
        }

        public int GetSize()
        {
            int size = PIC1_Header.Length +
                       sizeof(int) +
                       sizeof(byte) +
                       sizeof(byte) +
                       sizeof(byte) +
                       sizeof(byte) +
                       PIC1NameCharArray.Length +
                       PIC1_TransformData.GetSize() + 
                       VertexColorSet.GetSize() +
                       sizeof(short) +
                       sizeof(short);

            foreach (var item in Layout2DTextureCoordinate_List)
            {
                size += item.GetSize();
            }

            return size;
        }

        public PIC1(string Name, short MaterialID, byte U1, byte U2, byte U3, byte U4, PIC1_Transform pic1_Transform, List<Layout2DTextureCoordinate> layout2DTextureCoordinates)
        {
            PIC1_Header = "pic1".ToCharArray();
            PIC1_Size = 0;

            UnknownByte1 = U1;
            UnknownByte2 = U2;
            UnknownByte3 = U3;
            UnknownByte4 = U4;

            char[] NameCharAry = Enumerable.Repeat('\0', 24).ToArray();
            for (int i = 0; i < Name.ToCharArray().Length; i++)
            {
                NameCharAry[i] = Name.ToCharArray()[i];
            }

            PIC1NameCharArray = NameCharAry;

            PIC1_TransformData = pic1_Transform;

            VertexColorSet = new PIC1_VertexColorSet();
            Material_ID = MaterialID;
            Nr_Texture_Coordinates = (short)layout2DTextureCoordinates.Count;
            Layout2DTextureCoordinate_List = layout2DTextureCoordinates;
        }

        public PIC1()
        {
            PIC1_Header = "pic1".ToCharArray();
            PIC1_Size = 0;

            UnknownByte1 = 0x00;
            UnknownByte2 = 0x00;
            UnknownByte3 = 0x00;
            UnknownByte4 = 0x00;

            PIC1NameCharArray = new char[24];

            PIC1_TransformData = new PIC1_Transform();

            VertexColorSet = new PIC1_VertexColorSet();
            Material_ID = 0;
            Nr_Texture_Coordinates = 0;
            Layout2DTextureCoordinate_List = new List<Layout2DTextureCoordinate>();
        }
    }
}
