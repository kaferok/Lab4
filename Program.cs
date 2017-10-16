using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set set0 = new Set(10);
            set0.Inic();
            set0.Show();
            Set set01 = new Set(20);
            set01.Inic();
            set01.Show();
            Console.WriteLine("\nСумма множеств");
            Set setsum = set0 + set01;
            setsum.Show();


            Console.WriteLine("\nДобавление элемента");
            int add = 10;
            Set add1 = new Set(add);
            add1.Inic();
            add1.Show();
            //add1 += add;
            //add1.Show();
            Set set = add1 + add;
            set.Show();
            
       



            if(setsum)
            {
                Console.WriteLine("Размер массиа находится в пределах от 0 до 100");
            }
            else
                Console.WriteLine("Размер массиа не находится в пределах от 0 до 100");

            set0.Str();
            set0.Show();

            Console.ReadKey();

        }
    }
    class Owner
    {
        private readonly int id;
        private readonly string name;
        private readonly string company;

        public Owner(int id, string name, string company)
        {
            this.id = id;
            this.name = name;
            this.company = company;
        }
    }

    class Set
    {
        class Date
        {
            string date;
            public Date(string date)
            {
                this.date = date;
            }
        }
        public int number=5;
        private int[] arr;
        private int size;
        private static Random rand = new Random();
        private readonly Owner owner = new Owner(17515, "Nikolai", "*Company");
        private readonly Date date = new Date("11.10.2017");
        private Set()
        {

        }
        public int Len { get { return size; } }

        public static bool operator false(Set size1)
        {
            if (size1.size < 0 || size1.size > 100)
                return true;
            return false;

        }
        public static bool operator true(Set size1)
        {
            if (size1.size < 0 || size1.size > 100)
                return false;
            return true;
        }
        public Set(int size)
        {
            arr = new int[size];
            this.size = size;


        }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= arr.Length)
                {

                    return 0;
                }
                return arr[i];
            }
            set
            {
                if (i < 0 || i > arr.Length - 1)
                {
                    Console.WriteLine("Incorrect index. Nothing installed " + i);
                }
                else
                    arr[i] = value;


            }
        }
        public void Resize(int size)
        {
            System.Array.Resize(ref arr, size);
            this.size = size;
        }

        public void Inic()
        {
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next() % 100;
            }
        }

        public void Show()
        {
            Console.WriteLine("Множессто: ");

            for (int i = 0; i < size; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");

        }

        public static explicit operator int(Set arr)
        {
            return arr.size;
        }
        public static Set operator +(Set arr1, Set arr2)
        {

            Set set = new Set(Math.Min(arr1.size, arr2.size));
            for (int i = 0; i < set.size; i++)
            {
                set[i] = arr1[i] + arr2[i];
            }
            return set;

        }
        public static Set operator +(Set arr1, int number)
        {
            Set set = new Set(arr1.size+1);
            //set.Resize(arr1.size + 1);
            for(int x = 0;x<arr1.size;x++)
            {
                set[x] = arr1[x];
            }
            set[arr1.size] = number;
            Console.WriteLine("DLinna "+set.size);
            return set;
        }

       
            
            
    }


    static class MyMath
    {
        public static int Max(Set arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Len; i++)
            {
                int el = arr[i];
                if (el > max)
                    max = el;
            }

            return max;
        }

        public static int Min(Set arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Len; i++)
            {
                int el = arr[i];
                if (el < min)
                    min = el;
            }

            return min;
        }

        public static int Sum(Set arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Len; i++)
                sum += arr[i];

            return sum;
        }

        public static string Str(this Set set)
        {
            
            string s= Convert.ToString(set);
            
            return s;
            

        }
    }

}
