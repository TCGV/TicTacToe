using System;

namespace Tcgv.AI.TicTacToe
{
    public class RandomPlayer: Player
    {
        public RandomPlayer(int label)
            : base (label)
        {
            this.rd = new Random(Guid.NewGuid().GetHashCode());
        }

        public override void Play(Match match)
        {
            if (!match.IsFinished())
            {
                var point = new int[2];

                do
                {
                    point[0] = rd.Next(3);
                    point[1] = rd.Next(3);
                } while (match.Board.Get(point) != 0);

                match.Board.Mark(point, this.Label);
            }
        }

        private Random rd;
    }
}