using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{


    class Sort

    {
        public int[] GetRandArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next();
            }
            return array;
        }

        public int[] GetRandomArray_from_0_to_10(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0,10);
            }

            return array;
        }

        public int[] GetNearOrderedArray(int size)
        {
            int n = 100;
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                    array[i] = i + 1;        
            }

            for (int j = array.Length - n-1; j < array.Length-1; j++)
            {
                array[j] = rand.Next();
            }

            return array;
        }

        public void Show(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public void InsertSort(int[] array)
        {
            int iteration=0;
            int place;
            int j;

            for (int i = 0; i < array.Length; i++)
            {
                place = array[i];
                j = i - 1;

                while (j >= 0 && array[j] > place)
                {
                    array[j + 1] = array[j];
                    j--;
                   iteration++;
                }
                array[j + 1] = place;
                
            }
            Console.WriteLine("Количество итераций - " + iteration.ToString());

        }

        private int Partition(int[] array, int start, int end)
        {

            int pivot = array[end];

            int i = start;
            for (int j = start; j < end; j++)
            {

                if (array[j] <= pivot)
                {

                    Swap(ref array[i], ref array[j]);
                    i++;

                }
            }

            Swap(ref array[i], ref array[end]);

            return i;
        }

        public void QuickSort(int[] array, int start, int end)
        {

            if (start < end)
            {
                int q = Partition(array, start, end);
                QuickSort(array, start, q - 1);
                QuickSort(array, q + 1, end);

            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void CountSort(int[] array)
        {
            ulong iteration = 0;
            int[] sortedArray = new int[array.Length];


  

            int[] counts = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                counts[i] = 0;
                iteration++;
            }

                  
            for (int i = 0; i < array.Length; ++i)
            {
                ++counts[array[i]];
                iteration++;
            }

 
            for (int i = 1; i <= array.Length - 1; ++i)
            {
                counts[i] += counts[i - 1];
                iteration++;
            }

        
            for (int i = array.Length - 1; i >= 0; i--)
            {

                sortedArray[counts[array[i]] - 1] = array[i];
                --counts[array[i]];
                iteration++;
            }

        

            for (int i = 0; i < array.Length; ++i)
            { 
                array[i] = sortedArray[i];
                iteration++;
            }
            Console.WriteLine("Количество итераций - " + iteration.ToString());
        }


        public void MergeSort(int[] array, int size)
        {

            int half1;
            int half2;

            if (size % 2 == 0)
            {
                half1 = size / 2;
                half2 = size / 2;
            }
            else
            {
                half1 = size / 2 + 1;
                half2 = size / 2;
            }

            int[] left = new int[half1];
            int[] right = new int[half2];


            for (int i = 0; i < half1; i++)
            {
                left[i] = array[half1 + i];
            }

            for (int j = 0; j < size - 1; j++)
            {
                right[j] = array[half1 + j];
            }

            int min;
            int minIndex = 0;

            for (int start = 0; start < half1; start++)
            {

                min = left[start];
                for (int i = start + 1; i < half1; i++)
                {
                    if (left[i] < min)
                    {
                        min = left[i];
                        minIndex = i;
                    }
                }

                left[minIndex] = left[start];
                left[start] = min;
            }


            //index fot left
            int i1 = 0;
            //index for right
            int i2 = 0;
            for (int i = 0; i < size; i++)
            {
                if (left[i1] <= right[i2] && i1 < half1)
                {
                    array[i] = left[i1];
                    i1++;
                }
                else
                    if (i2 < half2)
                {
                    array[i] = array[i2];
                    i2++;
                }


            }
        }


    }

    class Program
        {
            static void Main()
            {
                Sort sort = new Sort();


                Console.Write("Please, enter size: ");
                Console.WriteLine();

                int size = int.Parse(Console.ReadLine());
                Console.WriteLine("size: " + size);

                int[] array = sort.GetRandArray(size);
                DateTime time = DateTime.Now;


            sort.Show(array);
            Console.WriteLine();

            sort.InsertSort(array);
            sort.Show(array);
            Console.WriteLine();
            Console.WriteLine("Insertion sorting took: {0} мс",
            (DateTime.Now - time).TotalMilliseconds);
            Console.WriteLine();

            array = sort.GetRandomArray_from_0_to_10(size);
            time = DateTime.Now;
            sort.Show(array);
            Console.WriteLine();

            sort.QuickSort(array, 0, array.Length - 1);
            sort.Show(array);
            Console.WriteLine();
            Console.WriteLine("Quick sorting took: {0} ms",
            (DateTime.Now - time).TotalMilliseconds);
            Console.WriteLine();

            array = sort.GetRandomArray_from_0_to_10(size);
            time = DateTime.Now;
            sort.Show(array);
            Console.WriteLine();

            sort.MergeSorting(array, 0, array.Length - 1);
            sort.Show(array);
            Console.WriteLine();
            Console.WriteLine("Merge sorting took: {0} ms",
            (DateTime.Now - time).TotalMilliseconds);
            Console.WriteLine();

            array = sort.GetRandArray(size);
            time = DateTime.Now;
            sort.Show(array);
            Console.WriteLine();

            sort.CountSort(array);
            sort.Show(array);
            Console.WriteLine();
            Console.WriteLine("Count sorting took: {0} ms",
            (DateTime.Now - time).TotalMilliseconds);
            Console.WriteLine();

            Console.ReadKey();
            }

        }


}