namespace TicTacToe
{
    public class TicTacToe
    {
        private string[,] board = new string[3, 3];
        private char currentPlayer;

        public TicTacToe()
        {
            ResetBoard();
        }

        public void StartNewGame()
        {
            ResetBoard();
            currentPlayer = 'X';
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = string.Empty;
                }
            }
        }

        public bool IsBoardEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!string.IsNullOrEmpty(board[i, j]))
                        return false;
                }
            }
            return true;
        }

        public void PlayMove(char player, int row, int column)
        {
            if (board[row, column] == string.Empty)
            {
                board[row, column] = player.ToString();
                currentPlayer = (player == 'X') ? 'O' : 'X';
            }
            else
            {
                throw new InvalidOperationException("Cell is already occupied.");
            }
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void SetCurrentPlayer(char player)
        {
            currentPlayer = player;
        }

        public bool CheckForWinner(char player)
        {
            string p = player.ToString();
            // Vérifier les lignes horizontales
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == p && board[row, 1] == p && board[row, 2] == p)
                    return true;
            }

            // Vérifier les colonnes verticales
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == p && board[1, col] == p && board[2, col] == p)
                    return true;
            }

            // Vérifier les diagonales
            if (board[0, 0] == p && board[1, 1] == p && board[2, 2] == p)
                return true;

            if (board[0, 2] == p && board[1, 1] == p && board[2, 0] == p)
                return true;

            return false;
        }

        public bool IsDraw()
        {
            // Si un joueur a gagné, ce n'est pas un match nul
            if (CheckForWinner('X') || CheckForWinner('O'))
                return false;

            // Vérifier si toutes les cases sont remplies
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(board[i, j]))
                        return false;
                }
            }

            return true;  // Si toutes les cases sont remplies et personne n'a gagné, c'est un match nul
        }

        public string[,] GetBoard()
        {
            return board;
        }
    }
}
