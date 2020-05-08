using Modelisateur.Connectors.Snowflake;
using Modelisateur.Modules.DbExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modelisateur.Modules.DbExplorer.Views
{
    /// <summary>
    /// Interaction logic for DbConnectionView.xaml
    /// </summary>
    public partial class DbConnectionView : Window
    {
        public DbConnectionView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((DbConnectionViewModel)DataContext).OpenConnection(new ObjectExplorer(account.Text, user.Text, password.SecurePassword, host.Text));
        }
    }
}
