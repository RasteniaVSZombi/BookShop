using BookShop;

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
            Application.Run(new MainForm());
            
            // Сначала показываем титульный экран
            TitleScreen titleScreen = new TitleScreen();

             if (titleScreen.ShowDialog() == DialogResult.OK)
             {
              // Если игрок выбрал сложность → запускаем основную форму
                    MainForm mainForm = new MainForm();
                    Application.Run(mainForm);
             }
             else
             {
              // Если игрок закрыл титульный экран:выходим
              Application.Exit();
             }
            
        }
    }
}
    