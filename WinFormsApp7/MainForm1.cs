using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToeApp
{
    public partial class MainForm : Form
    {
        private GameLogic gameLogic;

        public MainForm()
        {
            InitializeComponent();
            InitializeMenuAndToolBar();
            InitializeGame();
        }

        private void InitializeMenuAndToolBar()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem gameMenu = new ToolStripMenuItem("����");
            ToolStripMenuItem newGameMenuItem = new ToolStripMenuItem("����� ����", null, RestartButton_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("�����", null, (s, e) => Application.Exit());
            gameMenu.DropDownItems.Add(newGameMenuItem);
            gameMenu.DropDownItems.Add(exitMenuItem);
            menuStrip.Items.Add(gameMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Items.Add(new ToolStripButton("����� ����", null, RestartButton_Click));
            toolStrip.Items.Add(new ToolStripButton("�����", null, (s, e) => Application.Exit()));
            this.Controls.Add(toolStrip);
        }

        private void InitializeGame()
        {
            gameLogic = new GameLogic(gridButtons, playerStartsCheckbox.Checked);
            gameLogic.StartNewGame();
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            gameLogic.PlayerMove(selectedButton);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            gameLogic.StartNewGame();
        }
    }
}
