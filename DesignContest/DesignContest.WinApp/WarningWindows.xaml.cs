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

namespace DesignContest.WinApp
{
    /// <summary>
    /// WarningWindows.xaml 的交互逻辑
    /// </summary>
    public partial class WarningWindows : Window
    {
        public delegate void CloseWindows();
        public CloseWindows close;
        public WarningWindows()
        {
            InitializeComponent();
        }

        public WarningWindows(string message)
        {
            InitializeComponent();
            this.txtWarning.Text = message;
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            close();
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
