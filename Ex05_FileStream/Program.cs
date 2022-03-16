using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex05_FileStream
{
    //Stream : IO 최상위 클래스(읽기 , 쓰기 , 검색등의 작업)

    //*FileStream : 바이트단의 전송을 통한 파일의 입출력

    //bufferStream : 버퍼는 메모리의 바이트 블록으로서 데이터를 캐시하여           --> 바이트를 모아서 담는 공간(buffer)를 생성해서 뭉탱이로 통신.
    // 운영 체제에 대한 호출 수를 줄이는 데 사용됩니다. 따라서 
    // 버퍼는 읽기 및 쓰기 성능을 향상시킵니다. 
    //읽기 또는 쓰기에 버퍼를 사용할 수 있지만 둘 모두에 동시에 사용할 수는 없습니다.

    //MemoryStream :MemoryStream 클래스에서는 디스크나 네트워크 연결 ---> 딱히 잘 안씀. collection류랑 비슷한건데 그냥 collection을 씀..
    //대신 메모리를 백업 저장소로 사용하는 스트림을 만듭니다. 


    //StringReader & StringWriter 클래스는 문자열을 스트림에 기록하거나
    //읽어낼 때 사용하는 클래스(목표지점이 string형의 데이터)

    //StreamReader와 StreamWirter 클래스는 바이트 스트림을 문자스트림으로
    //바꾸어 주는 역활을 담당하는 스트림입니다
    //기본적으로 이 스트림으 TextReader , TextWriter에서 상속받튼 문자스트림입니다
    //바이트 스트림을 문자스트림으로 변환하고자 한다면 StreamReader와 StreamWriter사용

    //BinaryReader 와 BinaryWirter 클래스는 데이터 타입에 해당하는 메모리 사이즈에
    //따라서 바이너리 형식으로 읽거나 기록할 수 있는 스트립입니다
    //C#에서 사용하는 int형의 수는 4바이트를 차지합니다 , 단순히 4라는 숫자를 저장하는
    //것은 문자로 4를 기록하는 것과 같습니다, 하지만 이러한 데이터를 데이터 집합에 맞게
    //저장한다면 데이터타입별로 읽어 올 수도 있을 것입니다
    //만약 int형수 1000을 4바이트 공간에 BinaryWriter로 기록한다면 BinaryReader로 
    //읽을 때에는 ReadInt32() 메서드를 4바이트 단위로 수를 읽어내야 합니다
    class Program
    {
        static void Main(string[] args)
        {
            // 아래는 원론적인 방법이나 예외처리도 안되는 문제가 있어 권장되지 않음.
            //FileStream fs = new FileStream("hello.txt",FileMode.OpenOrCreate);
            //// 경로를 안적었을 때, default 경로는 어디? --> 실행파일이 있는 곳
            //// 이 프로젝트의 경우 (교육장 기준 D:\Ecount\Labs\FrameWork_IO\Ex05_FileStream\bin\Debug 이 default 경로)
            //StreamWriter streamWriter = new StreamWriter(fs);       // 문자기반 데이터 write ....
            //
            //int data = 100;
            //float fdata = 3.14f;
            //string strdata = "hello world";
            //
            //streamWriter.Write(data); // \r\n 이 적용되지 않음. 
            //streamWriter.Write(fdata);
            //streamWriter.Write(strdata);
            //
            //streamWriter.Close();           // network나 file 관련은 GC가 수거하지 않으므로 이렇게 직접 닫아줘야됨
            //fs.Close();

            // 아래는 위의 코드를 try catch를 활용해서 정석적으로 짜는 방법.
            // 예외가 발생하던가 말던가 무조건 close()를 통해 자원을 해제
            // FileStream fs = null;
            // StreamWriter streamWriter = null;
            // try
            // {
            //     fs = new FileStream("hello.txt", FileMode.OpenOrCreate);
            //     streamWriter = new StreamWriter(fs);
            //     int data = 100;
            //     float fdata = 3.14f;
            //     string strdata = "hello world";
            // 
            //     streamWriter.Write(data);
            //     streamWriter.Write(fdata);
            //     streamWriter.Write(strdata);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            //     Console.WriteLine(e.StackTrace);
            // }
            // finally
            // {
            //     *만일 좀더 제대로 코드를 만들고 싶으면?
            //     if(streamWriter != null)
            //     {
            //          streamWriter.Close();  
            //     }
            //     if(fs != null)
            //     {
            //          fs.Close(); 
            //     }
            // }

            // 위의 try catch 대신해서 using 구문을 써보자
            // 근데 using 하려고 보니 필요한 객체가 FileStream이랑 StreamWriter가 있는데 어떻게할까? using 안에 1개밖에 못쓰는데..          
            using (StreamWriter sw = new StreamWriter(new FileStream("hello2.txt", FileMode.OpenOrCreate))) // <- 다형성을 이용
            {                                                        // StreamWriter의 생성자 parameter에 상위 클래스인 stream이 가능하니 FileStream도 올 수 있다.
                int data = 100;
                float fdata = 3.14f;
                string strdata = "hello world";

                sw.WriteLine(data); // \r\
                sw.WriteLine(fdata);
                sw.WriteLine(strdata);
            }
            // using 블럭을 벗어나면 자동 Close() >> finally 구문과 같음.
        }
    }
}
