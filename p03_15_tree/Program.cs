using System;
using System.Collections.Generic;

namespace p03_15_tree
{
    /***********************************************************
        트리의 개념
        계층적 구조를 갖는 데이터를 표현하기 위한 자료구조
        * 노드(Node) : 데이터를 표현
        * 간선(Edge) : 노드의 계층 구조를 표현하기 위해 사용
        
        트리의 예시 :: 게임 신규 개발실 구성도
                                R1 개발실                        <= 루트(root)
                            ↙      ↓      ↘
             디자인팀          프로그래밍팀       아트팀
             ↙ ↓ ↘            ↙ ↓ ↘          ↙ ↘
        전투  경제  스토리   서버  클라  엔진   배경  캐릭터     <= 잎(leaf)

     노드의 깊이(depth) :: 
     트리의 높이(height) ::
     트리의 재귀적 속성 및 서브트리 (subtree) ::
     ***********************************************************/

    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            // 접근
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> child in root.Children)
                PrintTree(child);
        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach(TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                //if (height < newHeight)
                //    height = newHeight;
                height = Math.Max(height, newHeight);
            }

            return height;
        }

        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            //PrintTree(root);

            Console.WriteLine(GetHeight(root));
        }
    }
}
