using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex02_File_Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Temp\Temp2";
            Directory.CreateDirectory(path);

            Console.WriteLine(Directory.Exists(path)); // true, false
            string defaultDir = Directory.GetCurrentDirectory();        // 현재 실행되고 있는 파일의 디렉토리 줍기
            Console.WriteLine($"defaultDir : {defaultDir.ToString()}");

            string[] dirs = Directory.GetDirectories(@"E:\");
            Console.WriteLine($"E:드라이브 폴더 목록");
            foreach (string dir in dirs)
            {
                Console.WriteLine($"dir : {dir}");
            }

            // C:\windows 폴더 안에 있는 파일목록을 출력하세요

            path = @"C:\windows";
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine($"file name : {file}");
            }

            // 문제 : Directory.getFiles(@"C:\windows"); 안에서 확장자가 .bmp 인 것들만...

            string[] files_xml = Directory.GetFiles(@"C:\windows", "*.xml");
            foreach (string item in files_xml)
            {
                Console.WriteLine($"xml files : {item}");
            }
        }
    }
}
