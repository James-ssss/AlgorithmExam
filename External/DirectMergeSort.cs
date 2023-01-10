using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.External
{
    public class DirectMergeSort
    {

        public string FileInput { get; set; }
        private int _columnNumber = 0;
        private long iterations, segments;

        public DirectMergeSort(string filename)
        {
            FileInput = filename;
            iterations = 1; // степень двойки, количество элементов в каждой последовательности
        }

        public DirectMergeSort(string filename, int columnNumber)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
            iterations = 1;
        }

        public void Sort()
        {
            while (true)
            {
                SplitToFiles();
                if (segments == 1)
                {
                    break;
                }
                MergePairs();
            }
        }
       
        private void SplitToFiles()
        {
            segments = 1;
            using (StreamReader sr = new StreamReader(FileInput))
            using (StreamWriter writerA = new StreamWriter("a.txt"))
            using (StreamWriter writerB = new StreamWriter("b.txt"))
            {
                long counter = 0;
                bool flag = true;

                while (!sr.EndOfStream)
                {
                    if (counter == iterations)
                    {
                        flag = !flag;
                        counter = 0;
                        segments++;
                    }
                    string element = sr.ReadLine();

                    if (flag)
                    {
                        writerA.WriteLine(element);
                    }
                    else
                    {
                        writerB.WriteLine(element);
                    }
                    counter++;
                }
            }
            Console.WriteLine();
        }

        private void MergePairs()
        {
            using StreamReader readerA = new StreamReader(File.OpenRead("a.txt"));
            using StreamReader readerB = new StreamReader(File.OpenRead("b.txt"));
            using StreamWriter sr = new StreamWriter(File.Create(FileInput));
            long counterA = iterations, counterB = iterations;
            int elementA = 0, elementB = 0;
            string strA = null, strB = null;
            bool pickedA = false, pickedB = false;
            while (!readerA.EndOfStream || !readerB.EndOfStream || pickedA || pickedB)
            {
                if (counterA == 0 && counterB == 0)
                {
                    counterA = iterations;
                    counterB = iterations;
                }

                if (!readerA.EndOfStream)
                {
                    if (counterA > 0 && !pickedA)
                    {
                        strA = readerA.ReadLine();
                        elementA = int.Parse(strA.Split(";")[_columnNumber]);
                        pickedA = true;
                    }
                }

                if (!readerB.EndOfStream)
                {
                    if (counterB > 0 && !pickedB)
                    {
                        strB = readerB.ReadLine();
                        elementB = int.Parse(strB.Split(";")[_columnNumber]);
                        pickedB = true;
                    }
                }

                if (pickedA)
                {
                    if (pickedB)
                    {
                        if (elementA < elementB)
                        {
                            sr.WriteLine(strA);
                            counterA--;
                            pickedA = false;
                        }
                        else
                        {
                            sr.WriteLine(strB);
                            counterB--;
                            pickedB = false;
                        }
                    }
                    else
                    {
                        sr.WriteLine(strA);
                        counterA--;
                        pickedA = false;
                    }
                }
                else if (pickedB)
                {
                    sr.WriteLine(strB);
                    counterB--;
                    pickedB = false;
                }
            }
            sr.Close();
            readerA.Close();
            readerB.Close();
            iterations *= 2;
            Console.WriteLine();
            Console.WriteLine();


        }

    }
}
