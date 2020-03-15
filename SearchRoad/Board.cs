using System;
using System.Collections.Generic;
using System.Text;

namespace SearchRoad
{
    class Board
    {

        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size)
        {
            if (size % 2 == 0)
                return;
            Tile = new TileType[size, size];
            Size = size;
            GenerateBySideWinder();
        }

        private void GenerateBySideWinder()
        {
            for(int y = 0; y < Size; y++)
            {
                for(int x = 0; x<Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
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
