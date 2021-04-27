using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGuessNumber
{
    public class Game
    {
        private int number;
        private int times;
        private int max;
        private int min;

        public Game()
        {
            number = 0;
            times = 0;
            min = 0;
            max = 2000;
        }
        public DialogResult Start()
        {
            DialogResult result = MessageBox.Show("    Почнемо гру?", "Гра", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }
        public int GenerateNum(bool quest)
        {
            if (quest)
                min = number;
            else
                max = number;
            if (min < max)
            number = MyRand.GetRand(min, max);
            times++;
            return number;
        }
        public bool Question()
        {
            DialogResult result = MessageBox.Show($"Воно більше за {number}?", "Гра", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else return false;
        }
        public void GuessNumber()
        {
            MessageBox.Show("Загадай число від 1 до 2000", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("І запиши", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Записали?", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public bool IsItGuess()
        {
            DialogResult result = MessageBox.Show($"Ваше число {number}?", "Гра", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                return true;
            else return false;
        }
        public void EndGame()
        {
            MessageBox.Show($"Вітаю ваше число {number}", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Число вгадано\n за {times} спроб", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            number = 0;
            min = 0;
            max = 2000;
            times = 0;
        }
    }
}
