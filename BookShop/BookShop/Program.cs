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
        }
    }
}