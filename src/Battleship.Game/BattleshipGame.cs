namespace Battleship.Game
{
    using System;

    public class BattleshipGame
    {
        public bool Shot(Point point)
        {
            throw new NotImplementedException();
        }

        public int NumberOfShipsSunk()
        {
            throw new NotImplementedException();
        }

        public bool AllSunk()
        {
            throw new NotImplementedException();
        }

        public int TotalShotsTaken()
        {
            throw new NotImplementedException();
        }

        public int[] ShipSizes()
        {
            throw new NotImplementedException();
        }

        public void PrintBoard()
        {
            Console.Write("    |");
            for (int i = 0; i < GAME_BOARD_SIZE; i++)
            {
                Console.Write($"{this.gameBoardLetters[i],2} |");
            }
            Console.WriteLine();

            for (int y = 0; y < GAME_BOARD_SIZE; y++)
            {
                Console.Write($"|{y + 1,2} |");
                for(int x = 0; x < GAME_BOARD_SIZE; x++)
                {
                    Console.Write($"{this.PrintTile(x, y),2} |");
                }
                Console.WriteLine();
            }
        }

        private string PrintTile(int x, int y)
        {
            if (this.gameBoard[x, y] == 0)
            {
                return " ";
            }

            return "S";
        }

        private void PlaceShipsOnGameBoard()
        {
            var rand = new Random();
            for (int i = 0; i < NUMBER_OF_SHIPS; i++)
            {
                bool hasFoundLocation = false;
                while (!hasFoundLocation)
                {
                    Point shipLocation = this.GetShipLocation(rand);
                    Direction shipDirection = this.GetShipDirection(rand);

                    if (this.IsValidLocation(shipLocation, shipDirection, this.shipSizes[i]))
                    {
                        this.PlaceShip(shipLocation, shipDirection, this.shipSizes[i]);
                        hasFoundLocation = true;
                    }
                }
            }
        }

        private Point GetShipLocation(Random rand)
        {
            return new Point(rand.Next(GAME_BOARD_SIZE), rand.Next(GAME_BOARD_SIZE));
        }

        private Direction GetShipDirection(Random rand)
        {
            return (Direction)rand.Next(4);
        }

        private bool IsValidLocation(Point shipLocation, Direction direction, int shipSize)
        {
            if (this.gameBoard[shipLocation.x, shipLocation.y] == 0)
            {
                switch (direction)
                {
                    case Direction.North:
                        return this.IsNorthDirectionValid(shipLocation.y, shipSize);
                    case Direction.East:
                        return this.IsEastDirectionValid(shipLocation.x, shipSize);
                    case Direction.South:
                        return this.IsSouthDirectionValid(shipLocation.y, shipSize);
                    case Direction.West:
                        return this.IsWestDirectionValid(shipLocation.x, shipSize);
                    default:
                        return false;
                }
            }

            return false;
        }

        private bool IsNorthDirectionValid(int y, int shipSize)
        {
            if ((y - shipSize) >= 0)
            {
                return true;
            }

            return false;
        }

        private bool IsEastDirectionValid(int x, int shipSize)
        {
            if ((x + shipSize) < GAME_BOARD_SIZE)
            {
                return true;
            }

            return false;
        }

        private bool IsSouthDirectionValid(int y, int shipSize)
        {
            if ((y + shipSize) < GAME_BOARD_SIZE)
            {
                return true;
            }

            return false;
        }

        private bool IsWestDirectionValid(int x, int shipSize)
        {
            if ((x - shipSize) >= 0)
            {
                return true;
            }

            return false;
        }

        private void PlaceShip(Point shipLocation, Direction shipDirection, int shipSize)
        {
            for(int i = 0; i < shipSize; i++)
            {
                switch(shipDirection)
                {
                    case Direction.North:
                        this.gameBoard[shipLocation.x, shipLocation.y - i] = 1;
                        break;
                    case Direction.East:
                        this.gameBoard[shipLocation.x + i, shipLocation.y] = 1;
                        break;
                    case Direction.South:
                        this.gameBoard[shipLocation.x, shipLocation.y + i] = 1;
                        break;
                    case Direction.West:
                        this.gameBoard[shipLocation.x - i, shipLocation.y] = 1;
                        break;
                }
            }
        }

        private void InitializeGameBoard()
        {
            for (int y = 0; y < GAME_BOARD_SIZE; y++)
            {
                for (int x = 0; x < GAME_BOARD_SIZE; x++)
                {
                    this.gameBoard[x, y] = 0;
                }
            }
        }

        private void InitializeShipSizes()
        {
            this.shipSizes[0] = AIRCRAFT_CARRIER_SIZE;
            this.shipSizes[1] = BATTLESHIP;
            this.shipSizes[2] = SUBMARINE;
            this.shipSizes[3] = CRUISER;
            this.shipSizes[4] = DESTROYER;
        }

        public BattleshipGame()
        {
            this.gameBoard = new int[GAME_BOARD_SIZE, GAME_BOARD_SIZE];
            this.shipSizes = new int[NUMBER_OF_SHIPS];

            this.InitializeShipSizes();
            this.InitializeGameBoard();
            this.PlaceShipsOnGameBoard();
        }

        private int[,] gameBoard;
        private int[] shipSizes;
        private string[] gameBoardLetters = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        private const int AIRCRAFT_CARRIER_SIZE = 5;
        private const int BATTLESHIP = 4;
        private const int SUBMARINE = 3;
        private const int CRUISER = 3;
        private const int DESTROYER = 2;

        public const int GAME_BOARD_SIZE = 10;
        public const int NUMBER_OF_SHIPS = 5;
    }
}
