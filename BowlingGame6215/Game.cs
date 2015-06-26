using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame6215
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] += pins;
        }

        public int Score()
        {
            int score = 0;
            int frame = 0;
            for (int r = 0; r < 10; r++ )
            {
                if (IsStrike(frame))
                {
                    score += 10 + StrikeBonus(frame);
                    frame++;
                }
                else if (IsSpare(frame))
                {
                    score += 10 + SpareBonus(frame);
                    frame += 2;
                }
                else
                {
                    score += rolls[frame] + rolls[frame + 1];
                    frame += 2;
                }
            }

              return score;
        }

        private bool IsSpare(int frame)
        {
            return rolls[frame] + rolls[frame + 1] == 10;
        }

        private bool IsStrike(int frame)
        {
            return rolls[frame] == 10;
        }

        private int SpareBonus(int frame)
        {
            return rolls[frame + 2];
        }

        private int StrikeBonus(int frame)
        {
            return rolls[frame + 1] + rolls[frame + 2];
        }


    }
}
