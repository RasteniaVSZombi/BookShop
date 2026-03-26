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
        private GameSettings _gameSettings;
        private bool _isWinner;

        /// <summary>
        /// Конструктор формы завершения игры
        /// </summary>
        /// <param name="gameSettings">Настройки игры</param>
        /// <param name="isWinner">True — победа, False — проигрыш</param>
        public FormEndGame(GameSettings gameSettings, bool isWinner)
        {
            InitializeComponent(); // Инициализация компонентов формы

            // Сохраняем переданные данные
            _gameSettings = gameSettings;
            _isWinner = isWinner;


        }



    }
}
