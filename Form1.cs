using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

/* Final Assignemt MS4 - Wheel Of Fortune (Single Player) */
// Name: Cameron Deans

namespace Assignment2_MS1_CDeans
{
    public partial class Form1 : Form
    {
        Player player1;
        Game game1;

        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            player = new SoundPlayer("swThemeSong.wav");
        }

        private void startGameBTN_Click(object sender, EventArgs e)
        {
            player.Play();

            player1 = new Player
            {
                PlayersName = (player1NameTB.Text)
            };

            Console.Beep();

            player1ScoreTB.Text = Convert.ToString(player1.PlayerScore);

            player1LossesTB.Text = Convert.ToString(player1.NumberOfLosses);

            game1 = new Game();

            targetWordTB.Text = generateHidden(game1.TargetWord);

            game1.Hint = game1.AssignHint(game1.TargetWord);

            string gameHint = game1.Hint;

            MessageBox.Show(gameHint);

            image0.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image1.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image2.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image3.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image4.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image5.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image6.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;
            image7.Image = Assignment2_MS1_CDeans.Properties.Resources.redLightSaber;

            StartGameBTN.Hide();
        }

        public string generateHidden(string initialTargetWord)
        {
            game1.TargetWord = game1.AssignTargetWord();

            string gameWord = game1.TargetWord;
            char[] gameWordArray = gameWord.ToCharArray();

            for (int index = 0; index < game1.TargetWord.Length; index++)
            {
                gameWordArray[index] = '-';
                gameWord = new string(gameWordArray);
            }
            return gameWord;
        }

        private void gameLetterTB_TextChanged(object sender, EventArgs e)
        {
            if (gameLetterTB.Text.Length > 0)
            {
                char playerLetter = gameLetterTB.Text.ToLower()[0];
                char[] targetWordTBArray = targetWordTB.Text.ToCharArray();

                for (int index = 0; index < game1.TargetWord.Length; index++)
                {
                    if (game1.TargetWord[index] == playerLetter)
                    {
                        targetWordTBArray[index] = playerLetter;
                        player1.PlayerScore++;
                        player1ScoreTB.Text = Convert.ToString(player1.PlayerScore);
                    }
                }
                targetWordTB.Text = new string(targetWordTBArray);
                gameLetterTB.Text = "";

                if (targetWordTB.Text == game1.TargetWord)
                {

                    MessageBox.Show("WELL DONE!");

                    player1.NumberOfWins++;

                    Console.Beep();

                    PictureBox[] images = { image0, image1, image2, image3, image4, image5, image6, image7 };

                    for (int ctr = 0; ctr < 9; ctr++)
                    {
                        if (ctr == (player1.NumberOfWins -1))
                        {
                            images[ctr].Image = Assignment2_MS1_CDeans.Properties.Resources.lightsaber_full;
                        }
                    }

                    player1WinsTB.Text = Convert.ToString(player1.NumberOfWins);

                    if (player1.NumberOfWins != 8)
                    {
                        DialogResult dialogResult;
                        dialogResult = MessageBox.Show("Play Again?", "Wheel Of Fortune", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            player1.PlayerScore = 0;

                            player1ScoreTB.Text = Convert.ToString(player1.PlayerScore);

                            targetWordTB.Text = generateHidden(game1.TargetWord);

                            game1.Hint = game1.AssignHint(game1.TargetWord);

                            string gameHint = game1.Hint;

                            MessageBox.Show(gameHint);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }

                    else if (player1.NumberOfWins == 8)
                    {
                        DialogResult dialogResult;
                        dialogResult = MessageBox.Show("Watch ending scene?", " OR Cancel To - Exit Game", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();

                            milleniumFalcon.Visible = true;
                            

                            DialogResult dialogResult1;
                            dialogResult1 = MessageBox.Show("YOU WIN!!", "Exit Game", MessageBoxButtons.OK);
                            if (dialogResult1 == DialogResult.OK)
                            {
                                Application.Exit();
                            }

                        }
                        if (dialogResult == DialogResult.Cancel)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}