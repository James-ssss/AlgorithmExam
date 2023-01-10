using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.Graph
{
    public class GraphAlgorithms
    {
        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public static List<Node> BreadthSearch(Node startNode)
        {
            var result = new List<Node>();
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            visited.Add(startNode);
            queue.Enqueue(startNode);
            
            
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                result.Add(node);
                foreach(var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    queue.Enqueue(nextNode);
                }
                    
            }
            return result;
        }
        //поиск в глубину
        public static List<Node> DepthSearch(Node startNode)
        {
            var result = new List<Node>();
            var visited = new HashSet<Node>();
            visited.Add(startNode);
            var stack = new Stack<Node>();
            stack.Push(startNode);
            
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                result.Add(node);
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
                    
            }
            return result;
        }
        //Дейкстра
        class DijkstraData
        {
            public double Price;
            public Node Previous;
        }
        public static List<Node> Dijkstra(Graph graph, Node start, Node end)
        {
            var notVisited = graph.Nodes.ToList();
            var track = new Dictionary<Node, DijkstraData>();
            track[start] = new DijkstraData { Price = 0, Previous = null };

            while (true)
            {
                Node toOpen = null;
                var bestPrice = double.PositiveInfinity;
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                if (toOpen == null) return null;
                if (toOpen == end) break;

                foreach (var e in toOpen.IncidentEdges.Where(z => z.From == toOpen))
                {
                    var currentPrice = track[toOpen].Price + e.Weight;
                    var nextNode = e.OtherNode(toOpen);
                    if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                    {
                        track[nextNode] = new DijkstraData { Previous = toOpen, Price = currentPrice };
                    }
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end].Previous;
            }
            result.Reverse();
            return result;
        }
    }
}
