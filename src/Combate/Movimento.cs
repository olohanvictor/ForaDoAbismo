using System;

namespace Combate
{
    public class MovimentarJogador
    {
        public static void MovimentaJogador(char[,] mapa, ref int x, ref int y, char player)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;

            Console.SetCursorPosition(x, y);
            Console.Write(player);

            while (true)
            {
                tecla = Console.ReadKey(true);
                int dx = 0, dy = 0;

                switch (tecla.Key)
                {
                    case ConsoleKey.W: dy = -1; break;
                    case ConsoleKey.S: dy = 1; break;
                    case ConsoleKey.A: dx = -1; break;
                    case ConsoleKey.D: dx = 1; break;
                    case ConsoleKey.Q: 
                        Console.CursorVisible = true;
                        return;
                }

                int novoX = x + dx;
                int novoY = y + dy;

                if (novoX < 0 || novoX >= mapa.GetLength(1) ||
                    novoY < 0 || novoY >= mapa.GetLength(0))
                    continue;

                if (mapa[novoY, novoX] == '#')
                    continue;

                Console.SetCursorPosition(x, y);
                Console.Write(mapa[y, x]);

                x = novoX;
                y = novoY;

                Console.SetCursorPosition(x, y);
                Console.Write(player);
            }
        }
    }
}
