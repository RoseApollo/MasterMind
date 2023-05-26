using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Mind
{
    internal class AI
    {
        public static int[] Guess(Game.GameData game)
        {
            int[] guess = new int[4];

            for (int i = 0; i < 4; i++)
                guess[i] = -1;

            for (int x = 0; x < game.go; x++)
            {
                int[] stat = game.ContainsCalcIHateThis(x);

                for (int y = 0; y < 4; y++)
                {
                    if (stat[y] == 1)
                    {
                        guess[y] = game.board[x, y];
                    }
                }
            }

            return guess;
        }

        public static int[] ShittyGuess(Game.GameData game)
        {
            int[] guess = new int[4];

            Random r = new Random();

            if (game.go == 0)
            {
                // RANDOM

                guess[0] = r.Next(6);
                guess[1] = r.Next(6);
                guess[2] = r.Next(6);
                guess[3] = r.Next(6);

                return guess;
            }

            while (!IsThisValidGivenWhatIKnow(game, guess))
            {
                /*if (++guess[0] >= 6)
                {
                    guess[0] = 0;

                    if (++guess[1] >= 6)
                    {
                        guess[1] = 0;

                        if (++guess[2] >= 6)
                        {
                            guess[2] = 0;

                            if (++guess[3] >= 6)
                            {
                                throw new Exception("UM WTF");
                            }
                        }
                    }
                }*/

                guess[0] = r.Next(6);
                guess[1] = r.Next(6);
                guess[2] = r.Next(6);
                guess[3] = r.Next(6);
            }

            return guess;
        }

        public static bool IsThisValidGivenWhatIKnow(Game.GameData game, int[] guess)
        {
            for (int x = 0; x < game.go; x++)
            {
                int[] gDat = game.ContainsCalcIHateThis(x);

                for (int y = 0; y < 4; y++)
                {
                    if
                    (
                        ((gDat[y] == 0) && (guess[y] == game.board[x, y])) ||
                        ((gDat[y] == 1) && (guess[y] != game.board[x, y])) ||
                        ((gDat[y] == 2) && (guess[y] == game.board[x, y]))
                    )
                        return false;
                }
            }

            for (int x = 0; x < game.go; x++)
            {
                int[] gDat = game.ContainsCalcIHateThis(x);

                for (int y = 0; y < 4; y++)
                {
                    if (gDat[y] == 2 && !(guess.Contains(game.board[x, y])))
                        return false;
                }
            }

            return true;
        }
    }
}
