using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic
{
    public partial class Form1 : Form
    {
        Player currentPlayer;
        List<Button> buttons;
        Random rand = new Random();
        int playerWins = 0;
        int computerWins = 0;
        public enum Player
        {
            X, O
        }
        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            buttons.Remove(button);

            check();
            AImoves.Start();
        }

        private void AImove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon;
                buttons.RemoveAt(index);
                check();
                AImoves.Stop();
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            resetGame();
        }

        private void loadButtons()
        {
           buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
        }

        private void resetGame()
        {
            foreach(Control X in this.Controls)
            {
                if(X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = "";
                    ((Button)X).BackColor = default(Color);
                }
            }
            loadButtons();
        }

        private void check()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                AImoves.Stop();
                MessageBox.Show("U Won :D");
                playerWins++;
                label1.Text = "Player wins: " + playerWins;
                resetGame();
            }else if(button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                AImoves.Stop();
                MessageBox.Show("AI Wins :<");
                computerWins++;
                label2.Text = "AI wins: " + computerWins;
                resetGame();
            }
            if (buttons.Count == 0)
            {
                AImoves.Stop();
                MessageBox.Show("AI Wins :<");
                computerWins++;
                label2.Text = "AI wins: " + computerWins;
                resetGame();
            }
        }
    }
}
