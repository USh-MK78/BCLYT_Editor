using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary.XMLConvert
{
    ///<summary>
    ///ROOT
    ///<summary>
    [Serializable]
    [System.Xml.Serialization.XmlRoot("BCLYT")]
    public class BCLYT_XML
    {
        [System.Xml.Serialization.XmlElement("CLYT_INFO")]
        public CLYT_INFO CLYTINFO_Xml { get; set; }
        public class CLYT_INFO
        {
            [System.Xml.Serialization.XmlElement("Version")]
            public byte[] Version { get; set; }

            [System.Xml.Serialization.XmlElement("SectionCount")]
            public int SectionCount { get; set; }

            public CLYT_INFO(CLYT CLYTData)
            {
                Version = CLYTData.Version;
                SectionCount = CLYTData.NrSection;
            }

            public CLYT_INFO() { }
        }

        [System.Xml.Serialization.XmlElement("LYT1")]
        public LYT1 LYT1_Xml { get; set; }

        public BCLYT_XML(CLYT CLYTData)
        {
            CLYTINFO_Xml = new CLYT_INFO(CLYTData);
            LYT1_Xml = new LYT1(CLYTData.LYT1Data);
        }

        public BCLYT_XML() { }
    }

    public class LYT1
    {
        [System.Xml.Serialization.XmlElement("Origin_Type")]
        public int Origin_Type { get; set; }

        [System.Xml.Serialization.XmlElement("Canvas_XSize")]
        public float Canvas_XSize { get; set; }

        [System.Xml.Serialization.XmlElement("Canvas_YSize")]
        public float Canvas_YSize { get; set; }

        [System.Xml.Serialization.XmlElement("LayoutResource")]
        public List<LayoutResXml> LayoutResXml_List { get; set; } = new List<LayoutResXml>();
        public class LayoutResXml
        {
            [System.Xml.Serialization.XmlElement("TXL1")]
            public TXL1 TXL1Data { get; set; }

            [System.Xml.Serialization.XmlElement("MAT1")]
            public MAT1 MAT1Data { get; set; }

            [System.Xml.Serialization.XmlElement("FNL1")]
            public FNL1 FNL1Data { get; set; }

            [System.Xml.Serialization.XmlElement("PAN1")]
            public PAN1 PAN1Data { get; set; }

            public LayoutResXml(Component.LayoutResource obj)
            {
                var data = obj.LayoutResourceData;
                if (data is Component.TXL1)
                {
                    TXL1Data = new TXL1((Component.TXL1)data);
                }
                else if (data is Component.MAT1)
                {
                    MAT1Data = new MAT1((Component.MAT1)data);
                }
                else if (data is Component.FNL1)
                {
                    FNL1Data = new FNL1((Component.FNL1)data);
                }
                else if (data is Component.PAN1)
                {
                    PAN1Data = new PAN1((Component.PAN1)data);
                }
            }

            public LayoutResXml() { }
        }

        public LYT1(Component.LYT1 LYT1Data)
        {
            Origin_Type = LYT1Data.OriginTypeNum; //Enum
            Canvas_XSize = LYT1Data.Canvas_XSize;
            Canvas_YSize = LYT1Data.Canvas_YSize;

            foreach (var item in LYT1Data.LayoutResourceDictionary)
            {
                LayoutResXml_List.Add(new LayoutResXml(item.Value));
            }
        }

        public LYT1() { }
    }

    public class TXL1
    {
        [System.Xml.Serialization.XmlElement("Count")]
        public int TXL1Count { get; set; }

        [System.Xml.Serialization.XmlElement("TXL1_Name")]
        public List<TXL1_Name> TXL1NameList { get; set; } = new List<TXL1_Name>();
        public class TXL1_Name
        {
            //[System.Xml.Serialization.XmlElement("Pos")]
            //public int NamePos { get; set; }

            [System.Xml.Serialization.XmlText]
            public string Texture_Name { get; set; }

            public TXL1_Name(Component.TXL1.TexNameList texNameList)
            {
                Texture_Name = texNameList.TextureName;
            }

            public TXL1_Name() { }
        }

        public TXL1(Component.TXL1 TXL1Data)
        {
            TXL1Count = TXL1Data.TextureNameCount;

            foreach (var item in TXL1Data.TextureName_List)
            {
                TXL1NameList.Add(new TXL1_Name(item));
            }
        }

        public TXL1() { }
    }

    public class FNL1
    {
        [System.Xml.Serialization.XmlElement("Count")]
        public int FNL1Count { get; set; }

        [System.Xml.Serialization.XmlElement("FNL1_Name")]
        public List<FNL1_Name> FNL1NameList { get; set; } = new List<FNL1_Name>();
        public class FNL1_Name
        {
            [System.Xml.Serialization.XmlText]
            public string Font_Name { get; set; }

            public FNL1_Name(Component.FNL1.FontNameList fontNameList)
            {
                Font_Name = fontNameList.FontName;
            }

            public FNL1_Name() { }
        }

        public FNL1(Component.FNL1 FNL1Data)
        {
            FNL1Count = FNL1Data.FontCount;

            foreach (var item in FNL1Data.FontName_List)
            {
                FNL1NameList.Add(new FNL1_Name(item));
            }
        }

        public FNL1() { }
    }

    public class MAT1
    {
        [System.Xml.Serialization.XmlElement("Count")]
        public int MAT1_Count { get; set; }

        [System.Xml.Serialization.XmlElement("MAT1Data")]
        public List<MAT1_Layout> MAT1Layout_List { get; set; } = new List<MAT1_Layout>();
        public class MAT1_Layout
        {
            [System.Xml.Serialization.XmlElement("Material_Name")]
            public string MatName { get; set; }

            [System.Xml.Serialization.XmlElement("TevColor")]
            public TevColorXml TevColor_Xml { get; set; }
            public class TevColorXml
            {
                [System.Xml.Serialization.XmlAttribute("Data1")]
                public byte Data1 { get; set; }

                [System.Xml.Serialization.XmlAttribute("Data2")]
                public byte Data2 { get; set; }

                [System.Xml.Serialization.XmlAttribute("Data3")]
                public byte Data3 { get; set; }

                [System.Xml.Serialization.XmlAttribute("Data4")]
                public byte Data4 { get; set; }

                public TevColorXml(Component.MAT1.MatLayoutData.MatLayout.TevColor tevColor)
                {
                    Data1 = tevColor.Data1;
                    Data2 = tevColor.Data2;
                    Data3 = tevColor.Data3;
                    Data4 = tevColor.Data4;
                }

                public TevColorXml() { }
            }

            [System.Xml.Serialization.XmlElement("TevConstColor")]
            public TevConstantColor TevConstantColorData { get; set; }
            public class TevConstantColor
            {
                public class ConstantColorXML
                {
                    [System.Xml.Serialization.XmlAttribute("Data1")]
                    public byte Data1 { get; set; }

                    [System.Xml.Serialization.XmlAttribute("Data2")]
                    public byte Data2 { get; set; }

                    [System.Xml.Serialization.XmlAttribute("Data3")]
                    public byte Data3 { get; set; }

                    [System.Xml.Serialization.XmlAttribute("Data4")]
                    public byte Data4 { get; set; }

                    public ConstantColorXML(Component.MAT1.MatLayoutData.MatLayout.TevConstantColor.ConstantColor constantColor)
                    {
                        Data1 = constantColor.Data1;
                        Data2 = constantColor.Data2;
                        Data3 = constantColor.Data3;
                        Data4 = constantColor.Data4;
                    }

                    public ConstantColorXML() { }
                }

                [System.Xml.Serialization.XmlElement("TevConstColor_0")]
                public ConstantColorXML ConstantColor0 { get; set; }

                [System.Xml.Serialization.XmlElement("TevConstColor_1")]
                public ConstantColorXML ConstantColor1 { get; set; }

                [System.Xml.Serialization.XmlElement("TevConstColor_2")]
                public ConstantColorXML ConstantColor2 { get; set; }

                [System.Xml.Serialization.XmlElement("TevConstColor_3")]
                public ConstantColorXML ConstantColor3 { get; set; }

                [System.Xml.Serialization.XmlElement("TevConstColor_4")]
                public ConstantColorXML ConstantColor4 { get; set; }

                [System.Xml.Serialization.XmlElement("TevConstColor_5")]
                public ConstantColorXML ConstantColor5 { get; set; }

                public TevConstantColor(Component.MAT1.MatLayoutData.MatLayout.TevConstantColor tevConstantColor)
                {
                    ConstantColor0 = new ConstantColorXML(tevConstantColor.ConstantColor0);
                    ConstantColor1 = new ConstantColorXML(tevConstantColor.ConstantColor1);
                    ConstantColor2 = new ConstantColorXML(tevConstantColor.ConstantColor2);
                    ConstantColor3 = new ConstantColorXML(tevConstantColor.ConstantColor3);
                    ConstantColor4 = new ConstantColorXML(tevConstantColor.ConstantColor4);
                    ConstantColor5 = new ConstantColorXML(tevConstantColor.ConstantColor5);
                }

                public TevConstantColor() { }
            }

            [System.Xml.Serialization.XmlElement("FragOrBit")]
            public int FlagOrBit { get; set; }

            [System.Xml.Serialization.XmlElement("TextureIndex")]
            public short TexIndex { get; set; }

            [System.Xml.Serialization.XmlElement("Bitfield1")]
            public byte Bitfield1 { get; set; }

            [System.Xml.Serialization.XmlElement("Bitfield2")]
            public byte Bitfield2 { get; set; }

            [System.Xml.Serialization.XmlElement("LayoutTransform")]
            public LayoutTransformXML LayoutTransformData { get; set; }
            public class LayoutTransformXML
            {
                [System.Xml.Serialization.XmlElement("Transform_XY")]
                public Translate_XML Translate { get; set; }
                public class Translate_XML
                {
                    [System.Xml.Serialization.XmlAttribute("X")]
                    public float X { get; set; }

                    [System.Xml.Serialization.XmlAttribute("Y")]
                    public float Y { get; set; }

                    public Translate_XML(Component.MAT1.MatLayoutData.MatLayout.LayoutTransform.Translate translate)
                    {
                        this.X = translate.X;
                        this.Y = translate.Y;
                    }

                    public Translate_XML() { }
                }

                [System.Xml.Serialization.XmlElement("Rotation")]
                public float Rotation { get; set; }

                [System.Xml.Serialization.XmlElement("Scale_XY")]
                public Scale_XML Scale { get; set; }
                public class Scale_XML
                {
                    [System.Xml.Serialization.XmlAttribute("X")]
                    public float X { get; set; }

                    [System.Xml.Serialization.XmlAttribute("Y")]
                    public float Y { get; set; }

                    public Scale_XML(Component.MAT1.MatLayoutData.MatLayout.LayoutTransform.Scale scale)
                    {
                        this.X = scale.X;
                        this.Y = scale.Y;
                    }

                    public Scale_XML() { }
                }

                public LayoutTransformXML(Component.MAT1.MatLayoutData.MatLayout.LayoutTransform layoutTransform)
                {
                    Translate = new Translate_XML(layoutTransform.TranslateXY);
                    this.Rotation = layoutTransform.Rotation;
                    Scale = new Scale_XML(layoutTransform.ScaleXY);
                }

                public LayoutTransformXML() { }
            }

            [System.Xml.Serialization.XmlAttribute("UnknownByteArray0")]
            public byte[] UnknownByteArray0_XML { get; set; }

            public MAT1_Layout(Component.MAT1.MatLayoutData.MatLayout matLayout)
            {
                MatName = new string(matLayout.MatNameCharArray);
                TevColor_Xml = new TevColorXml(matLayout.TevColorData);
                TevConstantColorData = new TevConstantColor(matLayout.TevConstantColorData);
                FlagOrBit = matLayout.FlagOrBit;
                TexIndex = matLayout.TexIndex;
                Bitfield1 = matLayout.Bitfield1;
                Bitfield2 = matLayout.Bitfield2;
                LayoutTransformData = new LayoutTransformXML(matLayout.LayoutTransformData);
                UnknownByteArray0_XML = matLayout.UnknownByteArray0;
            }

            public MAT1_Layout() { }
        }

        public MAT1(Component.MAT1 mAT1)
        {
            MAT1_Count = mAT1.MatCount;

            for (int i = 0; i < mAT1.MatCount; i++)
            {
                MAT1Layout_List.Add(new MAT1_Layout(mAT1.MatLayoutData_List[i].Mat_Layout));
            }
        }

        public MAT1() { }
    }

    public class PAN1
    {
        [System.Xml.Serialization.XmlElement("Flag")]
        public byte Flag { get; set; }

        [System.Xml.Serialization.XmlElement("Origin")]
        public byte Origin { get; set; }

        [System.Xml.Serialization.XmlElement("Alpha")]
        public byte Alpha { get; set; }

        [System.Xml.Serialization.XmlElement("MagnificationFlag")]
        public byte Pane_Magnification_Flags { get; set; }

        [System.Xml.Serialization.XmlElement("Pane_Name")]
        public string Pane_Name { get; set; }

        [System.Xml.Serialization.XmlElement("TransformData")]
        public TransformDataXML TransformData_XML { get; set; }
        public class TransformDataXML
        {
            [System.Xml.Serialization.XmlElement("Translation")]
            public Translation translation { get; set; }
            public class Translation
            {
                [System.Xml.Serialization.XmlAttribute("X")]
                public float X { get; set; }

                [System.Xml.Serialization.XmlAttribute("Y")]
                public float Y { get; set; }

                [System.Xml.Serialization.XmlAttribute("Z")]
                public float Z { get; set; }

                public Translation(Component.PAN1.PAN1_Transform.Translate translate)
                {
                    X = translate.X;
                    Y = translate.Y;
                    Z = translate.Z;
                }

                public Translation() { }
            }

            [System.Xml.Serialization.XmlElement("Rotation")]
            public Rotation rotation { get; set; }
            public class Rotation
            {
                [System.Xml.Serialization.XmlAttribute("X")]
                public float X { get; set; }

                [System.Xml.Serialization.XmlAttribute("Y")]
                public float Y { get; set; }

                [System.Xml.Serialization.XmlAttribute("Z")]
                public float Z { get; set; }

                public Rotation(Component.PAN1.PAN1_Transform.Rotate rotate)
                {
                    X = rotate.X;
                    Y = rotate.Y;
                    Z = rotate.Z;
                }

                public Rotation() { }
            }

            [System.Xml.Serialization.XmlElement("Scale")]
            public Scale scale { get; set; }
            public class Scale
            {
                [System.Xml.Serialization.XmlAttribute("X")]
                public float X { get; set; }

                [System.Xml.Serialization.XmlAttribute("Y")]
                public float Y { get; set; }

                public Scale(Component.PAN1.PAN1_Transform.Scale scale)
                {
                    X = scale.X;
                    Y = scale.Y;
                }

                public Scale() { }
            }

            [System.Xml.Serialization.XmlElement("Size")]
            public Size size { get; set; }
            public class Size
            {
                [System.Xml.Serialization.XmlAttribute("X")]
                public float X { get; set; }

                [System.Xml.Serialization.XmlAttribute("Y")]
                public float Y { get; set; }

                public Size(Component.PAN1.PAN1_Transform.Size size)
                {
                    X = size.X;
                    Y = size.Y;
                }

                public Size() { }
            }

            public TransformDataXML(Component.PAN1.PAN1_Transform Transform)
            {
                translation = new Translation(Transform.TranslateData);
                rotation = new Rotation(Transform.RotateData);
                scale = new Scale(Transform.ScaleData);
                size = new Size(Transform.SizeData);
            }

            public TransformDataXML() { }
        }

        [System.Xml.Serialization.XmlElement("Sub_LayoutNode")]
        public LayoutNode SubLayoutNode { get; set; }
        public class LayoutNode
        {
            ////PAS1, PAE1...
            //[System.Xml.Serialization.XmlElement("PAS1")]
            //public PAS1 PAS1Data { get; set; }
            //public class PAS1
            //{
            //    [System.Xml.Serialization.XmlAttribute("EnableFlag")]
            //    public bool IsEnable { get; set; } 

            //    public PAS1(Component.PAS1 pas1)
            //    {
            //        if (pas1.)
            //    }

            //    public PAS1() { }
            //}

            [System.Xml.Serialization.XmlElement("LayoutData")]
            public List<LayoutDataXml> LayoutDataXml_List { get; set; } = new List<LayoutDataXml>();
            public class LayoutDataXml
            {
                //[System.Xml.Serialization.XmlElement("PIC1")]
                //public PIC1 PIC1Data { get; set; }

                [System.Xml.Serialization.XmlElement("PAN1")]
                public PAN1 PAN1Data { get; set; }

                public LayoutDataXml(Component.LayoutData layoutData)
                {
                    var data = layoutData.LayoutObject;
                    if (data is Component.PAN1)
                    {
                        PAN1Data = new PAN1((Component.PAN1)data);
                    }
                    //else if (data is Component.PIC1)
                    //{
                    //    PIC1Data = new MAT1((Component.PIC1)data);
                    //}
                }

                public LayoutDataXml() { }
            }

            public LayoutNode(Component.LayoutNode layoutNode)
            {
                if ((layoutNode.PAS1 != null && layoutNode.LayoutDict != null && layoutNode.PAE1 != null) == true)
                {
                    foreach (var item in layoutNode.LayoutDict)
                    {
                        LayoutDataXml layoutData = new LayoutDataXml(item.Value);
                        LayoutDataXml_List.Add(layoutData);
                    }
                }
            }

            public LayoutNode() { }
        }

        public PAN1(Component.PAN1 PAN1Data)
        {
            Flag = PAN1Data.Flag;
            Origin = PAN1Data.Origin;
            Alpha = PAN1Data.Alpha;
            Pane_Magnification_Flags = PAN1Data.Pane_Magnification_Flags;
            Pane_Name = PAN1Data.Pane_Name;

            TransformData_XML = new TransformDataXML(PAN1Data.PAN1_TransformData);
            SubLayoutNode = new LayoutNode(PAN1Data.LayoutNode);
        }

        public PAN1() { }
    }
}
