using System;
using System.Collections;

namespace ConsoleApp1
{
    public class House : IComparable
    {
        public string Name;
        public string Address;
        public int Number_of_rooms;
        public int Price;
        public double Area;

        public House() { }

        public House(string Name, string Address, int Number_of_rooms, int Price, double Area)
        {
            this.Name = Name;
            this.Address = Address;
            this.Number_of_rooms = Number_of_rooms;
            this.Price = Price;
            this.Area = Area;
        }

        int IComparable.CompareTo(object obj)
        {
            House h = obj as House;
            if (h != null)
            {
                if (this.Price < h.Price)
                    return -1;
                else if (this.Price > h.Price)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр повинен бути типу House!");
            }
        }

        public class SortByPrice : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                House h1 = (House)x;
                House h2 = (House)y;
                if (h1.Price < h2.Price)
                    return -1;
                else if (h1.Price > h2.Price)
                    return 1;
                else
                    return 0;
            }
        }

        public class SortByArea : IComparer
        {
            public int Compare(object x, object y)
            {
                House h1 = (House)x;
                House h2 = (House)y;
                if (h1.Area < h2.Area)
                    return -1;
                else if (h1.Area > h2.Area)
                    return 1;
                else
                    return 0;
            }
        }
    }

    class Houses : IEnumerable
    {
        private House[] _houses;
        public Houses(House[] hs)
        {
            _houses = new House[hs.Length];
            for (int i = 0; i < hs.Length; i++)
                _houses[i] = hs[i];
        }

        public HousesEnum GetEnumerator()
        {
            return new HousesEnum(_houses);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public class HousesEnum : IEnumerator
        {
            public House[] _houses;

            int position = -1;

            public HousesEnum(House[] list)
            {
                _houses = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _houses.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public House Current
            {
                get
                {
                    try
                    {
                        return _houses[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            House h1 = new House("Building 1", "3246  Timber Oak Drive", 4, 63000, 68);
            House h2 = new House("Building 2", "1140  Lynn Avenue", 3, 42000, 72);
            House h3 = new House("Building 3", "2721  Petunia Way", 6, 78000, 240);
            House h4 = new House("Building 4", "4992  Spring Avenue", 3, 33000, 74);
            House h5 = new House("Building 5", "414  Summit Street", 4, 54000, 98);
            House h6 = new House("Building 6", "664  Glenwood Avenue", 5, 80000, 152);
            House h7 = new House("Building 7", "1752  Browning Lane", 2, 24000, 49);
            House h8 = new House("Building 8", "3574  Big Indian", 4, 51000, 82);
            House h9 = new House("Building 9", "4218  Crummit Lane", 3, 58000, 78);
            House h10 = new House("Building 10", "4559  Holly Street", 4, 92000, 98);

            House[] houses = new House[10];
            houses[0] = h1;
            houses[1] = h2;
            houses[2] = h3;
            houses[3] = h4;
            houses[4] = h5;
            houses[5] = h6;
            houses[6] = h7;
            houses[7] = h8;
            houses[8] = h9;
            houses[9] = h10;

            string prn01 = "Назва:\t\tАдреса:\t\t\t\tКiлькiсть кiмнат:\tЦiна ($):\tПлоща (кв.м):";

            Console.WriteLine("Список без сортування");
            Console.WriteLine(prn01);
            for (int i = 0; i < houses.Length; i++)
                Console.WriteLine(houses[i].Name + "\t" + houses[i].Address + "\t\t" + houses[i].Number_of_rooms + "\t\t\t" + houses[i].Price + "\t\t" + houses[i].Area);

            while (true)
            {
                Console.WriteLine("\nНатиснiть на одну з вказаних клавiш, щоб вибрати режим роботи: ");
                Console.WriteLine("Реалiзацiя iнтерфейсу  IComparable для порiвняння будинкiв за цiною  - 1");
                Console.WriteLine("Реалiзацiя в класi iнтерфейсу IComparer для порiвняння будинкiв за цiною i за площею - 2");
                Console.WriteLine("Реалiзацiя iнтерфейсу IEnumerable - 3");
                Console.WriteLine("Вихiд з програми - будь-яка iнша клавiша");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.NumPad1)
                {
                    Array.Sort(houses);
                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < houses.Length; i++)
                        Console.WriteLine(houses[i].Name + "\t" + houses[i].Address + "\t\t" + houses[i].Number_of_rooms + "\t\t\t" + houses[i].Price + "\t\t" + houses[i].Area);
                }
                else if (cki.Key == ConsoleKey.NumPad2)
                {
                    Array.Sort(houses, new House.SortByPrice());
                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < houses.Length; i++)
                        Console.WriteLine(houses[i].Name + "\t" + houses[i].Address + "\t\t" + houses[i].Number_of_rooms + "\t\t\t" + houses[i].Price + "\t\t" + houses[i].Area);
                    
                    Array.Sort(houses, new House.SortByArea());
                    Console.WriteLine("\nСортування за площею");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < houses.Length; i++)
                        Console.WriteLine(houses[i].Name + "\t" + houses[i].Address + "\t\t" + houses[i].Number_of_rooms + "\t\t\t" + houses[i].Price + "\t\t" + houses[i].Area);
                }
                else if (cki.Key == ConsoleKey.NumPad3)
                {
                    Array.Sort(houses, new House.SortByPrice());
                    Houses HouseCollections01 = new Houses(houses);

                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    foreach (var house in HouseCollections01)
                        Console.WriteLine(house.Name + "\t" + house.Address + "\t\t" + house.Number_of_rooms + "\t\t\t" + house.Price + "\t\t" + house.Area);

                    Array.Sort(houses, new House.SortByArea());
                    Houses HouseCollections02 = new Houses(houses);

                    Console.WriteLine("\nСортування за площею");
                    Console.WriteLine(prn01);
                    foreach (var house in HouseCollections02)
                        Console.WriteLine(house.Name + "\t" + house.Address + "\t\t" + house.Number_of_rooms + "\t\t\t" + house.Price + "\t\t" + house.Area);
                }
                else
                    break;
            }
        }
    }
}
