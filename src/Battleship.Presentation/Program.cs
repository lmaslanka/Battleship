namespace Battleship.Presentation
{
    using Battleship.Game;

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new BattleshipGame();

            game.PrintBoard();
        }
    }
}
