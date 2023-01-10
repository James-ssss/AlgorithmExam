using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.Sorts
{
    public class BinaryTreeSort
    {
        public void Execute()
        {
            BinaryTree tree = new BinaryTree();

            int[] array = new int[] { 23, 4, -88, -312, -333 };
            //Console.WriteLine($"Массив: {array.ArrToString()}");
            //Console.WriteLine($"Результат сортировки: {tree.Sort(array).ArrToString()}");
        }
    }

    public class BinaryTree
    {
        Node b_root { get; set; }

        public class Node
        {
            public int value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int value, Node left, Node right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }

        public void Insert(Node node)
        {
            Node current = b_root;
            while (true)
            {
                if (current.value > node.value)
                {
                    if (current.left == null) { current.left = node; break; }
                    else current = current.left;
                    continue;
                }

                if (current.right == null) { current.right = node; break; }
                else current = current.right;
            }
        }

        public void Recursive(Node current, List<int> result)
        {
            if (current == null) return;

            //посещаем левое поддерево
            Recursive(current.left, result);

            //записываем результат в список
            result.Add(current.value);

            //посещаем правое поддерево
            Recursive(current.right, result);
        }

        public int[] Sort(int[] array)
        {
            List<int> result = new List<int>();
            if (array.Length != 0) b_root = new Node(array[0], null, null);

            for (int i = 1; i < array.Length; i++)
            {
                Insert(new Node(array[i], null, null));
            }

            Recursive(b_root, result);

            return result.ToArray();
        }
    }

}
