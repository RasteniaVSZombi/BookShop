using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{

    public partial class TitleScreen : Form
    {
        public GameSettings _gameSettings;

        public TitleScreen()
        {
            InitializeComponent();
            StyleTitleScreen();
            _gameSettings = new GameSettings();
        }

        private void StyleTitleScreen()
        {
            // Стилизация кнопок
            StyleButton(btnEasy, Color.FromArgb(100, 0, 150, 0), Color.LightGreen);
            StyleButton(btnNormal, Color.FromArgb(100, 150, 100, 0), Color.Gold);
            StyleButton(btnHard, Color.FromArgb(100, 150, 0, 0), Color.OrangeRed);
            StyleButton(btnAbout, Color.FromArgb(100, 50, 50, 150), Color.LightBlue);

            lblTeamName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = foreColor;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Cursor = Cursors.Hand;
        }

        private void ShowDifficultyConfirmation(string difficulty)
        {
            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите начать игру в режиме {difficulty}?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                _gameSettings.Difficulty = difficulty;
                _gameSettings.SetDifficulty(difficulty);// Настройка параметров сложности

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            ShowDifficultyConfirmation("«Лёгкий»");
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            ShowDifficultyConfirmation("«Нормальный»");
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            ShowDifficultyConfirmation("«Сложный»");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(

                "Добро пожаловать в симулятор книжного магазина!\n\n" +
                "Ваша задача:\n" +
                "1.Заказывайте книги у поставщиков\n" +
                "2.Проверяйте поставки на ошибки (плагиат, опечатки)\n" +
                "3.Обслуживайте покупателей\n" +
                "4.Не допускайте больших очередей\n" +
                "5.Следите за балансом магазина\n\n" +
                "Условия поражения:\n" +
                "1)Баланс <= 0\n" +
                "2)Очередь > максимума\n" +
                "3)Слишком много недовольных клиентов\n\n" +
                "Удачи в управлении магазином!",
                "Об игре",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }
}