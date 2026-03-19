using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{

    public partial class TitleScreen : Form
    {
        // Публичные показатели для передачи в MainForm
        public string SelectedDifficulty { get; private set; }
        public bool IsEasyMode { get; private set; } = false;

        // Игровые параметры (пока одинаковые для отладки)
        public int StartBalance { get; private set; } = 1000;
        public int OrderDeliveryTime { get; private set; } = 10; // секунд
        public int RandomBookTime { get; private set; } = 15; // секунд (n)
        public int CustomerTime { get; private set; } = 20; // секунд (m)
        public int MaxUnhappyCustomers { get; private set; } = 3;
        public int MaxQueueSize { get; private set; } = 5;
        public int GameDayTime { get; private set; } = 300; // секунд (5 минут)
        public int Bonus1 { get; private set; } = 10; // за отклонение ошибки
        public int Bonus2 { get; private set; } = 15; // за плагиат
        public int Bonus3 { get; private set; } = 12; // за опечатку
        public int Penalty { get; private set; } = 15;

        public TitleScreen()
        {
            InitializeComponent();
            StyleTitleScreen();
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
                SelectedDifficulty = difficulty;

                // Настройка параметров сложности
                switch (difficulty)
                {
                    case "Лёгкий":
                        IsEasyMode = true;
                        MaxQueueSize = 7;
                        MaxUnhappyCustomers = 5;
                        GameDayTime = 400;
                        break;
                    case "Нормальный":
                        IsEasyMode = false;
                        MaxQueueSize = 5;
                        MaxUnhappyCustomers = 3;
                        GameDayTime = 300;
                        break;
                    case "Сложный":
                        IsEasyMode = false;
                        MaxQueueSize = 3;
                        MaxUnhappyCustomers = 2;
                        GameDayTime = 200;
                        break;
                }

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

        private void lblNameGame_Click(object sender, EventArgs e)
        {

        }
    }
}