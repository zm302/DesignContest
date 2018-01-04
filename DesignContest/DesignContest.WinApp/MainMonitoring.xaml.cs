using DesignContest.Common.IPCamera;
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
    /// MainMonitoring.xaml 的交互逻辑
    /// </summary>
    public partial class MainMonitoring : Window
    {

        IPCameraHelper IpCameraHelper = new IPCameraHelper();
        public MainMonitoring()
        {
            InitializeComponent();
            IPCameraHelper.IPCaneraInitSDK();
        }
        public void CloseWindow()
        {
            this.Close();
        }
        private void imgBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //new LaboratoryCtrl().ShowDialog();
            this.Close();
        }
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定退出系统？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitIpCamera();
        }


        private void InitIpCamera()
        {
            IpCameraHelper.Login("172.18.120.2",8000,"admin","12345");
            IpCameraHelper.PreviewStart(picturebox_IpCamera.Handle);
        }
    }
}
