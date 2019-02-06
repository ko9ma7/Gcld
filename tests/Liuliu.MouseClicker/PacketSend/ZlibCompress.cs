﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib;

namespace Liuliu.MouseClicker.PacketSend
{
    /**//// <summary>
        /// Zlib压缩算法压缩应用类
        /// </summary>
    public class ZlibCompress
    {
        /**//// <summary>
        /// 拷贝复制流字节
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[2048];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }

        /**//// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="FileName">被压缩文件名（必须输入绝对路径）</param>
        /// <param name="CompressedFileName">压缩后保存的文件名（必须输入绝对路径）</param>
        /// <returns></returns>
        public static bool CompressFile(string FileName, string CompressedFileName)
        {
            bool bResult = false;

            FileStream outFileStream = new FileStream(CompressedFileName, FileMode.Create);
            ZOutputStream outZStream = new ZOutputStream(outFileStream, zlibConst.Z_DEFAULT_COMPRESSION);
            FileStream inFileStream = new FileStream(FileName, FileMode.Open);
            try
            {
                CopyStream(inFileStream, outZStream);
                bResult = true;
            }
            catch
            {
                bResult = false;
            }
            finally
            {
                outZStream.Close();
                outFileStream.Close();
                inFileStream.Close();
            }
            return bResult;
        }

        /**//// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="CompressedFileName">被解压文件名（必须输入绝对路径）</param>
        /// <param name="DecompressFileName">解压后保存的文件名（必须输入绝对路径）</param>
        /// <returns></returns>
        public static bool DecompressFile(string CompressedFileName, string DecompressFileName)
        {
            bool bResult = false;
            FileStream outFileStream = new FileStream(DecompressFileName, FileMode.Create);
            ZOutputStream outZStream = new ZOutputStream(outFileStream);
            FileStream inFileStream = new FileStream(CompressedFileName, FileMode.Open);
            try
            {
                CopyStream(inFileStream, outZStream);
                bResult = true;
            }
            catch
            {
                bResult = false;
            }
            finally
            {
                outZStream.Close();
                outFileStream.Close();
                inFileStream.Close();
            }
            return bResult;
        }

        /**//// <summary>
        /// 压缩byte数组数据
        /// </summary>
        /// <param name="SourceByte">需要被压缩的Byte数组数据</param>
        /// <returns></returns>
        public static byte[] CompressBytes(byte[] SourceByte)
        {
            try
            {
                MemoryStream stmInput = new MemoryStream(SourceByte);
                Stream stmOutPut = ZlibCompress.CompressStream(stmInput);
                byte[] bytOutPut = new byte[stmOutPut.Length];
                stmOutPut.Position = 0;
                stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);
                return bytOutPut;
            }
            catch
            {
                return null;
            }
        }

        /**//// <summary>
        /// 解压byte数据数据
        /// </summary>
        /// <param name="SourceByte">需要被解压的byte数组数据</param>
        /// <returns></returns>
        public static byte[] DecompressBytes(byte[] SourceByte)
        {
            try
            {
                MemoryStream stmInput = new MemoryStream(SourceByte);
                Stream stmOutPut = ZlibCompress.DecompressStream(stmInput);
                byte[] bytOutPut = new byte[stmOutPut.Length];
                stmOutPut.Position = 0;
                stmOutPut.Read(bytOutPut, 0, bytOutPut.Length);
                return bytOutPut;
            }
            catch
            {
                return null;
            }
        }

        /**//// <summary>
        /// 压缩流
        /// </summary>
        /// <param name="SourceStream">需要被压缩的流数据</param>
        /// <returns></returns>
        public static Stream CompressStream(Stream SourceStream)
        {
            try
            {
                MemoryStream stmOutTemp = new MemoryStream();
                ZOutputStream outZStream = new ZOutputStream(stmOutTemp, zlibConst.Z_DEFAULT_COMPRESSION);
                CopyStream(SourceStream, outZStream);
                outZStream.finish();
                return stmOutTemp;
            }
            catch
            {
                return null;
            }
        }

        /**//// <summary>
        /// 解压流
        /// </summary>
        /// <param name="SourceStream">需要被解缩的流数据</param>
        /// <returns></returns>
        public static Stream DecompressStream(Stream SourceStream)
        {
            try
            {
                MemoryStream stmOutput = new MemoryStream();
                ZOutputStream outZStream = new ZOutputStream(stmOutput);
                CopyStream(SourceStream, outZStream);
                outZStream.finish();
                return stmOutput;
            }
            catch
            {
                return null;
            }
        }

        /**//// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="SourceString">需要被压缩的字符串</param>
        /// <returns></returns>
        public static string CompressString(string SourceString)
        {
            byte[] byteSource = System.Text.Encoding.UTF8.GetBytes(SourceString);
            byte[] byteCompress = ZlibCompress.CompressBytes(byteSource);
            if (byteCompress != null)
            {
                return Convert.ToBase64String(byteCompress);
            }
            else
            {
                return null;
            }
        }

        /**//// <summary>
        /// 解压字符串
        /// </summary>
        /// <param name="SourceString">需要被解压的字符串</param>
        /// <returns></returns>
        public static string DecompressString(string SourceString)
        {
            byte[] byteSource = Convert.FromBase64String(SourceString);
            byte[] byteDecompress = ZlibCompress.DecompressBytes(byteSource);
            if (byteDecompress != null)
            {
                return System.Text.Encoding.UTF8.GetString(byteDecompress);
            }
            else
            {
                return null;
            }
        }
    }

    }
