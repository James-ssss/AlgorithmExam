using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam
{
    public class Sorts
    {
        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<int> BubbleSort(List<int> inputList)
        {
            for (int k = 0; k < inputList.Count - 1; k++)
            {
                for (int i = 0; i < inputList.Count - 1; i++)
                {
                    if (inputList[i] > inputList[i + 1])
                    {
                        (inputList[i + 1], inputList[i]) = (inputList[i], inputList[i + 1]);
                    }
                }
            }
            return inputList;
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<int> QuickSort(List<int> inputList)
        {
            if (inputList.Count <= 1)
            {
                return inputList;
            }
            var pivot = inputList[0];
            List<int> left = new();
            List<int> centre = new();
            List<int> right = new();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] > pivot)
                    right.Add(inputList[i]);
                else if (inputList[i] == pivot)
                    centre.Add(inputList[i]);
                else 
                    left.Add(inputList[i]);
            }
            return QuickSort(left).Concat(centre).Concat(right).ToList();
        }

        //List<int> input = new() { 7,4,3,1,8,2};
        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> InsertionSort(List<int> input)
        {
            
            for (int i = 1; i < input.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (input[j-1] > input[j])
                    {
                        Console.WriteLine($"Меняем местами {input[j - 1]} и {input[j]}");
                        (input[j-1], input[j]) = (input[j], input[j-1]);
                        foreach (int k in input)
                        {
                            Console.Write($"{k} ");
                        }
                        Console.WriteLine();
                    }
                    
                }
                
            }
            return input;
        }
        //List<int> arr = new() { 70, 3, 11, 6, 78, 1 };
        public static List<int> ShellSort(List<int> input)
        {
            var gap = input.Count / 2;
            while (gap > 0)
            {
                for (int i = gap; i < input.Count; i++)
                {
                    var current_value = input[i];
                    var position = i;
                    while (position >= gap && input[position-gap] > current_value)
                    {
                        input[position] = input[position-gap];
                        position -= gap;
                        input[position] = current_value;
                    }

                }
                gap /= 2;
            }
            
            return input;
        }
        /// <summary>
        /// Сортировка выбором
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> SelectionSort(List<int> input)
        {
            for (int i = 0; i < input.Count-1; i++)
            {
                int min = i;
                for(int j = i+1; j < input.Count; j++)
                {
                   if (input[j] < input[min])
                   {
                        min = j;     
                   }

                }
                (input[i], input[min]) = (input[min], input[i]);
                Console.WriteLine($"Меняем местами {input[i]} и {input[min]}");
                foreach (int k in input)
                {
                    Console.Write($"{k} ");
                }
                Console.WriteLine();
            }
            return input;
        }
        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> CocktailSort(List<int> input)
        {
            var left = 0;
            var right = input.Count-1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (input[i+1] < input[i])
                    {
                        (input[i], input[i + 1]) = (input[i + 1], input[i]);
                    }
                }
                right--;
                for(int i = right; i > left; i--)
                {
                    if (input[i-1] > input[i])
                    {
                        (input[i], input[i - 1]) = (input[i -    1], input[i]);
                    }
                }
                left++;
            }
            return input;
        }

        public static int BinarySearch(List<int> inputList, int searchedElem)
        {
            var left = 0;
            var right = inputList.Count;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (searchedElem < inputList[middle])
                {
                    right = middle - 1;
                }
                if (searchedElem == inputList[middle])
                {
                    return middle;
                }
                if (searchedElem > inputList[middle])
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
        //var arr = new int[] { 70, 3, 11, 6, 78, 1 };
        /// <summary>
        /// Поразрядная сортировка
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<int> RadixSort(List<int> inputList)
        {
            var maxNum = inputList.Max();
            var maxNumLengh = 0; // длина максимального числа и одновременно количество итераций
            while (maxNum > 0)
            {
                maxNumLengh += 1;
                maxNum /= 10;
            }

            for (int i = 0; i < maxNumLengh; i++)
            {
                var temp = new List<List<int>>();
                for (int j = 0; j < 10; j++)   //инициализация списка списков
                    temp.Add(new List<int>());

                // а тут будем фасовать чиселки по ведрам
                foreach (var item in inputList)
                {
                    int listIndex = (int) (item / Math.Pow(10, i) % 10);
                    temp[listIndex].Add(item);
                }
                inputList.Clear(); // собираем из ведер все в одну последовательность
                foreach(var item in temp)
                {
                    inputList.AddRange(item);
                }
            }            
            return  inputList;
        }
        public static string[] ABCSort(string[] Array, int rank)
        {
            if (Array.Length <= 1)
            {
                return Array;
            }
            var square = new Dictionary<char, List<string>>(62);
            var result = new List<string>();
            int shortWordsCounter = 0;
            foreach (var word in Array)
            {
                if (rank < word.Length)
                {
                    if (square.ContainsKey(word[rank]))
                    {
                        square[word[rank]].Add(word);
                    }
                    else
                    {
                        square.Add(word[rank], new List<string> { word });
                    }
                }
                else
                {
                    result.Add(word);
                    shortWordsCounter++;
                }
            }

            if (shortWordsCounter == Array.Length)
            {
                return Array;
            }
            for (char i = 'A'; i <= 'z'; i++)
            {
                if (square.ContainsKey(i))
                {
                    foreach (var word in ABCSort(square[i].ToArray(), rank + 1))
                    {
                        result.Add(word);

                    }
                }
            }
            return result.ToArray();
        }

    }
}
