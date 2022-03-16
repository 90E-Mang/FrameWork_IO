using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ex09_Serializable
{
    [Serializable]
    class Emp
    {
        public int empno;
        public string ename;
        [NonSerialized]
        public string job = "IT";
        public Emp(int empno, string ename) 
        {
            this.empno = empno;
            this.ename = ename;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 직렬화 객체를 파일에 write 
            Stream stream = new FileStream("Emp.txt",FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();  // 직렬화 위한 객체 생성 !
            Emp emp = new Emp(17931119, "임현기");

            // 직렬화
            formatter.Serialize(stream, emp);       // Emp.txt 파일에 emp 객체를 직렬화해서 write 하겠다. 근데 직렬화된 자원은 역직렬화를 해야 읽을 수 있다.
            stream.Close();

            // 위에서 직렬화를 끝낸 자원은 반드시 역직렬화를 해서 읽어야함.
            // 역직렬화
            Stream rs = new FileStream("Emp.txt", FileMode.Open);
            BinaryFormatter br = new BinaryFormatter();
            Emp empdata = (Emp)br.Deserialize(rs);             // emp.txt 파일에 쓰여진 자원을 다시 조립! 원래 type로 casting 해줘야됨.

            Console.WriteLine($"{empdata.empno}, {empdata.ename}");
            Console.WriteLine($"{empdata.job}");            // 직렬화 대상이 아닌 job은 안나온다.
        }
    }
}
