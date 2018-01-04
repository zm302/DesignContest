using DesignContest.Entity.Models;
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
    /// AddCleaningStaff.xaml 的交互逻辑
    /// </summary>
    public partial class AddCleaningStaff : Window
    {

        private Dispatcher dispatcher;

        private SrrReader reader = null;

        private Thread SignThread = null;

        public AddCleaningStaff()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if(reader!=null)
            {
                reader.CloseDevice();
            }
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSID.Text.Trim() == "")
            {
                new FailureWindows("请输入员工编号！").ShowDialog();
                return;
            }
            if (txtSName.Text.Trim() == "")
            {
                new FailureWindows("请输入员工姓名！").ShowDialog();
                return;
            }
            int age = 0;
            if (txtAge.Text.Trim() == "")
            {
                age = 0;
            }
            else
            {
                age = Convert.ToInt32(txtAge.Text);
            }
            string retStr = new BLL.Staff().Add(new T_Staff
            {
                F_staffID = txtSID.Text,
                F_staffName = txtSName.Text,
                F_sex = txtGender.Text,
                F_age = age
            });
            if(retStr.Equals(Common.SystemVar.SystemVar.Success))
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                new WarningWindows("添加失败").Show();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
            {
                reader.CloseDevice();
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //InitDispatcher();
            //InitDevices();
             
        }

        private void InitDevices()
        {
            reader = new SrrReader("COM8");
            reader.ConnDevice();
            reader.Read(new Action<string>((string data) => {
                dispatcher.Invoke(() =>
                {
                    txtSID.Text = data;
                });
            }));
        }


        private void InitDispatcher()
        {
            dispatcher = this.Dispatcher;
        }


        private void InitThread()
        {
            SignThread = new Thread(new ThreadStart(() => {
                InitDevices();
            }));
        }
    }
}
