using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Library
{
    public static class TicTacToe
    {
        /// <summary>
        /// Returns the name of the winner if a winner can be found
        /// Limited to a 3x3 grid at the moment
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static string EvaluateBoard(Board board)
        {
            // Checking for victory on rows
            for (int row = 0; row < 3; row++)
                if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && board[row, 0] != null)
                    return board[row, 0];

            // Checking for victory on columns
            for (int column = 0; column < 3; column++)
                if (board[0, column] == board[1, column] && board[1, column] == board[2, column] && board[0, column] != null)
                    return board[0, column];

            // Checking for victory on diagonals.
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != null)
                return board[0, 0];

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != null)
                return board[0, 2];

            // No winners found, return null
            return null;
        }

        /// <summary>
        /// Returns the highest value index (row, column) for a move
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static (int, int) FindBestMove(Board board, string ownCharacterId, string opponentCharacterId)
        {
            int bestValue = -1000;
            int moveValue = 0;
            (int, int) bestIndex = (-1, -1);

            for (int row = 0; row < board.RowCount; row++)
            {
                for (int column = 0; column < board.ColumnCount; column++)
                {
                    // Check if cell is empty
                    if (board[row, column] == null)
                    {
                        // Test the move
                        board[row, column] = ownCharacterId;
                        moveValue = TestBoardMinimax(board, ownCharacterId, opponentCharacterId, 0, false);

                        // Undo the move
                        board[row, column] = null;

                        // Store the value if it was better
                        if (moveValue > bestValue)
                        {
                            bestValue = moveValue;
                            bestIndex = (row, column);
                        }
                    }
                }
            }

            return bestIndex;
        }

        /// <summary>
        /// Tests the board to see if there are any moves available
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool MoveIsAvailable(Board board)
        {
            for (int row = 0; row < board.RowCount; row++)
                for (int column = 0; column < board.ColumnCount; column++)
                    if (board[row, column] == null)
                        return true;

            return false;
        }

        /// <summary>
        /// Applys the minimax algorithm to test the value of the board in its current state
        /// </summary>
        /// <param name="board">The board containing the game's cell data</param>
        /// <param name="characterId">The id of the player we are testing for</param>
        /// <param name="depth">The depth we are into testing the board</param>
        /// <param name="isMax">Boolean indicating if its the testing player</param>
        /// <returns></returns>
        private static int TestBoardMinimax(Board board, string ownCharacterId, string opponentCharacterId, int depth, bool isMax)
        {
            string winner = string.Empty;
            int bestValue = int.MinValue;

            winner = TicTacToe.EvaluateBoard(board);
            if (winner != null)
            {
                if (winner == ownCharacterId)
                    return 10;
                else
                    return -10;
            }

            if (TicTacToe.MoveIsAvailable(board) == false)
                return 0;

            // Traverse all cells
            if (isMax)
            {
                bestValue = -1000;
                for (int row = 0; row < board.RowCount; row++)
                {
                    for (int column = 0; column < board.ColumnCount; column++)
                    {
                        if (board[row, column] == null)
                        {
                            // Make the move
                            board[row, column] = ownCharacterId;

                            // Recursively execute test
                            bestValue = Math.Max(bestValue, TicTacToe.TestBoardMinimax(board, ownCharacterId, opponentCharacterId, depth + 1, !isMax));

                            // Undo the move
                            board[row, column] = null;
                        }
                    }
                }

                return bestValue;
            }
            else
            {
                bestValue = 1000;
                for (int row = 0; row < board.RowCount; row++)
                {
                    for (int column = 0; column < board.ColumnCount; column++)
                    {
                        if (board[row, column] == null)
                        {
                            // Make the move
                            board[row, column] = opponentCharacterId;

                            // Recursively execute test
                            bestValue = Math.Min(bestValue, TicTacToe.TestBoardMinimax(board, ownCharacterId, opponentCharacterId, depth + 1, !isMax));

                            // Undo the move
                            board[row, column] = null;
                        }
                    }
                }

                return bestValue;
            }
        }

        #region Internal Class
        public class Board
        {
            private string[,] _cellStates;
            public string this[int row, int column]
            {
                get { return _cellStates[row, column]; }
                set { _cellStates[row, column] = value; }
            }
            public int RowCount { get; set; }
            public int ColumnCount { get; set; }

            public Board()
            {
                this.RowCount = 3;
                this.ColumnCount = 3;
                this._cellStates = new string[this.RowCount, this.ColumnCount];
            }

            public Board(int rowCount, int columnCount)
            {
                this.RowCount = rowCount;
                this.ColumnCount = columnCount;
                this._cellStates = new string[this.RowCount, this.ColumnCount];
            }
        }
        #endregion
    }
}
