using System;
using System.Collections.Generic;
using System.Text;

namespace p03_17_AStart
{
    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; }

        public int Size { get; private set; }
        
        public int DestY { get; private set; }
        public int DestX { get; private set; }
        
        Player _player;

        public enum TileType
        {
            Empty,
            Wall
        }


        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;

            _player = player;

            Tile = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;

            // Mazes for Programmers
            GenerateBySideWinder();
        }

        void GenerateBySideWinder()
        {
            // 길막기
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (y % 2 == 0 || x % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 길뚫기
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (y % 2 == 0 || x % 2 == 0)
                        continue;
                    if (y == Size - 2 && x == Size - 2)
                        continue;
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    int count = 1;
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomeIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomeIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor dfcolor = Console.ForegroundColor;
            for(int y=0; y<Size; y++)
            {
                for(int x=0; x<Size; x++)
                {
                    if (_player.PosY == y && _player.PosX == x)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (y == DestY && x == DestX)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = dfcolor;
        }

        public ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
