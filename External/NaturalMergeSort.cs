using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.External
{
    public class NaturalMergeSort
    {
        private int _columnNumber = 0;
        string FileInput = "data.txt";
        int _segments = 1;
        public NaturalMergeSort(string filename, int columnNumber)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
        }
        public void Sort()
        {
            while (true)
            {
                SplitToFiles();
                if (_segments == 1)
                {
                    break;
                }
                MergePairs();
            }
        }

        private void SplitToFiles()
        {
            _segments = 1;
            using StreamReader br = new StreamReader(File.OpenRead(FileInput));
            using StreamWriter writerA = new StreamWriter(File.Create("a.txt"));
            using StreamWriter writerB = new StreamWriter(File.Create("b.txt"));
            bool flag = true;
            string str1 = null;
            string str2;
            int element1 = 0;
            int element2 = 0;
            while (true)
            {
                if (str1 is null)
                {
                    str1 = br.ReadLine();
                    element1 = int.Parse(str1?.Split(";")[_columnNumber]);
                    writerA.WriteLine(str1);
                }

                str2 = br.ReadLine();
                if (str2 is null | String.Compare(str2, "", StringComparison.Ordinal) == 0) break;
                element2 = int.Parse(str2.Split(";")[_columnNumber]);

                if (element1 > element2)
                {
                    flag = !flag;
                    _segments++;
                }

                if (flag)
                {
                    writerA.WriteLine(str2);
                }
                else
                {
                    writerB.WriteLine(str2);
                }

                str1 = str2;
                element1 = element2;
            }
            br.Close();
            writerA.Close();
            writerB.Close();
        }
        private void MergePairs()
        {
            using StreamReader readerA = new StreamReader(File.OpenRead("a.txt"));
            using StreamReader readerB = new StreamReader(File.OpenRead("b.txt"));
            using StreamWriter bw = new StreamWriter(File.Create(FileInput));
            int elementA = 0, elementB = 0;
            string strA = null, strB = null;
            bool pickedA = false, pickedB = false, endA = false, endB = false;
            while (!endA || !endB)
            {
                if (!endA & !pickedA)
                {
                    strA = readerA.ReadLine();
                    if (strA is null | String.Compare(strA, "", StringComparison.Ordinal) == 0) endA = true;
                    else
                    {
                        elementA = int.Parse(strA.Split(";")[_columnNumber]);
                        pickedA = true;
                    }
                }
                if (!endB & !pickedB)
                {
                    strB = readerB.ReadLine();
                    if (strB is null | String.Compare(strB, "", StringComparison.Ordinal) == 0) endB = true;
                    else
                    {
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
                            bw.WriteLine(strA);
                            pickedA = false;
                        }
                        else
                        {
                            bw.WriteLine(strB);
                            pickedB = false;
                        }
                    }
                    else
                    {
                        bw.WriteLine(strA);
                        pickedA = false;
                    }
                }
                else
                {
                    bw.WriteLine(strB);
                    pickedB = false;
                }
            }
        }

    }
}
