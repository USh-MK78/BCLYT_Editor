using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Collections;
using CLYTLibrary;
using System.Net;

namespace BCLYT_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public CLYT CLYTData { get; set; }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_BCLYT = new OpenFileDialog()
            {
                Title = "BCLYTを開く",
                //InitialDirectory = @"C:\Users\User\Desktop",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "bclyt file|*.bclyt"
            };

            if (Open_BCLYT.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(Open_BCLYT.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                CLYT cLYT = new CLYT();
                cLYT.Read_CLYT(br);

                CLYTData = cLYT;

                br.Close();
                fs.Close();
            }
            else return;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save_BCLYT = new SaveFileDialog
            {
                Title = "Save BCLYT",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "bclyt file|*.bclyt"
            };

            if (Save_BCLYT.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(Save_BCLYT.FileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);

                CLYT cLYT = CLYTData;
                cLYT.Write_BCLYT(bw);

                bw.Close();
                fs.Close();
            }
            else return;
        }

        private void bCLYTXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenBCLYT = new OpenFileDialog()
            {
                Title = "BCLYTを開く",
                //InitialDirectory = @"C:\Users\User\Desktop",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "bclyt file|*.bclyt"
            };

            if (OpenBCLYT.ShowDialog() == DialogResult.OK)
            {
                #region Read
                FileStream fs = new FileStream(OpenBCLYT.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                CLYT cLYT = new CLYT();
                cLYT.Read_CLYT(br);

                br.Close();
                fs.Close();
                #endregion

                #region Xml
                CLYTLibrary.XMLConvert.BCLYT_XML CLYTXml = new CLYTLibrary.XMLConvert.BCLYT_XML(cLYT);
                //Delete Namespaces
                var xns = new XmlSerializerNamespaces();
                xns.Add(string.Empty, string.Empty);

                StreamWriter sw = new StreamWriter(OpenBCLYT.FileName + "_out.xml", false, new System.Text.UTF8Encoding(false));
                XmlSerializer serializer = new XmlSerializer(typeof(CLYTLibrary.XMLConvert.BCLYT_XML));
                serializer.Serialize(sw, CLYTXml, xns);
                sw.Close();
                #endregion
            }
            else return;
        }

        private void xMLBCLYTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Xml2BCLYTDir = new OpenFileDialog()
            {
                Title = "Xmlを開く",
                InitialDirectory = Environment.CurrentDirectory,
                //InitialDirectory = @"C:\Users\User\Desktop",
                Filter = "xml file|*.xml"
            };

            if (Xml2BCLYTDir.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(Xml2BCLYTDir.FileName, new System.Text.UTF8Encoding(false));
                XmlSerializer serializer = new XmlSerializer(typeof(CLYTLibrary.XMLConvert.BCLYT_XML));
                CLYTLibrary.XMLConvert.BCLYT_XML cLYT_XML = (CLYTLibrary.XMLConvert.BCLYT_XML)serializer.Deserialize(sw);
                sw.Close();


                //CLYTLibrary.Component.LYT1 lYT1 = new CLYTLibrary.Component.LYT1(cLYT_XML.LYT1_Xml.Canvas_XSize, cLYT_XML.LYT1_Xml.Canvas_YSize, cLYT_XML.LYT1_Xml.Origin_Type)

                //CLYT cLYT1 = new CLYT();


                //FileStream fs = new FileStream(Xml2BCLYTDir.FileName + "_out.bclyt", FileMode.Create, FileAccess.Write);
                //BinaryWriter bw = new BinaryWriter(fs);

                //CLYT cLYT = CLYTData;
                //cLYT.Write_BCLYT(bw);

                //bw.Close();
                //fs.Close();
            }
            else return;
        }
    }
}
