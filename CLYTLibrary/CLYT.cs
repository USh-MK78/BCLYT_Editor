using CLYTLibrary.Component;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLYTLibrary
{
    public class CLYT
    {
        public char[] CLYT_Header { get; set; }
        public byte[] BOM { get; set; }
        public short LYT1Size { get; set; } //Size
        //public LYT1 LYT1Data { get; set; }

        public byte[] Version { get; set; } //0x4
        public int FileSize { get; set; }
        public int NrSection { get; set; }
        public LYT1 LYT1Data { get; set; }

        public void Read_CLYT(BinaryReader br)
        {
            long CLYTPos = br.BaseStream.Position;

            CLYT_Header = br.ReadChars(4);
            if (new string(CLYT_Header) != "CLYT") throw new Exception("CLYT : 不明なフォーマットです");

            BOM = br.ReadBytes(2);

            EndianConvert endianConvert = new EndianConvert(BOM);

            LYT1Size = BitConverter.ToInt16(endianConvert.Convert(br.ReadBytes(2)), 0);

            #region DELETE
            //if (LYT1Offset != 0)
            //{
            //    long CurrentPos = br.BaseStream.Position;

            //    br.BaseStream.Position = CLYTPos;
            //    br.BaseStream.Seek(LYT1Offset, SeekOrigin.Current);

            //    LYT1Data.ReadLYT1(br, BOM);

            //    br.BaseStream.Position = CurrentPos;
            //}
            #endregion

            Version = endianConvert.Convert(br.ReadBytes(4));
            FileSize = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            NrSection = BitConverter.ToInt32(endianConvert.Convert(br.ReadBytes(4)), 0);
            if (LYT1Size != 0)
            {
                LYT1Data.ReadLYT1(br, BOM);
            }
        }

        public void Write_BCLYT(BinaryWriter bw)
        {
            bw.Write(CLYT_Header);
            bw.Write(BOM);
            bw.Write(GetSize());
            bw.Write(Version);

            #region WriteDummyFileSize
            long FileSizeWritePos = bw.BaseStream.Position;
            bw.Write((int)0);
            #endregion

            bw.Write(NrSection);
            LYT1Data.Write_LYT1(bw);

            #region Write FileSize
            long CurPos = bw.BaseStream.Position;

            bw.BaseStream.Position = FileSizeWritePos;
            bw.Write((int)CurPos);
            bw.BaseStream.Position = CurPos;
            #endregion
        }

        public short GetSize()
        {
            return (short)(CLYT_Header.Length + BOM.Length + sizeof(short) + Version.Length + sizeof(int) + sizeof(int));
        }

        public CLYT(LYT1 LYT1, EndianConvert.Endian endian)
        {
            CLYT_Header = "CLYT".ToCharArray();
            BOM = EndianConvert.GetEnumEndianToBytes(endian);
            LYT1Size = GetSize();
            Version = new byte[] { 0x00, 0x00, 0x02, 0x02 };
            FileSize = 0;
            NrSection = 0;
            LYT1Data = LYT1;
        }

        public CLYT()
        {
            CLYT_Header = "CLYT".ToCharArray();
            BOM = new byte[4];
            LYT1Size = 0;
            Version = new byte[4];
            FileSize = 0;
            NrSection = 0;
            LYT1Data = new LYT1();
        }
    }
}
