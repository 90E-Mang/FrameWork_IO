using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex04_File_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            if (args.Length < 1)
            {
                Console.WriteLine("사용법 : 파일.exe [디렉토리 경로]");
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(args[0]); // C:\windows 
            if (dirInfo.Exists)
            {
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo dir in dirs)             // C:\windows\temp > 파일 존재
                {
                    FileInfo[] files = dir.GetFiles();
                    Console.WriteLine($"디렉토리 : {dir.FullName}, 파일수 : {files.Length}");

                    int index = 0;
                    foreach (FileInfo file in files)        //test.txt.. x.jpg, ....
                    {
                        string str = string.Format($"[{++index}] : Name : {file.Name} , Extention{file.Extension} , size{file.Length}");
                        Console.WriteLine(str);
                    }
                }
            }
        }
    }
}
