using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tcgv.AI.TicTacToe;

namespace Tcgv.AI.TicTacToe.UnitTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void MiniMaxPlayer_Against_MiniMaxPlayer_ExpectingDraw_Test()
        {
            var p1 = new MiniMaxPlayer(1);
            var p2 = new MiniMaxPlayer(2);

            var g = new Game(p1, p2);

            g.NewMatch();
            while (!g.Match.IsFinished())
                g.Run();

            Assert.IsTrue(g.Match.IsFinished());
            Assert.IsNull(g.Match.GetWinner());
        }

        [TestMethod]
        public void MiniMaxPlayer_Against_RandomPlayer_NotExpectingDefeat_Test()
        {
            var p1 = new RandomPlayer(1);
            var p2 = new MiniMaxPlayer(2);

            var g = new Game(p1, p2);

            g.NewMatch();
            while (!g.Match.IsFinished())
                g.Run();

            Assert.IsTrue(g.Match.IsFinished());
            Assert.AreNotEqual(p1.Label, g.Match.GetWinner());
        }
    }
}
