using DesignContest.BLL;
using DesignContest.Common.Encrypt;
using DesignContest.Common.SystemVar;
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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Close();
        }
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定关闭？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }

        //取消（即关闭窗口）
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定取消？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }

        //登陆
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                new FailureWindows("请输入用户名!").ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(txtUserPW.Password))
            {
                new FailureWindows("请输入密码!").ShowDialog();
                return;
            }
            string pwd = MD5Encrypt.MD5Encrypt32(txtUserPW.Password);
            //从配置文件读取接口
            string manager = new BLL.User().Login(txtUserName.Text, pwd);
            if (manager.Equals(SystemVar.Success))
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                if (manager.Equals(SystemVar.Exception))
                {
                    new FailureWindows("登录异常!").ShowDialog();
                }
                else
                {
                    new FailureWindows("用户名或密码有误！").ShowDialog();
                }
            }
        }
    }
}
