using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_sort
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int N = 10;

            bool[] a_d = new bool[N + 1]; //중복 방지
            for (int j = 1; j <= N; j++)
                a_d[j] = false;
            int[] arr = new int[N];
            int[] arr_ = new int[N];
            for (int j = 0; j < N; j++)
            {
                int t = rnd.Next(1, N + 1);
                while (a_d[t])
                {
                    t = rnd.Next(1, N + 1);
                }
                arr[j] = t;
                a_d[t] = true;
            }

            Console.WriteLine("Original Array");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr[j] + ", ");
            }
            Console.Write("\n");

            Sort_visual sort_visual = new Sort_visual();

            arr.CopyTo(arr_, 0);
            sort_visual.Quick_Sort(ref arr_);
            Console.WriteLine("Quick Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            }
            Console.Write("\n");

            /*
            Sort sort = new Sort();

            arr.CopyTo(arr_, 0);
            sort.Selection_Sort(ref arr_);
            Console.WriteLine("Selection Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            } Console.Write("\n");

            arr.CopyTo(arr_, 0);
            sort.Insertion_Sort(ref arr_);
            Console.WriteLine("Insertion Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            }
            Console.Write("\n");

            arr.CopyTo(arr_, 0);
            sort.Merge_Sort(ref arr_);
            Console.WriteLine("Merge Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            }
            Console.Write("\n");

            arr.CopyTo(arr_, 0);
            sort.Heap_Sort(ref arr_);
            Console.WriteLine("Heap Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            }
            Console.Write("\n");

            arr.CopyTo(arr_, 0);
            sort.Quick_Sort(ref arr_);
            Console.WriteLine("Quick Sort");
            for (int j = 0; j < N; j++)
            {
                Console.Write(arr_[j] + ", ");
            }
            Console.Write("\n");
            */
            Console.ReadLine();
        }
    }
}
