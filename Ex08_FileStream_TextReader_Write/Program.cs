using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_FileStream_TextReader_Write
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\temp\aa.txt";
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                sw.WriteLine("Text 쓰기작업");
                sw.WriteLine("오늘도 이렇게");
                sw.WriteLine("하루가 지나가네요");
            }

            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }

                Console.WriteLine("[위치를 통한 출력]");

                sr.BaseStream.Seek(3, SeekOrigin.Begin);

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}
