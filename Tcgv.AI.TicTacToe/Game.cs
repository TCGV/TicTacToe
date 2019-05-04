namespace Tcgv.AI.TicTacToe
{
    public class Game
    {
        public Game(Player p1, Player p2)
        {
            this.Player1 = p1;
            this.Player2 = p2;

            p1.SetOponent(p2);
            p2.SetOponent(p1);
        }

        public Player Player1 { get; private set; }
        
        public Player Player2 { get; private set; }

        public Match Match { get; private set; }

        public void NewMatch()
        {
            Match = new Match();
            currentPlayer = Player1;
        }

        public void Run()
        {
            if (!Match.IsFinished())
            {
                currentPlayer.Play(Match);
                if (currentPlayer == Player1)
                    currentPlayer = Player2;
                else
                    currentPlayer = Player1;
            }
        }

        private Player currentPlayer;
    }
}
