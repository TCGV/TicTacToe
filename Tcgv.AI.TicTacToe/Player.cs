namespace Tcgv.AI.TicTacToe
{
    public abstract class Player
    {
        public Player(int label)
        {
            this.Label = label;
        }

        public int Label { get; private set; }

        public virtual void SetOponent(Player oponent)
        {
            
        }

        public abstract void Play(Match match);
    }
}
