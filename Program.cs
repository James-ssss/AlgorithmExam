using AlgorithmExam;
using AlgorithmExam.Graph;
using System.Net.Http.Headers;


//List<int> input = new() { 7,4,3,1,8,2};

//Sorts.SelectionSort(input);
//foreach (int i in Sorts.CocktailSort(input))
//{
//    Console.Write($"{i} ");
//}
//Sorts.ShellSort(input);
//List<int> input = new() { 1, 2, 4, 7, 8, 9, 14, 30, 37, 40, 41 };

//Console.WriteLine(Sorts.BinarySearch(input, 5));
//List<int> arr = new() { 70, 3, 11, 6, 78, 1 };
//foreach (int i in arr)
//    Console.Write($"{i} ");
//Console.WriteLine();
//foreach (int i in Sorts.ShellSort(arr))
//    Console.Write($"{i} "); 


var graph = Graph.MakeGraph(
    0, 1, 1,
    0, 2, 2,
    0, 3, 6, 
    1, 3, 4, 
    2, 3, 2
    );
var path = GraphAlgorithms.Dijkstra(graph, graph[0], graph[3]).Select(n => n.NodeNumber);
foreach (var node in path)
    Console.WriteLine(node);
//foreach (var item in GraphAlgorithms.BreadthSearch(graph[0]))
//    Console.Write( $"{ item.NodeNumber} ");
//Console.WriteLine();
//foreach (var item in GraphAlgorithms.DepthSearch(graph[0]))
//    Console.Write($"{item.NodeNumber} ");
