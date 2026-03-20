using BookShop;
using BookLibrary; // Добавляем using для доступа к GameSettings

namespace BookStore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //var config = new ApplicationConfiguration();
            //config.InitializeOnMainThread = true;
            ApplicationConfiguration.Initialize();
            
            // Сначала показываем титульный экран
            TitleScreen titleScreen = new TitleScreen();

            if (titleScreen.ShowDialog() == DialogResult.OK)
            {
                // Если игрок выбрал сложность → запускаем основную форму
                Application.Run(new MainForm(titleScreen._gameSettings));
            }
            else
            {
                // Если игрок закрыл титульный экран:выходим
                Application.Exit();
            }
        }
    }
}
    