using System;

namespace SortingExample
{
    public interface ISortable
    {
        int[] Ascending(int[] numbers);
        int[] Descending(int[] numbers);
    }

    public class Sortable : ISortable
    {
        
        public int[] BubbleSort(int[] numbers, bool ascending)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if ((ascending && numbers[j] > numbers[j + 1]) || (!ascending && numbers[j] < numbers[j + 1]))
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }

       
        public int[] MergeSort(int[] numbers, bool ascending)
        {
            if (numbers.Length <= 1)
                return numbers;

            int mid = numbers.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[numbers.Length - mid];

            Array.Copy(numbers, 0, left, 0, mid);
            Array.Copy(numbers, mid, right, 0, numbers.Length - mid);

            left = MergeSort(left, ascending);
            right = MergeSort(right, ascending);

            return Merge(left, right, ascending);
        }

        private int[] Merge(int[] left, int[] right, bool ascending)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if ((ascending && left[i] < right[j]) || (!ascending && left[i] > right[j]))
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                result[k++] = left[i++];
            }

            while (j < right.Length)
            {
                result[k++] = right[j++];
            }

            return result;
        }

        public int[] SelectionSort(int[] numbers, bool ascending)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((ascending && numbers[j] < numbers[index]) || (!ascending && numbers[j] > numbers[index]))
                    {
                        index = j;
                    }
                }
                int temp = numbers[i];
                numbers[i] = numbers[index];
                numbers[index] = temp;
            }
            return numbers;
        }

        public int[] InsertionSort(int[] numbers, bool ascending)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int j = i - 1;

                while (j >= 0 && ((ascending && numbers[j] > current) || (!ascending && numbers[j] < current)))
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = current;
            }
            return numbers;
        }

        
        public int[] Ascending(int[] numbers)
        {
            
            return BubbleSort(numbers, true); 
        }

        public int[] Descending(int[] numbers)
        {
            
            return BubbleSort(numbers, false); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 2, 9, 1, 5, 6, 3, 8, 7, 4 };

            Sortable sortable = new Sortable();

            Console.WriteLine("Original Array: ");
            PrintArray(numbers);

            
            Console.WriteLine("\nSorted Ascending (Bubble Sort): ");
            PrintArray(sortable.Ascending(numbers));

            
            Console.WriteLine("\nSorted Descending (Bubble Sort): ");
            PrintArray(sortable.Descending(numbers));

           
            Console.WriteLine("\nSorted Ascending (Merge Sort): ");
            PrintArray(sortable.MergeSort(numbers, true));

            
            Console.WriteLine("\nSorted Descending (Merge Sort): ");
            PrintArray(sortable.MergeSort(numbers, false));

           
            Console.WriteLine("\nSorted Ascending (Selection Sort): ");
            PrintArray(sortable.SelectionSort(numbers, true));

            
            Console.WriteLine("\nSorted Descending (Selection Sort): ");
            PrintArray(sortable.SelectionSort(numbers, false));

            
            Console.WriteLine("\nSorted Ascending (Insertion Sort): ");
            PrintArray(sortable.InsertionSort(numbers, true));

            
            Console.WriteLine("\nSorted Descending (Insertion Sort): ");
            PrintArray(sortable.InsertionSort(numbers, false));
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
