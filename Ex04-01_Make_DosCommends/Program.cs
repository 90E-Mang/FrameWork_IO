using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex04_01_Make_DosCommends
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("사용법: 파일.exe [옵션]  [현재 디렉토리명]  [파일명] [옮길 디렉토리명]");
                Console.WriteLine("[옵션] : -mv 파일이동");
                Console.WriteLine("사용법 : 파일.exe rd [/S] [/Q] [드라이브 경로] ");
                Console.WriteLine("[옵션] : -rd 하위 디렉토리와 파일까지 삭제");
                Console.WriteLine("/Q : 지정된 디렉터리 자체와, 그 안의 모든 디렉터리 및 파일을 지웁니다.디렉터리 트리를 지우는데 사용합니다.");
                Console.WriteLine("/S : 조용한 모드로, /S로 디렉터리 트리를 지우는데 문제가 없으면 다시 묻지 않습니다.");
                Console.WriteLine("사용법: 파일.exe [옵션] [디렉토리명] [파일명]");
                Console.WriteLine("[옵션] : -del 하나 이상의 파일을 지웁니다.");
                Console.WriteLine("사용법: 파일.exe [옵션]  [현재 디렉토리명]  [파일명] [옮길 디렉토리명]");
                Console.WriteLine("[옵션] : -cp 파일복사");
                return;
            }
            DirectoryInfo nowdir = new DirectoryInfo(args[1]);
            
            if (args[0].Trim() == "-mv")
            {
                DirectoryInfo newDir = new DirectoryInfo(args[3]);
                FileInfo[] fileInfo = nowdir.GetFiles();
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Name == args[2])
                    {
                        item.MoveTo($@"{args[3]}\{item.Name}");
                    }
                }
                
            }
            else if (args[0].Trim() == "-rd")
            {
                if (args.Length == 2)
                {

                    DirectoryInfo dir = new DirectoryInfo(args[1]);

                    try
                    {
                        dir.Delete();
                        return;
                    }
                    catch
                    {
                        Console.WriteLine("디렉터리가 비어있지 않습니다.");
                    }


                }

                else if (args.Length == 3)
                {
                    if (args[1].Trim() == "/S")
                    {
                        DirectoryInfo dir = new DirectoryInfo(args[2]);
                        Console.WriteLine("하위 디렉터리 및 파일을 지우시겠습니까? Y , N");
                        string select = Console.ReadLine();
                        if (select == "Y")
                        {
                            dir.Delete(true);
                            return;
                        }
                        else return;

                    }
                    else
                    {
                        Console.WriteLine("명령 구문이 올바르지 않습니다.");
                        return;
                    }

                }
                else if (args.Length == 4)
                {
                    if (args[1].Trim() == "/S" && args[2] == "/Q")
                    {
                        DirectoryInfo dir = new DirectoryInfo(args[3]);
                        dir.Delete(true);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("명령 구문이 올바르지 않습니다.");
                        return;
                    }

                }
            }
            
            else if (args[0].Trim() == "del")
            {
                FileInfo files = new FileInfo(args[2]);
                files.Delete();
            }
            else if (args[0].Trim() == "-cp")
            {
                DirectoryInfo newDir = new DirectoryInfo(args[3]);
                FileInfo[] fileInfo = nowdir.GetFiles();
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Name == args[2])
                    {
                        item.CopyTo($@"{args[3]}\{item.Name}");
                    }
                }
            }
        }
    }
}
