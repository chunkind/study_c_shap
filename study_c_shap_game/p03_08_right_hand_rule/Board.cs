using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace p03_08_right_hand_rule
{
    class Board
    {
        const char CIRCLE = '\u25cf';
        int _size;
        public TileType[,] _tile;

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size, Player player)
        {
            _size = size;
            _tile = new TileType[size, size];

            GenerateBySideWinder();
        }

        public void GenerateBySideWinder()
        {
            //길막기 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 1;
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    int randomeIndex = rand.Next(0, count);
                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        _tile[y + 1, x - randomeIndex * 2] = TileType.Empty;
                        count = 1;
                    }

                }
            }
        }

        public void Render()
        {
            ConsoleColor df = Console.ForegroundColor;
            for (int y=0; y<_size; y++)
            {
                for(int x=0; x<_size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = df;
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
