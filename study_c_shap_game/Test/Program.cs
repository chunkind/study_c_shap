using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);
            int lastTick = 0;
            const int WIAT_TIME = 1000;
            
            while (true)
            {
                #region 프레임설정
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WIAT_TIME)
                    continue;
                lastTick = currentTick;
                #endregion

                board.Render();
            }

        }
    }

    class Board
    {
        public int _size;
        public TileType[,] _tile;
        public const char DEFAILT_CHAR = '\u25cf';

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size)
        {
            if (size % 2 == 0) return;

            _size = size;
            _tile = new TileType[size, size];
            Random rand = new Random();

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++) 
                {
                    if( x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                    {
                        _tile[y, x] = TileType.Wall;
                        continue;
                    }

                    if( x % 2 == 0 || y % 2 == 0)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                }
            }

            Boolean changed = false;
            for (int y = 0; y < _size; y++) 
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                        continue;

                    if (x % 2 == 1 && y % 2 == 1)
                    {
                        if (rand.Next(0, 2) == 1)
                            _tile[y + 1, x] = TileType.Empty;
                        else
                            _tile[y, x + 1] = TileType.Empty;
                    }
                    
                }
            }
        }

        public void Render()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++) 
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    Console.Write(DEFAILT_CHAR);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = defaultColor;
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