using DesignContest.Common.DevicesOperate;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Windows.Threading;

namespace DesignContest.WinApp
{
    /// <summary>
    /// CorridorLampManager.xaml 的交互逻辑
    /// </summary>
    public partial class CorridorLampManager : Window
    {
        private DispatcherTimer time = new DispatcherTimer();

        private bool LampStatus = false;

        private ADAM4150 adamDevices = null;
        public CorridorLampManager()
        {
            InitializeComponent();
            initalReloadTime();
            //time.Start();
        }
        public void initalReloadTime()
        {
            time.Interval = TimeSpan.FromMilliseconds(1000);
            time.Tick += new EventHandler(test);
        }
        public void test(object obj,System.EventArgs e)
        {
            //txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        public void CloseWindow()
        {
            this.Close();
        }
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定退出系统？");
            windows.close += CloseWindow;
            windows.Show();
        }

        private void imgBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string tagRadio = ((RadioButton)sender).Name;
            switch (tagRadio)
            {
                case "radioBtnManual":
                    boxManual.IsEnabled = true;
                    boxBody.IsEnabled = false;
                    boxTime.IsEnabled = false;
                    break;
                case "radioBtnBody":
                    boxManual.IsEnabled = false;
                    boxBody.IsEnabled = true;
                    boxTime.IsEnabled = false;
                    break;
                case "radioBtnTime":
                    boxManual.IsEnabled = false;
                    boxBody.IsEnabled = false;
                    boxTime.IsEnabled = true;
                    break;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (adamDevices == null)
            {
                return;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlStreetLamp(LampStatus);
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (adamDevices == null)
            {
                return;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlStreetLamp(LampStatus);
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (adamDevices == null)
            {
                return;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlStreetLamp(LampStatus);
        }

        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            if (adamDevices == null)
            {
                return;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlStreetLamp(LampStatus);
        }

        /// <summary>
        /// 初始化设备
        /// </summary>
        private void InitDevices()
        {
            //string[] port = SerialPort.GetPortNames();
            //if (port.Length <= 0)
            //{
            //    return;
            //}
            adamDevices = new ADAM4150("COM4");
            adamDevices.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitDevices();
        }
    }
}
