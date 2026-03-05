using BookShop;

namespace BookStore.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var config = new ApplicationConfiguration();
            config.InitializeOnMainThread = true;
            ApplicationConfiguration.Initialize(config);
            Application.Run(new MainForm());
        }
    }
}