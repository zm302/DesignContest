using DesignContest.Entity.Models;
using LEDLibrary;
using Srr1100U;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// SignManager.xaml 的交互逻辑
    /// </summary>
    public partial class SignManager : Window
    {

        private Dispatcher dispatcher;

        private static SrrReader reader = null;

        private LEDPlayer LedPalyer = null;

        private BLL.Staff bllStaff = new BLL.Staff();

        private BLL.StaffSign bllStaffSign = new BLL.StaffSign();

        private Thread SignThread = null;


        public SignManager()
        {
            InitializeComponent();
        }
        public void CloseWindow()
        {
            this.Close();
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddCleaningStaff toCleaningStaff = new AddCleaningStaff();
            toCleaningStaff.ShowDialog();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitDispatcher();
            InitDevices();
            //InitThread();
            //SignThread.Start();
            string message = "";
            dataSignHistory.ItemsSource = bllStaffSign.GetList(out message);

            dataVisit.ItemsSource = bllStaff.GetList(out message);


        }

        /// <summary>
        /// 初始化调度器
        /// </summary>
        private void InitDispatcher()
        {
            dispatcher = this.Dispatcher;
        }

        private void InitDevices()
        {
            reader = new SrrReader("COM4");
            reader.ConnDevice();
            LedPalyer = new LEDPlayer("COM28");
            reader.Read(new Action<string>((string data) => {


                string message = "";
                T_Staff staff = bllStaff.Get(new T_Staff { F_staffID = data }, out message);
                if (staff == null)
                {
                    dispatcher.Invoke(() => {
                        ClearViewValue();
                        txtID.Text = data;
                    });
                }
                else
                {

                    //
                    bllStaffSign.Add(new T_StaffSign
                    {
                        F_ClassRoomID = "cdb3876d-d6da-4c2d-bbea-d8150d7c3e9a",
                        F_ClassRoomName = "501-学生工作室",
                        F_SignTime = DateTime.Now,
                        F_StaffID = data,
                        F_StaffName = staff.F_staffName
                        
                    });

                    //显示到LED屏上
                    LedPalyer.DisplayText(staff.F_staffName+"签到成功！");
                    


                    dispatcher.Invoke(() => {

                        ClearViewValue();

                        txtID.Text = staff.F_staffID;
                        txtName.Text = staff.F_staffName;
                        txtIntime.Text = staff.F_startWorkTime.ToString();
                        txtSex.Text = staff.F_sex;
                        txtPhone.Text = staff.F_phone;
                        txtAge.Text = staff.F_age + "";
                        txtAddress.Text = staff.F_address;

                        dataSignHistory.ItemsSource = bllStaffSign.GetList(out message);

                    });

                    
                }

            }));
        }


        private void InitThread()
        {
            SignThread = new Thread(new ThreadStart(() => {
                InitDevices();
            }));
        }


        private void ClearViewValue()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtIntime.Text = "";
            txtSex.Text = "";
            txtPhone.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";

            //dataSignHistory.Items.Clear();
        }

    }


}
