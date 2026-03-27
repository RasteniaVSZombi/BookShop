using BookLibrary;
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
    public partial class FormEndGame : Form
    {
        /// <summary>
        /// Конструктор формы завершения игры
        /// </summary>
        /// <param name="gameSettings">Настройки игры</param>
        /// <param name="isWinner">True — победа, False — поражение</param>
        /// <param name="elapsedTime">пройденное время</param>
        /// <param name="_store">магазин</param>
        /// <param name="unhappyCustomers">количество недовольных покупателей</param>
        /// <param name="QueueSize">очередь</param>
        public FormEndGame(GameSettings gameSettings, bool isWinner, int elapsedTime, Shop _store, int unhappyCustomers, int QueueSize)
        {
            InitializeComponent(); // Инициализация компонентов формы

            phonoWin.Visible = false;
            photoLose.Visible = false;

            if(isWinner)
            {
                phonoWin.Visible = true;
                photoLose.Visible = false;
            }
            else
            {
                photoLose.Visible = true;
                phonoWin.Visible = false;
            }

            lbStats.Text = $"Статистика:\n" +
                $"Сложность: {gameSettings.Difficulty}\n" +
                $"Прошло игрового времени: {elapsedTime} / {gameSettings.GameDayTime}\n" +
                $"Оставшийся баланс магазина: {_store.Balance}\n" +
                $"Недовольных покупателей: {unhappyCustomers} / {gameSettings.MaxUnhappyCustomers}\n" +
                $"Очередь: {QueueSize} / {gameSettings.MaxQueueSize}\n";

        }



    }
}
