using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.Component
{
    public class PAN1
    {
        public char[] PAN1_Header { get; set; }
        public int PAN1Size { get; set; }

        public byte Flag { get; set; }
        public byte Origin { get; set; }
        public byte Alpha { get; set; }
        public byte Pane_Magnification_Flags { get; set; }

        public char[] PaneNameCharArray { get; set; } //0x24
        public string Pane_Name => new string(PaneNameCharArray);

        public PAN1_Transform PAN1_TransformData { get; set; }
        public class PAN1_Transform
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

            public void Read_PAN1_Transform(BinaryReader br, byte[] BOM)
            {
                TranslateData.Read_Translate(br, BOM);
                RotateData.Read_Rotate(br, BOM);
                ScaleData.Read_Scale(br, BOM);
                SizeData.Read_Size(br, BOM);
            }

            public void Write_PAN1_Transform(BinaryWriter bw)
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

            public PAN1_Transform(Translate translate, Rotate rotate, Scale scale, Size size)
            {
                TranslateData = translate;
                RotateData = rotate;
                ScaleData = scale;
                SizeData = size;
            }

            public PAN1_Transform()
            {
                TranslateData = new Translate();
                RotateData = new Rotate();
                ScaleData = new Scale();
                SizeData = new Size();
            }
        }

        public LayoutNode LayoutNode { get; set; }

        public void Read_PAN1(BinaryReader br, byte[] BOM)
        {
            //long PAN1_Pos = br.BaseStream.Position;

            PAN1_Header = br.ReadChars(4);
            if (new string(PAN1_Header) != "pan1") throw new Exception("PAN1 : 不明なフォーマットです");

            EndianConvert endianConvert = new EndianConvert(BOM);

            PAN1Size = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);

            Flag = br.ReadByte();
            Origin = br.ReadByte();
            Alpha = br.ReadByte();
            Pane_Magnification_Flags = br.ReadByte();
            PaneNameCharArray = br.ReadChars(24);

            PAN1_TransformData.Read_PAN1_Transform(br, BOM);

            //TODO : Seek => AllPaneDataLength
            LayoutNode.ReadLayoutNode(br, BOM);
        }

        public void Write_PAN1(BinaryWriter bw)
        {
            bw.Write(PAN1_Header);
            bw.Write(GetPAN1Size());
            bw.Write(Flag);
            bw.Write(Origin);
            bw.Write(Alpha);
            bw.Write(Pane_Magnification_Flags);

            bw.Write(PaneNameCharArray);

            LayoutNode.WriteLayoutData(bw);
        }

        public int GetPAN1Size()
        {
            int size = PAN1_Header.Length +
                       sizeof(int) +
                       sizeof(byte) +
                       sizeof(byte) +
                       sizeof(byte) +
                       sizeof(byte) +
                       PaneNameCharArray.Length +
                       PAN1_TransformData.GetSize() + 
                       LayoutNode.GetSize();

            return size;
        }

        public PAN1(string Name, byte Flag, byte Origin, byte Alpha, byte MagnificationFlag, PAN1_Transform pAN1_Transform, LayoutNode layoutNode)
        {
            PAN1_Header = "pan1".ToCharArray();
            PAN1Size = GetPAN1Size();
            this.Flag = Flag;
            this.Origin = Origin;
            this.Alpha = Alpha;
            Pane_Magnification_Flags = MagnificationFlag;

            #region Name
            char[] NameCharAry = Enumerable.Repeat('\0', 24).ToArray();
            for(int i = 0; i < Name.ToCharArray().Length; i++)
            {
                NameCharAry[i] = Name.ToCharArray()[i];
            }

            PaneNameCharArray = NameCharAry;
            #endregion

            PAN1_TransformData = pAN1_Transform;
            LayoutNode = layoutNode;
        }

        public PAN1()
        {
            PAN1_Header = "pan1".ToCharArray();
            PAN1Size = 0;
            Flag = 0x00;
            Origin = 0x00;
            Alpha = 0x00;
            Pane_Magnification_Flags = 0x00;

            PaneNameCharArray = new char[24];

            PAN1_TransformData = new PAN1_Transform();

            LayoutNode = new LayoutNode();
        }
    }
}
