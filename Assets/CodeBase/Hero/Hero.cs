namespace CodeBase.Hero
{
    public class Hero
    {
        public Hero(int health, int mana)
        {
            Health = new Point(health);
            Mana = new Point(mana);
        }

        public Point Health { get; }
        public Point Mana { get; }
    }
}