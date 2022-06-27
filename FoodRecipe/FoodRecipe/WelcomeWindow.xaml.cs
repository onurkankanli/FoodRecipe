using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoodRecipe
{
    /*
    Name: Onurkan Kanli
    Student Number: 492421

    References:
    https://www.codegrepper.com/code-examples/csharp/wpf+combobox+filter+as+you+type
    https://stackoverflow.com/questions/10679214/how-do-you-set-the-content-type-header-for-an-httpclient-request
    https://docs.microsoft.com/en-us/dotnet/desktop/wpf/controls/listview-overview?view=netframeworkdesktop-4.8
    */

    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            this.Close();
        }
    }
}
