using ModelisateurWPF.View;
using System.Windows;

namespace ModelisateurWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindowView();
            window.Show();
        }
    }
}
