using System;
using System.Windows.Forms;

public class GameLogic
{
    private Button[,] gridButtons;
    private bool isPlayerTurn;
    private int moveCount;

    public GameLogic(Button[,] buttons, bool playerStarts)
    {
        gridButtons = buttons;
        isPlayerTurn = playerStarts;
        moveCount = 0;
    }

    public void StartNewGame()
    {
        
        moveCount = 0;
        foreach (Button button in gridButtons)
        {
            button.Text = "";
            button.Enabled = true;
        }
        isPlayerTurn = true;
        if (!isPlayerTurn)
        {
            ComputerMove(); 
        }
    }

    public void PlayerMove(Button selectedButton)
    {
        if (selectedButton.Text == "" && isPlayerTurn)
        {
            selectedButton.Text = "X"; 
            moveCount++;
            CheckForWinOrDraw();
            isPlayerTurn = false; 
            if (moveCount < 9) 
            {
                ComputerMove();
            }
        }
    }

    private void ComputerMove()
    {
        Random random = new Random();
        Button moveButton;
        do
        {
            int row = random.Next(3);
            int col = random.Next(3);
            moveButton = gridButtons[row, col];
        } while (moveButton.Text != "");

        moveButton.Text = "O";
        moveCount++;
        CheckForWinOrDraw();
        isPlayerTurn = true;
    }

    private void CheckForWinOrDraw()
    {
        if (IsWinningCondition("X"))
        {
            MessageBox.Show("Игрок победил!");
            DisableAllButtons();
        }
        else if (IsWinningCondition("O"))
        {
            MessageBox.Show("Компьютер победил!");
            DisableAllButtons();
        }
        else if (moveCount == 9)
        {
            MessageBox.Show("Ничья!");
            DisableAllButtons();
        }
    }

    private bool IsWinningCondition(string playerSymbol)
    {
        for (int i = 0; i < 3; i++)
        {
            if (gridButtons[i, 0].Text == playerSymbol && gridButtons[i, 1].Text == playerSymbol && gridButtons[i, 2].Text == playerSymbol)
                return true;
        }

        for (int i = 0; i < 3; i++)
        {
            if (gridButtons[0, i].Text == playerSymbol && gridButtons[1, i].Text == playerSymbol && gridButtons[2, i].Text == playerSymbol)
                return true;
        }

        if (gridButtons[0, 0].Text == playerSymbol && gridButtons[1, 1].Text == playerSymbol && gridButtons[2, 2].Text == playerSymbol)
            return true;

        if (gridButtons[0, 2].Text == playerSymbol && gridButtons[1, 1].Text == playerSymbol && gridButtons[2, 0].Text == playerSymbol)
            return true;

        return false;
    }


    private void DisableAllButtons()
    {
        foreach (Button button in gridButtons)
        {
            button.Enabled = false;
        }
    }
}
