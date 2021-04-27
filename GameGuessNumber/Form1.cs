using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GameGuessNumber
{
    public partial class Form1 : Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath Button_Path = new GraphicsPath();
            Button_Path.AddEllipse(5, 5, this.buttonStartGame.Width - 10, 90);
            Region Button_Region = new Region(Button_Path);
            this.buttonStartGame.Region = Button_Region;

            GraphicsPath TextPath = new GraphicsPath();
            TextPath.AddEllipse(5, 5, this.labelNumber.Width - 10, 90);
            Region TextRegion = new Region(TextPath);
            this.labelNumber.Region = TextRegion;

            GraphicsPath Text2Path = new GraphicsPath();
            Text2Path.AddEllipse(5, 10, this.labelText.Width - 10, 70);
            Region Text2Region = new Region(Text2Path);
            this.labelText.Region = Text2Region;
        }
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            if (game.Start() == DialogResult.OK)
            {
                buttonStartGame.Visible = false;
                labelNumber.Visible = true;
                labelText.Visible = true;
                Game();
            }
            else
            {
                labelText.Visible = true;
                buttonStartGame.Visible = false;
                string tmp = labelText.Text;
                labelText.Text = "Як бажаєте";
                labelText.TextAlign = ContentAlignment.MiddleCenter;
                labelText.Refresh();
                Thread.Sleep(2000);
                labelText.Visible = false;
                buttonStartGame.Visible = true;
                labelText.Text = tmp;
            }
        }
        private void Game()
        {
            game.GuessNumber();
            GenerateNumber(true);
            while (!game.IsItGuess())
            {
                GenerateNumber(game.Question());
            }
            EndGame();
        }
        private void GenerateNumber(bool ques)
        {
            for (int i = 0; i < 10; i++)
            {
                labelNumber.Text = Convert.ToString(MyRand.GetRand(1, 2000));
                labelNumber.Refresh();
                labelText.ForeColor = Color.FromArgb(MyRand.GetRand(1,255), 100, 100);
                labelText.Refresh();
                Thread.Sleep(300);
            }
            labelNumber.Text = Convert.ToString(game.GenerateNum(ques));
            labelNumber.Refresh();
        }
        private void EndGame()
        {
            game.EndGame();
            string tmp = labelText.Text;
            labelText.ForeColor = Color.Black;
            labelText.Text = "Вітаю";
            labelText.Refresh();
            Thread.Sleep(2000);
            labelText.Visible = false;
            labelText.Text = tmp;
            labelNumber.Visible = false;
            buttonStartGame.Visible = true;
        }
    }
}
