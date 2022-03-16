using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ex10_1_Collection_Serializable_TeamHomework
{
    [Serializable]
    public class Book
    {

        private readonly string isbn;
        private string title;
        private int price;


        public Book(string isbn, string title, int price)
        {
            this.isbn = isbn;
            this.title = title;
            this.price = price;
        }

        public override string ToString()
        {
            return string.Format($"ISBN : {isbn}, 책 제목 : {title}, 가격 : {price}");

        }
        public string ISBN()
        {
            return isbn;
        }       

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public int getPrice()
        {
            return price;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public string getIsbn()
        {
            return isbn;
        }
    }

    class BookManager
    {
        private Dictionary<string, Book> books;
        public BookManager()
        {
             books = new Dictionary<string, Book>();    
            //book.txt 파일이 존재하면 값을 읽어와서 Dictionary 저장
        }

        public void Run()
        {
            int key = 0;
            while ((key = selectMenu()) != 0)
            {
                switch (key)
                {
                    case 1:
                        addBook();
                        break;
                    case 2:
                        removeBook();
                        break;
                    case 3:
                        searchBook();
                        break;
                    case 4:
                        listBook();
                        break;
                    case 5:
                        listISBN();
                        break;
                    case 6:
                        save();
                        break;
                    case 7:
                        load();
                        break;
                    default:
                        Console.WriteLine("잘못 선택하였습니다.");
                        break;
                }
            }
            Console.WriteLine("종료합니다...");
        }
        private int selectMenu()
        {
            Console.WriteLine("1:추가 2:삭제 3:검색 4:도서 목록 5:ISBN 목록 6:저장 7:불러오기 0:종료");
            int key = int.Parse(Console.ReadLine());
            return key;
        }

        public void addBook()
        {
            //기존에 책이 존재하는 확인 하고
            //ISBN , title , price 정보를 받아서 Dictionary 추가        ISBN이 key값
            //(ISBN , book) 추가
            // new Dictionary<1902, new Book()>;

            string isbn = $"{DateTime.Now.ToString("yyMMddhhmmss")}";
            Console.Write("책 제목을 입력해주세요.");
            string title = Console.ReadLine();
            Console.Write("가격을 입력해주세요.");
            int price = Convert.ToInt32(Console.ReadLine());
            books.Add(isbn,new Book(isbn,title,price));
        }
        public void removeBook()
        {
            //삭제도서 입력 ISBN 받아서 
            // Dictionary 에서 삭제
            Console.Write("삭제하실 도서의 ISBN을 입력해주세요 : ");
            string isbn = Console.ReadLine();
            
            if (books.ContainsKey(isbn))
            {
                books.Remove(isbn);
            }
            else
            {
                Console.WriteLine("ISBN이 없습니다. 다시 입력해 주세요");
            }
        }
        public void searchBook()
        {
            //ISBN 정보 입력 받아
            //책정보 조회
            if (books.Count == 0)
            {
                Console.WriteLine("저장된 도서목록이 없습니다.");
                return;
            }
            Console.Write("찾으시는 도서의 ISBN을 입력해주세요 : ");
            string isbn = Console.ReadLine();
            foreach (var temp in books)
            {
                if (isbn == temp.Key)
                {
                    Console.WriteLine(temp.Value.ToString());
                    return;
                }
            }
            Console.WriteLine("찾는 도서가 없습니다.");
        }
        public void listBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("저장된 도서가 없습니다.");
                return;
            }
            //모든 도서 목록 조회
            foreach (var Book in books)
            {
                Console.WriteLine(Book.Value.ToString());
            }
        }
        public void listISBN()
        {
            if (books.Count <= 0)
            {
                Console.WriteLine("저장되어 있는 책이 없습니다.");
            }
            else
            {
                int i = 1;
                Console.WriteLine($"총 도서수 : {books.Count}");

                foreach (var book in books)
                {
                    Console.WriteLine($"{i}번책 :{book.Key} \n");
                    i++;
                }
            }
            //총 도서수와
            //ISBN 출력
        }

        public void save()  //
        {
            // book.txt 에 책 정보를 담고 있는 객체를 저장 (직렬화) : Dictionary
            using (Stream stream = new FileStream("Library.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, books);
                Console.WriteLine("파일에 저장을 완료했습니다.");
            }                           
        }
        public void load()
        {
            // 책 정보를 담고 있는 book.txt 에 객체 읽어서 화면에 출력 (역직렬화)
            // List<Emp> list = (List<Emp>)bf.Deserialize(rs); 이런 식으로 새로 선언 하지말고 주소값에 덮어버리기.
            string path = $@"D:\Ecount\Labs\FrameWork_IO\Ex10-1_Collection_Serializable_TeamHomework\bin\Debug\Library.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("저장된 파일이 없습니다.");
                return;
            }
            using (Stream stream = new FileStream("Library.txt", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                books = (Dictionary<string, Book>)bf.Deserialize(stream);

                foreach (var item in books)
                {
                    Console.WriteLine(item.Value.ToString());
                }
            }                         
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookManager manager = new BookManager();
            manager.Run();
        }
    }
}
