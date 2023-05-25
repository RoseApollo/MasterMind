using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Mind
{
    public class Game
    {
        public class GameData
        {
            public int[,] board = new int[12, 4];
            public int[] sequence = new int[4];

            public int go = 0;

            public int won 
            { 
                get 
                {
                    if (go >= 12)
                    {
                        return -1;
                    }


                    for (int i = 0; i < 4; i++)
                    {
                        if (board[go - 1, i] != sequence[i])
                        {
                            return 0;
                        }
                    }

                    return 1;
                }
            }

            public GameData()
            {
                this.board = new int[12, 4];
                this.sequence = new int[4];

                this.go = 0;
            }

            public void AddRow(int[] dat)
            {
                for (int i = 0; i < 4; i++)
                {
                    this.board[this.go, i] = dat[i];
                }

                this.go++;
            }

            public int[] ContainsCalcIHateThis(int row)
            {
                int[] retVal = new int[4];
                int[] seqCache = new int[4];

                this.sequence.CopyTo(seqCache, 0);

                for (int i = 0; i < 4; i++)
                {
                    if (this.board[row, i] == seqCache[i])
                    {
                        seqCache[i] = -1;

                        retVal[i] = 1;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (retVal[i] == 1)
                        continue;

                    for (int s = 0; s < 4; s++)
                    {
                        if (this.board[row, i] == seqCache[s])
                        {
                            seqCache[s] = -1;

                            retVal[i] = 2;
                        }
                    }
                }

                return retVal;
            }
        }

        public static void Play()
        {
            Console.Clear();
            int opt = Menu.NumberMenu(new string[] { "You Guesses", "Computer Guess" });
            Console.Clear();

            Console.WriteLine("Loading...");

            GameData game = new GameData();

            if (opt == 1)
            {
                Random rand = new Random();

                for (int i = 0; i < 4; i++)
                {
                    int col = rand.Next(6);
                    
                    game.sequence[i] = col;
                }
            }
            else
            {
                Console.WriteLine("Please select your colors");

                return;
            }

            do
            {
                game.AddRow(Render.GetColorInput());

                Console.Clear();

                Render.RenderBoard(game);

                Console.ReadLine();
            } while (game.won == 0);
        }
    }
}
