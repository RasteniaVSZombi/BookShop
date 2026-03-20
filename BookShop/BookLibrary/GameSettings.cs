using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class GameSettings
    {
        // Основные параметры игры
        public string Difficulty { get; set; }
        public bool IsEasyMode { get; set; }

        // Экономические параметры
        public float StartBalance { get; set; }
        public float OrderDeliveryTime { get; set; }
        public float RandomBookTime { get; set; }
        public float CustomerTime { get; set; }

        // Параметры игрового процесса
        public int MaxUnhappyCustomers { get; set; }
        public int MaxQueueSize { get; set; }
        public int GameDayTime { get; set; }

        // Бонусы и штрафы
        public int Bonus1 { get; set; }  // за отклонение ошибки
        public int Bonus2 { get; set; }  // за плагиат
        public int Bonus3 { get; set; }  // за опечатку
        public int Penalty { get; set; }

        // Конструктор по умолчанию с начальными значениями
        public GameSettings()
        {
            ResetToDefault();
        }

        // Метод сброса настроек к значениям по умолчанию
        public void ResetToDefault()
        {
            Difficulty = "Нормальный";
            IsEasyMode = false;
            StartBalance = 1000;
            OrderDeliveryTime = 10;
            RandomBookTime = 15;
            CustomerTime = 20;
            MaxUnhappyCustomers = 3;
            MaxQueueSize = 5;
            GameDayTime = 300;
            Bonus1 = 10;
            Bonus2 = 15;
            Bonus3 = 12;
            Penalty = 15;
        }

        // Метод установки параметров в зависимости от сложности
        public void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "«Лёгкий»":
                    IsEasyMode = true;
                    StartBalance = 1500;
                    OrderDeliveryTime = 12;
                    RandomBookTime = 18;
                    CustomerTime = 25;
                    MaxUnhappyCustomers = 5;
                    MaxQueueSize = 7;
                    GameDayTime = 200;
                    Bonus1 = 12;
                    Bonus2 = 18;
                    Bonus3 = 15;
                    Penalty = 10;
                    break;

                case "«Нормальный»":
                    ResetToDefault();
                    break;

                case "«Сложный»":
                    IsEasyMode = false;
                    StartBalance = 800;
                    OrderDeliveryTime = 8;
                    RandomBookTime = 12;
                    CustomerTime = 15;
                    MaxUnhappyCustomers = 2;
                    MaxQueueSize = 3;
                    GameDayTime = 400;
                    Bonus1 = 8;
                    Bonus2 = 12;
                    Bonus3 = 9;
                    Penalty = 20;
                    break;

                default:
                    ResetToDefault();
                    break;
            }
        }
    }
}

