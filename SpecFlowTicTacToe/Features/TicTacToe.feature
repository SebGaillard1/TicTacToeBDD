Feature: TicTacToe

A short summary of the feature

  Scenario: Start a new game
    Given no game is currently active
    When I start a new game
    Then the game board should be empty
    And it is player X's turn

  Scenario: Player X plays a move
    Given it is player X's turn
    And the board is empty
    When player X plays at position (1,1)
    Then the board should have X at position (1,1)
    And it is player O's turn

  Scenario: Player O plays a move
    Given it is player O's turn
    And player X has played at position (1,1)
    When player O plays at position (1,2)
    Then the board should have O at position (1,2)
    And it is player X's turn

  Scenario: Winning the game
    Given the following board layout
      |   |   |   |
      | X | X |   |
      | O | O |   |
      |   |   |   |
    And it is player X's turn
    When player X plays at position (1,3)
    Then the board should show X at position (1,3)
    And player X should be declared the winner

  Scenario: Game is a draw
    Given the following board layout
      | X | X | O |
      | O | O | X |
      | X |   | O |
    And it is player X's turn
    When player X plays at position (2,2)
    Then the board should show X at position (2,2)
    And the game should be declared a draw