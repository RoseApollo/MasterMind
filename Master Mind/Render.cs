using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Mind
{
    public class Render
    {
        public static void RenderBoard(Game.GameData board, bool showAns = false)
        {
            for (int x = 0; x < (board.go); x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Console.BackgroundColor = Values.colors[board.board[x, y]];
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }

                Console.Write("  ");

                int[] checks = board.ContainsCalcIHateThis(x);

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");

                for (int y = 0; y < 4; y++)
                {
                    switch (checks[y])
                    {
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;

                        case 2:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;

                        case 0:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }

                    Console.Write(" ");
                }

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");

            if (showAns)
            {
                for (int y = 0; y < 4; y++)
                {
                    Console.BackgroundColor = Values.colors[board.sequence[y]];
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
        }

        public static int[] GetColorInput()
        {
            int[] colors = new int[4];

            int selected = 0;

            while (true)
            {
                Console.Clear();

                for (int x = 0; x < 4; x++)
                {
                    Console.Write("      ");

                    for (int y = 0; y < 4; y++)
                    {
                        Console.BackgroundColor = Values.colors[colors[y]];
                        Console.Write((y == selected) ? "#    #" : "      ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("      ");
                    }

                    Console.WriteLine();
                }

                ConsoleKey ck = Console.ReadKey().Key;

                switch (ck)
                {
                    case ConsoleKey.LeftArrow:
                        if (--selected < 0)
                            selected = 3;

                        break;
                    case ConsoleKey.RightArrow:
                        if (++selected > 3)
                            selected = 0;

                        break;
                    case ConsoleKey.UpArrow:
                        if (++colors[selected] > 5)
                            colors[selected] = 0;

                        break;
                    case ConsoleKey.DownArrow:
                        if (--colors[selected] < 0)
                            colors[selected] = 5;

                        break;
                    case ConsoleKey.Enter:
                        return colors;
                }
            }
        }
    }
}
