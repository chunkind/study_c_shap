using System;
using System.Collections.Generic;

namespace p03_10_theory_of_graph
{
    /**
     *  그래프의 개념
     *  현실 세계의 사물이나 추상적인 개념 간의 연결 관계를 표현.
     *  정점[Vertex] : 데이터를 표현 (사물, 개념 등)
     *  간선[Edge] : 정점들을 연결하는데 사용
     *  
     *  그래프의 예시
     *   * 소셜 네트워크 관계도
     *  1.가중치 그래프(Weighted Graph)
     *   * 지하철 노선도
     *  2.방향 그래프(Directed Graph)
     *   * 일방 통행이 포함된 도로망
     *   * 두 사람 사이의 호감도
     */
    class Program
    {
        static void Main(string[] args)
        {

        }

        /* 아래와 같은 그래프를 코드로 표현한다...
               (15)     (5)
            0   ↔   1  →   2

               (35) (10)
                ↘  ↓
                
                     3

                    (5)
                    ↓  
                        (5)
                     4  ←   5
        */

        /************************* List 이용 ******************************/
        // 방향 그래프의 예시 1
        class Vertex { public List<Vertex> edges = new List<Vertex>(); }
        static void DirectedGraphEx1()
        {
            List<Vertex> v = new List<Vertex>(6)
            {
                /* 0 */new Vertex(),
                /* 1 */new Vertex(),
                /* 2 */new Vertex(),
                /* 3 */new Vertex(),
                /* 4 */new Vertex(),
                /* 5 */new Vertex()
            };
            v[0].edges.Add(v[1]);
            v[0].edges.Add(v[3]);
            v[1].edges.Add(v[0]);
            v[1].edges.Add(v[2]);
            v[1].edges.Add(v[3]);
            v[3].edges.Add(v[4]);
            v[5].edges.Add(v[4]);
        }
        // 방향 그래프의 예시 2
        // 읽는 방법 : adjacent[from] -> 연결된 항목
        // 리스트를 이용한 그래프 표현
        // 메모리는 아낄 수 있지만, 접근 속도에서 손해를 본다.
        // (간선이 적고 정점이 많은 경우 이점이 있다.)
        static void DirectedGraphEx2()
        {
            List<int>[] adjacent = new List<int>[6]
            {
                /* 0 */new List<int>{ 1, 3 },
                /* 1 */new List<int>{ 0, 2, 3 },
                /* 2 */new List<int>{ },
                /* 3 */new List<int>{ 4 },
                /* 4 */new List<int>{ },
                /* 5 */new List<int>{ 4 },
            };
        }

        // 방향 그래프의 가중치까지 더한 예시
        // 읽는 방법 : adjacent[from] -> 연결된 목록
        // 메모리는 아낄 수 있지만, 접근 속도에서 손해를 본다.
        // (간선이 적고 정점이 많은 경우 이점이 있다.)
        class Edge
        {
            public Edge(int v, int w) { vertex = v; weight = w; }
            public int vertex;
            public int weight;
        }
        static void DirectedAndWeightedGraphEx1()
        {
            List<Edge>[] adjacent = new List<Edge>[6]
            {
                new List<Edge>() { new Edge(1, 15), new Edge(3, 35) },
                new List<Edge>() { new Edge(0, 15), new Edge(2, 5), new Edge(3, 10) },
                new List<Edge>() { },
                new List<Edge>() { new Edge(4, 5) },
                new List<Edge>() { },
                new List<Edge>() { new Edge(4, 5) },
            };
        }

        /************************* 행렬 이용 ******************************/
        //접근 속도를 높이기위해 행렬을 이용 할 수도 있다.

        // 행렬 예시1
        // 행렬을 이용한 그래프 표현 (2차원 배열)
        // 메모리 소모가 심하지만, 빠른 접근이 가능 하다.
        // (정점은 적고 간선이 많은 경우 이점이 있다.)
        static void MultiArrayEx1()
        {
            int[,] adjacent2 = new int[6, 6]
            {
                { 0, 1, 0, 1, 0, 0 },
                { 1, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
            };
        }

        // 행렬 예시2
        // 가중치 추가 : -1을 이용해서 연결이 끊긴 것을 표현
        // 행렬을 이용한 그래프 표현 (2차원 배열)
        // 메모리 소모가 심하지만, 빠른 접근이 가능 하다.
        // (정점은 적고 간선이 많은 경우 이점이 있다.)
        static void MultiArrayEx2()
        {
            int[,] adjacent2 = new int[6, 6]
            {
                { -1, 15, -1, 35, -1, -1 },
                { 15, -1, 5, 10, -1, -1 },
                { -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, 5, -1 },
                { -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, 5, -1 },
            };
        }
    }
}
