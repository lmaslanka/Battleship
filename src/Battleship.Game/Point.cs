namespace Battleship.Game
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public int x, y;
    }
}
