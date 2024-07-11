namespace SpecFlowTicTacToe.StepDefinitions
{
    [Binding]
    public class TicTacToeSteps
    {
        private TicTacToe.TicTacToe game;

        [Given(@"no game is currently active")]
        public void GivenNoGameIsCurrentlyActive()
        {
            game = new TicTacToe.TicTacToe();
        }

        [Given(@"it is player (.*)'s turn")]
        public void GivenItIsPlayerSTurn(char player)
        {
            EnsureGameIsInitialized();
            game.SetCurrentPlayer(player);
        }

        [Given(@"the board is empty")]
        public void GivenTheBoardIsEmpty()
        {
            EnsureGameIsInitialized();
            game.ResetBoard();
        }

        [Given(@"player X has played at position \((.*),(.*)\)")]
        public void GivenPlayerXHasPlayedAtPosition(int row, int column)
        {
            EnsureGameIsInitialized();
            game.PlayMove('X', row - 1, column - 1);
        }

        [Given(@"the following board layout")]
        public void GivenTheFollowingBoardLayout(Table table)
        {
            EnsureGameIsInitialized();
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Rows[row].Count; col++)
                {
                    var cellValue = table.Rows[row][col];
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        game.PlayMove(cellValue[0], row, col);
                    }
                }
            }
        }

        [When(@"I start a new game")]
        public void WhenIStartANewGame()
        {
            EnsureGameIsInitialized();
            game.StartNewGame();
        }

        [When(@"player (.*) plays at position \((.*),(.*)\)")]
        public void WhenPlayerPlaysAtPosition(char player, int row, int column)
        {
            EnsureGameIsInitialized();
            game.PlayMove(player, row - 1, column - 1);
        }

        [Then(@"the game board should be empty")]
        public void ThenTheGameBoardShouldBeEmpty()
        {
            EnsureGameIsInitialized();
            Assert.True(game.IsBoardEmpty());
        }

        [Then(@"it is player (.*)'s turn")]
        public void ThenItIsPlayerSTurn(char player)
        {
            EnsureGameIsInitialized();
            Assert.Equal(player, game.GetCurrentPlayer());
        }

        [Then(@"the board should have (.*) at position \((.*),(.*)\)")]
        public void ThenTheBoardShouldHaveAtPosition(char player, int row, int column)
        {
            EnsureGameIsInitialized();
            var board = game.GetBoard();
            Assert.Equal(player.ToString(), board[row - 1, column - 1]);
        }

        [Then(@"player (.*) should be declared the winner")]
        public void ThenPlayerShouldBeDeclaredTheWinner(char player)
        {
            EnsureGameIsInitialized();
            Assert.True(game.CheckForWinner(player));
        }

        [Then(@"the game should be declared a draw")]
        public void ThenTheGameShouldBeDeclaredADraw()
        {
            EnsureGameIsInitialized();
            Assert.True(game.IsDraw());
        }

        [Then(@"the board should show (.*) at position \((.*),(.*)\)")]
        public void ThenTheBoardShouldShowAtPosition(char player, int row, int column)
        {
            EnsureGameIsInitialized();
            var board = game.GetBoard();
            Assert.Equal(player.ToString(), board[row - 1, column - 1]);
        }

        private void EnsureGameIsInitialized()
        {
            if (game == null)
            {
                game = new TicTacToe.TicTacToe();
            }
        }
    }
}
