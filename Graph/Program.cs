using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //리스트 순회
            //List<int> list = new List<int>() { 1, 2, 3, 4 };
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            //foreach (int val in list)
            //{
            //    Console.WriteLine(val);
            //}

            //그래프 순회
            // DFS(Depth First Search : 깊이 우선 탐색)
            //ExDFS dfs = new ExDFS();
            //dfs.DFS(3);
            //dfs.DFS2(3);
            //dfs.SearchAll();

            // BFS(Breadth First Search : 너비 우선 탐색)
            ExBFS bfs = new ExBFS();
            bfs.BFS(0);

        }
    }
}
