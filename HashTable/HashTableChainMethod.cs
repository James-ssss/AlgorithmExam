    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.HashTable
{
    public class HashTableChainMethod
    {
        LinkedList<KeyValuePair<int, int>>[] HashTable { get; set; }

        public void Execute()
        {
            Random random = new Random();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int count = random.Next(30, 50);
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(100);
                if (dict.ContainsKey(rand)) { i--; continue; }
                dict.Add(rand, i);
            }

            HashData(dict, 20);
        }

        void HashData(Dictionary<int, int> dict, int size)
        {
            HashTable = new LinkedList<KeyValuePair<int, int>>[size];

            foreach (var val in dict)
            {
                int hash = GetHashCode(val.Key);
                if (HashTable[hash] is null) HashTable[hash] = new LinkedList<KeyValuePair<int, int>>();

                HashTable[hash].AddFirst(new LinkedListNode<KeyValuePair<int, int>>(val));
            }
        }

        int GetHashCode(int value)
        {
            return value % HashTable.Length;
        }
    }

}
