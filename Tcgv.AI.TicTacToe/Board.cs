using System;
using System.Collections.Generic;

namespace Tcgv.AI.TicTacToe
{
    public class Board
    {
        public Board()
        {
            Create();
        }

        public int Get(int[] point)
        {
            return board[point[0]][point[1]];
        }

        public void Mark(int[] point, int label)
        {
            if (Get(point) != 0)
                throw new Exception();
            board[point[0]][point[1]] = label;
            clearPositions--;
        }

        public void Clear(int[] pos)
        {
            board[pos[0]][pos[1]] = 0;
            clearPositions++;
        }

        public int CountClearPositions()
        {
            return this.clearPositions;
        }

        public IEnumerable<int[]> GetClearPositions()
        {
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    if (board[i][j] == 0)
                        yield return new[] { i, j };
        }

        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < board.Length; i++)
            {
                str += (i > 0 ? "\n" : "");
                for (int j = 0; j < board[i].Length; j++)
                {
                    var l = board[i][j];
                    str += (j > 0 ? " " : "") + (l == 1 ? "X" : l == 2 ? "O" : "+");
                }
            }
            return str;
        }

        private void Create()
        {
            this.board = new int[3][];
            for (int i = 0; i < this.board.Length; i++)
                this.board[i] = new int[3];
            this.clearPositions = 9;
        }

        private int[][] board;
        private int clearPositions;
    }
}