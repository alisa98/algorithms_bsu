using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiada
{
    class Program
    {
        class Olympiada
        {
            private int id; private int[,] matrix; private Olympiada() { }
            public Olympiada(int id, int[,] matrix) { this.id = id; this.matrix = matrix; }
            public void DFS(int startVertex)
            {
                Boolean[] visited = new Boolean[id];
                Console.WriteLine("The Depth First Search is as follows");
                DFSUtil(startVertex, matrix, visited);
            }
            private void DFSUtil(int startVertex, int[,] matrix, Boolean[] visited) { visited[startVertex] = true; Console.Write(startVertex + "--"); for (int i = 0; i < id; i++) { if (matrix[i, startVertex] == 1 && false == visited[i]) { DFSUtil(i, matrix, visited); } } }
            public bool Check(int[,] matrix) { if (matrix.GetLength(0) == visited.Length) { return true; } else { return false; } }
            public void PrintyMatrix()
            {
                for (int i = 0; i < id; i++)
                {
                    for (int j = 0; j < id; j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of competitors");
            int competitors = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements [" + competitors + "*" + competitors + "=" + (competitors * competitors) + "]");
            int[,] adjMatrix = new int[competitors, competitors];
            for (int i = 0; i < competitors; i++)
            {
                for (int j = 0; j < competitors; j++)
                {
                    adjMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Olympiada g = new Olympiada(competitors, adjMatrix);
            Console.WriteLine("The Matrix is"); g.PrintyMatrix();
            Console.WriteLine();
            Console.WriteLine("Enter the start index");
            int startIndex = int.Parse(Console.ReadLine());
            g.DFS(startIndex);
            //  g.Check();   
            Console.ReadKey();
        }
    }
}