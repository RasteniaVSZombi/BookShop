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
            "Разработанное приложение «Книжный магазин» - игровая симуляция управления магазином книг.\n\n" +
            "Игрок выступает в роли владельца книжного магазина и выполняет основные задачи по его развитию и управлению.\n\n" +

            "Игровая цель\n\n" +
            "Основной целью игры является эффективное управление ассортиментом книг и увеличение баланса магазина за счёт продажи книг.\n\n" +

            "Игровой процесс\n\n" +
            "Игровой процесс включает следующие действия:\n" +
            "* создание новых книг (вручную или случайным образом);\n" +
            "* распределение книг по шкафам в зависимости от жанра;\n" +
            "* управление ограниченным пространством хранения;\n" +
            "* поиск книг по различным параметрам;\n" +
            "* продажа книг с целью получения прибыли.\n\n" +

            "Каждое действие пользователя влияет на состояние магазина, в частности на доступное место и текущий баланс.\n\n" +

            "Игровая механика\n\n" +
            "В игре реализованы следующие механики:\n" +
            "* ресурсная система — ограниченное количество мест в шкафах;\n" +
            "* экономика — баланс увеличивается при продаже книг;\n" +
            "* поиск и управление данными — игрок должен эффективно находить и продавать книги;\n" +
            "* случайная генерация — добавляет разнообразие игровому процессу.\n\n" +

            "Особенности игры\n\n" +
            "* возможность хранения нескольких шкафов одного жанра;\n" +
            "* гибкая система распределения книг;\n" +
            "* необходимость принимать решения при заполнении шкафов;\n" +
            "* обработка ошибок и ограничений, влияющих на игровой процесс.",
                "Об игре",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }
}