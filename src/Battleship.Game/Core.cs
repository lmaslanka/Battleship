namespace Battleship.Game
{
    using System;
    public class Core
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

        private void PlaceShipsOnGameBoard()
        {
            // loop over array of ships
            // pick location of ship
            // pick ship direction
            // check if valid location
            // place ship
        }

        private void InitializeGameBoard()
        {
            for(int y = 0; y < GAME_BOARD_SIZE; y++)
            {
                for(int x = 0; x < GAME_BOARD_SIZE; x++)
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

        public Core()
        {
            this.gameBoard = new int[GAME_BOARD_SIZE, GAME_BOARD_SIZE];
            this.shipSizes = new int[NUMBER_OF_SHIPS];

            this.InitializeShipSizes();
            this.InitializeGameBoard();
            this.PlaceShipsOnGameBoard();
        }

        private int[,] gameBoard;
        private int[] shipSizes;

        private const int AIRCRAFT_CARRIER_SIZE = 5;
        private const int BATTLESHIP = 4;
        private const int SUBMARINE = 3;
        private const int CRUISER = 3;
        private const int DESTROYER = 2;

        public const int GAME_BOARD_SIZE = 10;
        public const int NUMBER_OF_SHIPS = 5;
    }
}
