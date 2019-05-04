namespace Tcgv.AI.TicTacToe
{
    public class MiniMaxPlayer : Player
    {
        public MiniMaxPlayer(int label)
            : base (label) { }

        public override void SetOponent(Player oponent)
        {
            this.oponentLabel = oponent.Label;
        }

        public override void Play(Match match)
        {
            var m = MiniMax(match, true);
            match.Board.Mark(m.Pos, this.Label);
        }

        private Move MiniMax(Match match, bool maxPlay)
        {
            if (match.IsFinished())
            {
                var winner = match.GetWinner();
                var r = winner == this.Label ? int.MaxValue :
                    winner > 0 ? int.MinValue : 0;
                return new Move { Result = r };
            }

            var move = new Move();
            foreach (var pos in match.Board.GetClearPositions())
            {
                match.Board.Mark(pos, maxPlay ? this.Label : this.oponentLabel);
                var m = MiniMax(match, !maxPlay);
                match.Board.Clear(pos);

                if (move.Pos == null || (maxPlay && move.Result < m.Result) || (!maxPlay && move.Result > m.Result))
                {
                    move.Result = m.Result;
                    move.Pos = pos;
                }
            }

            return move;
        }

        private int oponentLabel;

        struct Move
        {
            public int[] Pos;
            public int Result;
        }
    }
}