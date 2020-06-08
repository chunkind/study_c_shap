using System;
using System.Collections.Generic;

namespace p03_11_depth_first_search
{
    /*
        0   ―  1  ―  2
            ＼  |
                3
                |
                4  ―  5
    */
    class Graph
    {
        /* 3, 4 연결 된 거
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };
        */

        /* 3, 4 연결 안된 거 */
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };

        /* 3, 4 연결 된 거
        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){ 1, 3 },
            new List<int>(){ 0, 2, 3 },
            new List<int>(){ 1 },
            new List<int>(){ 0, 1, 4 },
            new List<int>(){ 3, 5 },
            new List<int>(){ 4 },
        };
        */

        /* 3, 4 연결 안된 거 */
        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){ 1, 3 },
            new List<int>(){ 0, 2, 3 },
            new List<int>(){ 1 },
            new List<int>(){ 0, 1 },
            new List<int>(){ 5 },
            new List<int>(){ 4 },
        };

        bool[] visited = new bool[6];
        public void DFS(int now)
        {
            Console.WriteLine(now);
            // 1) 우선 now부터 방문하고
            visited[now] = true;
            // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견(미방문) 상태라면 방문한다.
            for (int next = 0; next < adj.GetLength(0); next++)
            {
                if (adj[now, next] == 0) // 연결되지 않으면 패스
                    continue;
                if (visited[next]) // 이미 방문한방이라면 패스
                    continue;
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            // 1) 우선 now부터 방문하고
            visited[now] = true;

            // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견(미방문) 상태라면 방문한다.
            foreach (int next in adj2[now])
            {
                if (visited[next]) // 이미 방문한방이라면 패스
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
                if (visited[now] == false)
                    DFS(now);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            // DFS (Depth First Search : 깊이 우선 탐색)
            //graph.DFS(0);
            //graph.DFS2(0);
            graph.SearchAll();
            // BFS (Breadth First Search : 너비 우선 탐색)
        }
    }
}
