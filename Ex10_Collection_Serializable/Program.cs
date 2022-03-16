using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ex10_Collection_Serializable
{
    // 여러객체를 계속해서 직렬화해서 사용하게 되면 불편..
    // 객체가 몇개 있는지 확인도 해야됨.

    // ->  File >> 하나의 파일에 여러개의 객체를 직렬화하면?

    // 여러개의 객체를 한번에 저장하기 위해 -> Collection !
    // -> Collection > List<> , Dictionary<> 사용하여 한번만 write, read 한다

    [Serializable]
    class Emp
    {
        public int empno;
        public string ename;
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
            Stream stream = new FileStream("Semp.txt",FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Emp> empList = new List<Emp>();
            empList.Add(new Emp(17931119, "임현기"));
            empList.Add(new Emp(17931110, "윤상혁"));
            empList.Add(new Emp(17931105, "박민우"));

            formatter.Serialize(stream,empList);
            stream.Close();

            Stream rs = new FileStream("Semp.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            List<Emp> list = (List<Emp>)bf.Deserialize(rs);

            foreach (var Emp in list)
            {
                Console.WriteLine($"empno : {Emp.empno}, ename : {Emp.ename}");
            }
        }
    }
}
