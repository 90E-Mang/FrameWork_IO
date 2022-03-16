using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_FileStream_BufferStream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[127];
            byte[] writedata = new byte[127];
            FileStream file = new FileStream(@"D:\temp\stream.txt", FileMode.OpenOrCreate, FileAccess.Write);
            BufferedStream bs = new BufferedStream(file);
            for (int i = 0; i < 127; i++)
            {
                data[i] = (byte)(i + 1);            //[1][2][3][4]......
            }
            foreach (byte b in data)
            {
                Console.WriteLine(b);
            }
            bs.Write(data, 0, data.Length);
            bs.Close();

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");


            file = new FileStream(@"D:\temp\stream.txt", FileMode.Open, FileAccess.Read);
            bs = new BufferedStream(file);
            bs.Read(writedata, 0, writedata.Length);
            for (int i = 0; i < writedata.Length; i++)
            {
                Console.WriteLine("writedata : {0}", i);
            }
            Console.WriteLine(Encoding.ASCII.GetString(writedata));
            bs.Close();
        }
    }
}
