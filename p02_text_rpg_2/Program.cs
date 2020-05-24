using System;

namespace p02_text_rpg_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (true)
            {
                game.Process();
            }
        }
    }
}
