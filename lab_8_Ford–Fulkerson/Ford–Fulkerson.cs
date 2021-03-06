using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkerson
{
    class Program
    {
        int men = 4;
        int women = 4;

        bool DFS(bool[,] graph, int u, bool[] visited, int[] match)
        {
            for (int v = 0; v < women; v++)
            {
                if (graph[u, v] && !visited[v])
                {
                    visited[v] = true;

                    if (match[v] < 0 || DFS(graph, match[v], visited, match))
                    {
                        match[v] = u;

                        return true;
                    }
                }
            }
            return false;
        }

        int FordFulkerson(bool[,] graph)
        {
            int[] match = new int[women];
            int count = 0;

            for (int i = 0; i < women; ++i)
                match[i] = -1;
            for (int u = 0; u < men; u++)
            {
                bool[] visited = new bool[women];
                for (int i = 0; i < women; ++i)
                    visited[i] = false;
                if (DFS(graph, u, visited, match))
                    count++;
            }
            return count;
        }

        public static void Main()
        {
            bool[,] graph = new bool[,]
                           {{false, true, true,false},
                           {true, false, false, true},
                           {false, false, true,false},
                           {false, false, false, false}};
            Program m = new Program();
            Console.Write("�aximum number of pairs " + m.FordFulkerson(graph));
            Console.ReadKey();
        }
    }
}



