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
using System.Configuration;
using System.IO.Ports;

namespace DesignContest.WinApp
{
    /// <summary>
    /// SystemSetting.xaml 的交互逻辑
    /// </summary>
    public partial class SystemSetting : Window
    {
        public SystemSetting()
        {
            InitializeComponent();
        }
        public void CloseWindow()
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitComboxData();
        }
        private void imgBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定退出系统？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }


        private void InitComboxData()
        {

            List<ComboBox> list_br = new List<ComboBox>();
            list_br.Add(comboBox_ADAM_BR);
            list_br.Add(comboBox_FourAnalog_BR);
            list_br.Add(comboBox_RFID_BR);
            list_br.Add(comboBox_ZigBee_BR);

            int[] brs = { 300,600,1200,2400,4800,9600,19200,38400,43000,56000,57600,115200 };

            foreach (var coms_br in list_br)
            {
                foreach (var br in brs)
                {
                    coms_br.Items.Add(br);
                }
            }

            comboBox_ADAM_BR.SelectedItem = GetAppConfig("ADAM_BR");
            comboBox_FourAnalog_BR.SelectedItem = GetAppConfig("FourAnalog_BR");
            comboBox_RFID_BR.SelectedItem = GetAppConfig("RFID_BR");
            comboBox_ZigBee_BR.SelectedItem = GetAppConfig("ZigBee_BR");

            comboBox_ADAM_SPName.Items.Add(GetAppConfig("ADAM_SPName"));
            comboBox_FourAnalog_SPName.Items.Add(GetAppConfig("FourAnalog_SPName"));           
            comboBox_RFID_SPName.Items.Add(GetAppConfig("RFID_SPName"));          
            comboBox_ZigBee_SPName.Items.Add(GetAppConfig("ZigBee_SPName"));

            string[] coms = SerialPort.GetPortNames();
            List<ComboBox> list_coms = new List<ComboBox>();
            list_coms.Add(comboBox_ADAM_SPName);
            list_coms.Add(comboBox_FourAnalog_SPName);
            list_coms.Add(comboBox_RFID_SPName);
            list_coms.Add(comboBox_ZigBee_SPName);
            foreach (var combox in list_coms)
            {
                foreach (var com in coms)
                {
                    combox.Items.Add(com);
                }
                combox.SelectedIndex = 0;
            }
        }
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string s = AccessAppSetting("qq", comboBox_ADAM_SPName.SelectedValue.ToString());
            MessageBox.Show(s);
            string filepath = ConfigurationManager.AppSettings["qq"];
            MessageBox.Show(filepath);
        }
        
        private string AccessAppSetting(string strKey, string strValue)
        {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    config.AppSettings.Settings[strKey].Value = strValue;
                    return "0";
                }
            }
            config.AppSettings.Settings.Add(strKey, strValue);
            //保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");
            return strKey;
        }
    }
        
}
