using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex03_FileInfo_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Program Files (x86)\Internet Explorer");
            if (dirInfo.Exists)
            {
                Console.WriteLine($"전체경로 : {dirInfo.FullName}");
                Console.WriteLine($"디렉토리이름 : {dirInfo.Name}");
                Console.WriteLine($"생성일 : {dirInfo.CreationTime}");
                Console.WriteLine($"디렉토리 속성 : {dirInfo.Attributes}");
                Console.WriteLine($"루트경로 : {dirInfo.Root}");
                Console.WriteLine($"부모 디렉토리 : {dirInfo.Parent}");
            }
            else
            {
                Console.WriteLine("디렉토리 없음.");
            }

            FileInfo finfo = new FileInfo(@"E:\Temp\test.txt");
            if (finfo.Exists)
            {
                Console.WriteLine($"폴더이름 : {finfo.Directory}");
                Console.WriteLine($"파일이름 : {finfo.Name}");
                Console.WriteLine($"확장자 : {finfo.Extension}");
                Console.WriteLine($"생성일 : {finfo.CreationTime}");
                Console.WriteLine($"파일크기 : {finfo.Length}byte");
                Console.WriteLine($"속성 : {finfo.Attributes}");
            }
            else
            {
                Console.WriteLine("디렉토리 없음.");
            }
        }
    }
}
