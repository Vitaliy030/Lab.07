using System;
using System.IO;
using System.Collections;

namespace ConsoleApp2
{
    public class Library : IComparable
    {
        public string AddressFILE = "D:\\ІТ\\Програмування\\Програми\\Lab.7\\ConsoleApp2\\Library.txt";

        public string prt01 = "Inventory number:\t\tAuthor:\t\t\tTitle:\t\t\t\tNumber of pages:\t\tYear of publication:";

        public int is_number(string input)
        {
            bool a = true;
            bool a0 = true;
            while (a0)
            {
                while (a)
                {
                    int d = input.Length;
                    foreach (char c in input)
                        if (char.IsNumber(c))
                        {
                            if ((input[0] == '0') && (d != 1))
                            {
                                Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                                input = Console.ReadLine();
                                a = true;
                                break;
                            }
                            a = false;
                        }
                        else if ((input[0] == '-') && (d != 1) && (input[1] != '-'))
                            continue;
                        else
                        {
                            Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                            input = Console.ReadLine();
                            a = true;
                            break;
                        }
                }

                if (Convert.ToInt32(input) >= 0)
                {
                    a0 = false;
                }
                else
                {
                    Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                    input = Console.ReadLine();
                    a = true;
                }
            }
            return Convert.ToInt32(input);
        }

        private int Inventory_number;
        private string Author;
        private string Title;
        private int Number_of_pages;
        private int Year_of_publication;

        public int inventory_number
        {
            get
            {
                return Inventory_number;
            }
            set
            {
                Inventory_number = value;
            }
        }
        public string author
        {
            get
            {
                return Author;
            }
            set
            {
                Author = value;
            }
        }
        public string title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }
        public int number_of_pages
        {
            get
            {
                return Number_of_pages;
            }
            set
            {
                Number_of_pages = value;
            }
        }
        public int year_of_publication
        {
            get
            {
                return Year_of_publication;
            }
            set
            {
                Year_of_publication = value;
            }
        }

        public Library() { }

        public void Add()
        {
            Library np = new Library();

            Console.WriteLine("\nВведiть iнвентарний номер книги: ");
            np.inventory_number = is_number(Console.ReadLine());

            Console.WriteLine("Введiть прiзвище автора книги: ");
            np.author = Console.ReadLine();

            Console.WriteLine("Введiть назву книги (без пробiлiв, використовуйте _ ): ");
            np.title = Console.ReadLine();

            bool a00 = true; 
            while (a00)
            {
                a00 = false;
                for (int i = 0; i < np.title.Length; i++)
                {
                    if (Char.IsWhiteSpace(np.title[i]))
                    {
                        Console.WriteLine("Ви ввели некоректне значення, введiть ще раз!");
                        np.title = Console.ReadLine();
                        a00 = true;
                        break;
                    }
                }

            }

            Console.WriteLine("Введiть кiлькiсть сторiнок книги: ");
            np.number_of_pages = is_number(Console.ReadLine());

            Console.WriteLine("Введiть рiк видання книги: ");
            np.year_of_publication = is_number(Console.ReadLine());

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(AddressFILE, true))
                        f.WriteLine("{0}\t\t\t{1}\t\t\t{2}\t\t{3}\t\t\t\t{4}", np.inventory_number, np.author, np.title, np.number_of_pages, np.year_of_publication);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Edit()
        {
            Library ep = new Library();
            int count = File.ReadAllLines(AddressFILE).Length;

            Console.WriteLine("\nВведiть порядковий новер запису, де ви хочете здiйснити редагування: ");
            int n = is_number(Console.ReadLine());
            while (n > count - 1 || n < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n = is_number(Console.ReadLine());
            }

            string[] s0 = File.ReadAllLines(AddressFILE);
            string s = s0[n];
            int u = s.Length;

            int k = 0;
            int l = 1;

            foreach (char c in s)
            {
                if (Char.IsWhiteSpace(c))
                    break;
                k++;
            }
            ep.inventory_number = Convert.ToInt32(s.Substring(0, k));

            for (int i = k + 1; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            k++;
            for (int i = k + 1; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.author = s.Substring(k, l);

            k += l;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.title = s.Substring(k, l - 1);

            k = k + l - 1;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.number_of_pages = Convert.ToInt32(s.Substring(k, l));

            k = k + l - 1;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.year_of_publication = Convert.ToInt32(s.Substring(k, l - 1));

            Console.WriteLine("Введiть порядковий номер стовпчика, елемент якого хочете виправити: ");
            int n0 = is_number(Console.ReadLine());
            while (n0 > 5 || n0 < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n0 = is_number(Console.ReadLine());
            }

            if (n0 == 1)
            {
                Console.WriteLine("Iнвентарний номер: ");
                ep.inventory_number = is_number(Console.ReadLine());
            }
            else if (n0 == 2)
            {
                Console.WriteLine("Прiзвище автора книги: ");
                ep.author = Console.ReadLine();
            }
            else if (n0 == 3)
            {
                Console.WriteLine("Назва книги (без пробiлiв, використовуйте _ ): ");
                ep.title = Console.ReadLine();

                bool a00 = true;
                while (a00)
                {
                    a00 = false;
                    for (int i = 0; i < ep.title.Length; i++)
                    {
                        if (Char.IsWhiteSpace(ep.title[i]))
                        {
                            Console.WriteLine("Ви ввели некоректне значення, введiть ще раз!");
                            ep.title = Console.ReadLine();
                            a00 = true;
                            break;
                        }
                    }

                }
            }
            else if (n0 == 4)
            {
                Console.WriteLine("Кiлькiсть сторiнок у книзi: ");
                ep.number_of_pages = is_number(Console.ReadLine());
            }
            else if (n0 == 5)
            {
                Console.WriteLine("Рiк видання книги: ");
                ep.year_of_publication = is_number(Console.ReadLine());
            }

            while (true)
            {
                Console.WriteLine("Якщо ви бажаєте продовжити редагування в даному рядку, то натиснiть на будь-яку клавiшу, якщо нi, то натиснiть Spacebar.");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    break;
                else
                {
                    Console.WriteLine("\nВведiть порядковий номер стовпчика, елемент якого хочете виправити: ");
                    n0 = is_number(Console.ReadLine());
                    while (n0 > 5 || n0 < 1)
                    {
                        Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                        n0 = is_number(Console.ReadLine());
                    }

                    if (n0 == 1)
                    {
                        Console.WriteLine("Iнвентарний номер: ");
                        ep.inventory_number = is_number(Console.ReadLine());
                    }
                    else if (n0 == 2)
                    {
                        Console.WriteLine("Прiзвище автора книги: ");
                        ep.author = Console.ReadLine();
                    }
                    else if (n0 == 3)
                    {
                        Console.WriteLine("Назва книги (без пробiлiв, використовуйте _ ): ");
                        ep.title = Console.ReadLine();

                        bool a00 = true;
                        while (a00)
                        {
                            a00 = false;
                            for (int i = 0; i < ep.title.Length; i++)
                            {
                                if (Char.IsWhiteSpace(ep.title[i]))
                                {
                                    Console.WriteLine("Ви ввели некоректне значення, введiть ще раз!");
                                    ep.title = Console.ReadLine();
                                    a00 = true;
                                    break;
                                }
                            }

                        }
                    }
                    else if (n0 == 4)
                    {
                        Console.WriteLine("Кiлькiсть сторiнок у книзi: ");
                        ep.number_of_pages = is_number(Console.ReadLine());
                    }
                    else if (n0 == 5)
                    {
                        Console.WriteLine("Рiк видання книги: ");
                        ep.year_of_publication = is_number(Console.ReadLine());
                    }
                }
            }

            s = ep.inventory_number + "\t\t\t" + ep.author + "\t\t\t" + ep.title + "\t\t" + ep.number_of_pages + "\t\t\t\t" + ep.year_of_publication;

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    s0[n] = s;
                    using (StreamWriter f = new StreamWriter(AddressFILE))
                        for (int i = 0; i < count; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Remove()
        {
            int count = File.ReadAllLines(AddressFILE).Length;
            Console.WriteLine("\nВведiть порядковий новер рядка, який ви хочете видалити: ");
            int n = is_number(Console.ReadLine());
            while (n > count - 1 || n < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n = is_number(Console.ReadLine());
            }

            string[] s0 = File.ReadAllLines(AddressFILE);
            for (int i = n; i < count - 1; i++)
                s0[i] = s0[i + 1];

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(AddressFILE))
                        for (int i = 0; i < count - 1; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Output()
        {
            string[] s0 = File.ReadAllLines(AddressFILE);
            int count = File.ReadAllLines(AddressFILE).Length;

            Console.WriteLine("\nЯкщо ви бажаєте вивести весь список, то натиснiть Enter, якщо тiльки один рядок, то будь-яку iншу клавiшу.\n");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine(s0[i]);
            }
            else
            {
                Console.WriteLine("\nВведiть порядковий новер товару, який ви хочете вивести: ");
                int n = is_number(Console.ReadLine());
                while (n > count - 1 || n < 1)
                {
                    Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                    n = is_number(Console.ReadLine());
                }
                string s = s0[n];
                Console.WriteLine("\n" + prt01 + "\n" + s);
            }
            Console.WriteLine("\n");
        }

        public void Sort()
        {
            string[] s0 = File.ReadAllLines(AddressFILE);
            int count = File.ReadAllLines(AddressFILE).Length;

            Library[] books = new Library[count - 1];

            for (int j0 = 1; j0 < count; j0++)
            {
                Library book0 = new Library();

                string s = s0[j0];
                int u0 = s.Length;
                int k0 = 0;
                int l0 = 1;

                foreach (char c in s)
                {
                    if (Char.IsWhiteSpace(c))
                        break;
                    k0++;
                }
                book0.inventory_number = Convert.ToInt32(s.Substring(0, k0));

                for (int i = k0 + 1; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        k0++;
                    else
                        break;
                }

                k0++;
                for (int i = k0 + 1; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        break;
                    l0++;
                }
                book0.author = s.Substring(k0, l0);

                k0 += l0;
                l0 = 1;
                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        k0++;
                    else
                        break;
                }

                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        break;
                    l0++;
                }
                book0.title = s.Substring(k0, l0 - 1);

                k0 = k0 + l0 - 1;
                l0 = 1;
                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        k0++;
                    else
                        break;
                }

                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        break;
                    l0++;
                }
                book0.number_of_pages = Convert.ToInt32(s.Substring(k0, l0));

                k0 = k0 + l0 - 1;
                l0 = 1;
                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        k0++;
                    else
                        break;
                }

                for (int i = k0; i < u0; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        break;
                    l0++;
                }
                book0.year_of_publication = Convert.ToInt32(s.Substring(k0, l0 - 1));

                books[j0 - 1] = book0;
            }

            Console.WriteLine("\nНатиснiть на одну з вказаних клавiш, щоб вибрати, за яким параметром сортувати: ");
            Console.WriteLine("За роком видання - 1");
            Console.WriteLine("За iнвентарним номером - 2");
            Console.WriteLine("За кiлькiстю сторiнок - 3");
            Console.WriteLine("Вихiд з даного режиму - будь-яка iнша клавiша");

            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.NumPad1)
            {
                Array.Sort(books);
                Console.WriteLine("\nСортування за роком видання");
                Console.WriteLine(prt01);
                for (int i = 0; i < books.Length; i++)
                    Console.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);

                Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(AddressFILE))
                    {
                        f.WriteLine(prt01);
                        for (int i = 0; i < books.Length; i++)
                            f.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);
                    }
                    Console.WriteLine("Змiни збережено!\n\n");
                }
                else
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
            }
            else if (cki.Key == ConsoleKey.NumPad2)
            {
                Array.Sort(books, new SortByInventory_number());
                Console.WriteLine("\nСортування за iнвентарним номером");
                Console.WriteLine(prt01);
                for (int i = 0; i < books.Length; i++)
                    Console.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);

                Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(AddressFILE))
                    {
                        f.WriteLine(prt01);
                        for (int i = 0; i < books.Length; i++)
                            f.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);
                    }
                    Console.WriteLine("Змiни збережено!\n\n");
                }
                else
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
            }
            else if (cki.Key == ConsoleKey.NumPad3)
            {
                Array.Sort(books, new SortByNumber_of_pages());
                Console.WriteLine("\nСортування за кiлькiстю сторiнок");
                Console.WriteLine(prt01);
                for (int i = 0; i < books.Length; i++)
                    Console.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);

                Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(AddressFILE))
                    {
                        f.WriteLine(prt01);
                        for (int i = 0; i < books.Length; i++)
                            f.WriteLine(books[i].inventory_number + "\t\t\t" + books[i].author + "\t\t\t" + books[i].title + "\t\t" + books[i].number_of_pages + "\t\t\t\t" + books[i].year_of_publication);
                    }
                    Console.WriteLine("Змiни збережено!\n\n");
                }
                else
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
            }
            else
                Console.WriteLine();
        }

        public int CompareTo(object obj)
        {
            Library book = obj as Library;
            if (book != null)
            {
                if (this.Year_of_publication < book.Year_of_publication)
                    return -1;
                else if (this.Year_of_publication > book.Year_of_publication)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр повинен бути типу Library!");
            }
        }


        public class SortByInventory_number : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Library b1 = (Library)x;
                Library b2 = (Library)y;
                if (b1.Inventory_number < b2.Inventory_number)
                    return -1;
                else if (b1.Inventory_number > b2.Inventory_number)
                    return 1;
                else
                    return 0;
            }
        }

        public class SortByNumber_of_pages : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Library b1 = (Library)x;
                Library b2 = (Library)y;
                if (b1.Number_of_pages < b2.Number_of_pages)
                    return -1;
                else if (b1.Number_of_pages > b2.Number_of_pages)
                    return 1;
                else
                    return 0;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Library book = new Library();

            while (true)
            {
                Console.WriteLine("Натиснiть на одну з вказаних клавiш, щоб вибрати режим роботи: ");
                Console.WriteLine("Додавання записiв - Enter");
                Console.WriteLine("Редагування записiв - E");
                Console.WriteLine("Знищення записiв - R");
                Console.WriteLine("Виведення iнформацiї з файла на екран - O");
                Console.WriteLine("Сортування - Tab");
                Console.WriteLine("Вихiд з програми - будь-яка iнша клавiша");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                    book.Add();
                else if (cki.Key == ConsoleKey.E)
                    book.Edit();
                else if (cki.Key == ConsoleKey.R)
                    book.Remove();
                else if (cki.Key == ConsoleKey.O)
                    book.Output();
                else if (cki.Key == ConsoleKey.Tab)
                    book.Sort();
                else
                    break;
            }
        }
    }
}
