namespace Tcgv.AI.TicTacToe
{
    public class Match
    {
        public Match()
        {
            CreateBoard();
            CreateWinPatterns();
        }

        public Board Board { get; private set; }

        public bool IsFinished()
        {
            return GetWinner() != null || Board.CountClearPositions() == 0;
        }

        public int? GetWinner()
        {
            foreach (var p in winPatterns)
            {
                var label = Board.Get(p[0]);
                if (label != 0 && label == Board.Get(p[1]) && label == Board.Get(p[2]))
                    return label;
            }

            return null;
        }

        private void CreateWinPatterns()
        {
            winPatterns = new int[][][]
            {
                new int[][]{ new int[]{0,0}, new int[]{0,1}, new int[]{0,2} },
                new int[][]{ new int[]{1,0}, new int[]{1,1}, new int[]{1,2} },
                new int[][]{ new int[]{2,0}, new int[]{2,1}, new int[]{2,2} },
                new int[][]{ new int[]{0,0}, new int[]{1,0}, new int[]{2,0} },
                new int[][]{ new int[]{0,1}, new int[]{1,1}, new int[]{2,1} },
                new int[][]{ new int[]{0,2}, new int[]{1,2}, new int[]{2,2} },
                new int[][]{ new int[]{0,0}, new int[]{1,1}, new int[]{2,2} },
                new int[][]{ new int[]{0,2}, new int[]{1,1}, new int[]{2,0} }
            };
        }

        private void CreateBoard()
        {
            this.Board = new Board();
        }

        private int[][][] winPatterns;
    }
}