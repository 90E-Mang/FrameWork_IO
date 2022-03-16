using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex01_File
{
    /*
        입출력(IO)
        1. stream : 중간 매게체 "빨대" 라고 생각하자
        1.1 Byte stream - 이미지 처리 등을 위해 필요함.
        1.2 : 문자(2Byte) stream - 우리가 대부분 사용하는 stream
        1.3 : 하나의 stream은 한번에 하나만 작업할 수 있다(입력 따로, 출력 따로 --> 입출력 동시에 안됨)
        나를 기준으로 바이트 저장소에서 데이터가 들어오면 ? -> 입력 stream
        나를 기준으로 데이터가 밖으로 나간다면 ? -> 출력 stream

        2. C#에서는 System.IO; 
        2.1 File
        2.2 Directory
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Temp\test.txt";
            /*
            File.Create(path);

            if (File.Exists(path))
            {
                Console.WriteLine($"{path} 파일이 존재합니다.");
            }
            else
            {
                Console.WriteLine($"{path} 파일이 생성되지 않았습니다.");
            }
            */
            File.AppendAllText(path,"추가추가 합니다");
            DateTime dt = File.GetCreationTime(path);
            Console.WriteLine(dt.ToLongTimeString());

            dt = File.GetLastAccessTime(path);
            Console.WriteLine($"Last : {dt.ToLongTimeString()}");
        }
    }
}
