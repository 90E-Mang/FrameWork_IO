using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex06_FileStream2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 파일 읽기 - read
            //FileStream fs = new FileStream("hello2.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs);
            //// Console.WriteLine(sr.ReadLine());   // text
            //// Console.WriteLine(sr.ReadLine());   // text
            //// Console.WriteLine(sr.ReadLine());   // text
            //
            //int data = int.Parse(sr.ReadLine());
            //float fdata = float.Parse(sr.ReadLine());
            //string strdata = sr.ReadLine();
            //
            //sr.Close();
            //fs.Close();
            //Console.WriteLine($"{data},{fdata},{strdata}");

            // 위에꺼 using으로 바꾸면 ?
            //using (StreamReader sr = new StreamReader(new FileStream("hello2.txt", FileMode.Open, FileAccess.Read)))
            //{
            //    int data = int.Parse(sr.ReadLine());
            //    float fdata = float.Parse(sr.ReadLine());
            //    string strdata = sr.ReadLine();
            //
            //    sr.Close();
            //    Console.WriteLine($"{data}-{fdata}-{strdata}");
            //}
            // 순수하게 읽기만 할거라면 굳이 FileStream을 안써도 된다,.
            using (StreamReader sr = new StreamReader("hello2.txt"))    // read만 ! FileStream 옵션 없으면 생성.
            {
                int data = int.Parse(sr.ReadLine());
                float fdata = float.Parse(sr.ReadLine());
                string strdata = sr.ReadLine();

                sr.Close();
                Console.WriteLine($"{data}-{fdata}-{strdata}");
            }
        }
    }
}
