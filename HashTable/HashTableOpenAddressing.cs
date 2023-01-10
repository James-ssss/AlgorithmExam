using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.HashTable
{
    public class HashTableOpenAddressing
    {

        KeyValuePair<int, int>?[] HashTable { get; set; }

        public void Execute()
        {
            Random random = new Random();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int count = random.Next(80, 100);
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(100);
                if (dict.ContainsKey(rand)) { i--; continue; }
                dict.Add(rand, i);
            }

            HashData(dict, 110);
        }

        void HashData(Dictionary<int, int> dict, int size)
        {
            HashTable = new KeyValuePair<int, int>?[size];

            foreach (var val in dict)
            {
                for (int i = 0; i < HashTable.Length; i++)
                {
                    int hash = GetHashCode(val.Key) + i;

                    if (!HashTable[hash].HasValue)
                    {
                        HashTable[hash] = val;
                        break;
                    }
                }
            }
        }

        int GetHashCode(int value)
        {
            return value % HashTable.Length;
        }
    }

}
