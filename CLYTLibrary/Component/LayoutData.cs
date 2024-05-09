using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLYTLibrary.Component.LayoutData;

namespace CLYTLibrary.Component
{
    public class LayoutNode
    {
        public PAS1 PAS1 { get; set; }
        public Dictionary<int, LayoutData> LayoutDict { get; set; }
        public PAE1 PAE1 { get; set; }

        public void ReadLayoutNode(BinaryReader br, byte[] BOM)
        {
            long Pos = br.BaseStream.Position;
            char[] HeaderCheck = br.ReadChars(4);
            string HeaderString = new string(HeaderCheck);
            br.BaseStream.Position = Pos;

            if (HeaderString == "pas1")
            {
                PAS1 pas1 = new PAS1();
                pas1.ReadPAS1(br, BOM);
                PAS1 = pas1;

                int i = 0;
                while (HeaderString != "pae1")
                {
                    long CurPos = br.BaseStream.Position;
                    char[] HeaderCheck_Loop = br.ReadChars(4);
                    string HeaderString_Loop = new string(HeaderCheck_Loop);
                    br.BaseStream.Position = CurPos;

                    if (HeaderString_Loop == "pic1")
                    {
                        PIC1 pIC1 = new PIC1();
                        pIC1.Read_PIC1(br, BOM);

                        LayoutData layoutData = new LayoutData(LayoutType.PIC1, pIC1);

                        LayoutDict.Add(i, layoutData);
                        i++;
                    }
                    else if (HeaderString_Loop == "pan1")
                    {
                        PAN1 pAN1 = new PAN1();
                        pAN1.Read_PAN1(br, BOM);

                        LayoutData layoutData = new LayoutData(LayoutType.PAN1, pAN1);

                        LayoutDict.Add(i, layoutData);
                        i++;
                    }
                    else if (HeaderString_Loop == "pae1")
                    {
                        PAE1 pae1 = new PAE1();
                        pae1.ReadPAE1(br, BOM);
                        PAE1 = pae1;

                        break;
                    }
                }
            }
            else
            {
                PAS1 = null;
                LayoutDict = null;
                PAE1 = null;
                return;
            }
        }

        public void WriteLayoutData(BinaryWriter bw)
        {
            if (PAS1 != null)
            {
                PAS1.WritePAS1(bw);
                if (LayoutDict != null || LayoutDict.Count != 0)
                {
                    foreach (var item in LayoutDict)
                    {
                        if (item.Value.CLYT_LayoutType == LayoutType.PAN1)
                        {
                            PAN1 pan1 = (PAN1)item.Value.LayoutObject;
                            pan1.Write_PAN1(bw);
                        }
                        else if (item.Value.CLYT_LayoutType == LayoutType.PIC1)
                        {
                            PIC1 pic1 = (PIC1)item.Value.LayoutObject;
                            pic1.Write_PIC1(bw);
                        }
                        else if (item.Value.CLYT_LayoutType == LayoutType.BND1)
                        {
                            //BND1
                        }
                        else if (item.Value.CLYT_LayoutType == LayoutType.WND1)
                        {
                            //WND1
                        }
                    }

                    if (PAE1 != null)
                    {
                        PAE1.WritePAE1(bw);
                    }
                }
            }


        }

        public int GetSize()
        {
            int size = PAS1.PAS1_Size + PAE1.PAE1_Size;

            foreach (var i in LayoutDict)
            {
                if (i.Value.LayoutObject is PAN1)
                {
                    PAN1 pan1 = (PAN1)i.Value.LayoutObject;
                    size += pan1.PAN1Size;
                }
                else if (i.Value.LayoutObject is PIC1)
                {
                    PIC1 pic1 = (PIC1)i.Value.LayoutObject;
                    size += pic1.PIC1_Size;
                }
                
            }

            return size;
        }

        public LayoutNode()
        {
            PAS1 = new PAS1();
            LayoutDict = new Dictionary<int, LayoutData>();
            PAE1 = new PAE1();
        }
    }

    public class LayoutData
    {
        public enum LayoutType
        {
            //LYT1,
            //TXL1,
            //FNL1,
            //MAT1,

            //PAS1,
            //PAE1,
            PAN1,
            PIC1,
            BND1,
            WND1,

            EMPTY
        }

        public LayoutType CLYT_LayoutType { get; set; }
        public object LayoutObject { get; set; }

        public T GetLayoutData<T>()
        {
            T data = (T)new object();
            if (LayoutObject is T)
            {
                data = (T)LayoutObject;

                #region Hide
                //if ((CLYT_LayoutType == LayoutType.LYT1 && LayoutObject is T) == true)
                //{
                //    data = (T)LayoutObject;
                //}
                //else if ((CLYT_LayoutType == LayoutType.TXL1 && LayoutObject is T) == true)
                //{

                //}
                #endregion
            }
            else
            {
                throw new Exception("[!] UnDefined Data [!]");
            }

            #region Hide
            //if ((CLYT_LayoutType == LayoutType.LYT1 && LayoutObject is T) == true)
            //{
            //    data = (T)LayoutObject;
            //}
            //else if ((CLYT_LayoutType == LayoutType.TXL1 && LayoutObject is T) == true)
            //{

            //}
            #endregion

            return data;
        }

        public LayoutData(LayoutType layoutType, object LayoutObject)
        {
            CLYT_LayoutType = layoutType;
            this.LayoutObject = LayoutObject;
        }

        public LayoutData()
        {
            CLYT_LayoutType = LayoutType.EMPTY;
            LayoutObject = new object();
        }
    }
}
