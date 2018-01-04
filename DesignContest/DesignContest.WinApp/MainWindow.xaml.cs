using DesignContest.Common.SystemVar;
using DesignContest.Entity.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignContest.WinApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLogin=false;
        private CheckBox[] ckBox;
        public MainWindow()
        {
            InitializeComponent();
            //settingtUnderline(txtUName);
            //txtUName.Text = "您尚未登录！";
            //isLogin = false;
            
        }
        public MainWindow(string uName)
        {
            InitializeComponent();
            txtUName.Text = uName+",您好！";
            btnQuit.Visibility = Visibility.Visible;
            isLogin = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int count = getCount();
            List<T_ClassRoom> classroom = Load();
            test(count,classroom);
        }
        public void CloseWindow()
        {
            this.Close();
        }
        //设置TextBlock带下划线、蓝色
        private void settingtUnderline(object sender)
        {
            (sender as TextBlock).TextDecorations = TextDecorations.Underline;
            (sender as TextBlock).Foreground = new SolidColorBrush(Colors.Blue);
        }
        public List<T_ClassRoom> Load()
        {
            List<T_ClassRoom> classroom = new BLL.ClassRoom().getAllClassRoomInfo();
            
            return classroom;   
        }
        
        public int getCount()
        {
            int count = new BLL.ClassRoom().getClassRoomCount();
            return count;
        }
        /*
         * 动态显示实验室**/
        public void test(int count,List<T_ClassRoom> classroom)
        {
            gridLaboratory.Children.Clear();
            if (count == 0)
            {
                MessageBox.Show("暂时没有实验室！");
            }
            int row = -1;
            int column = -1;

            string[] classroomID = new string[count];
            string[] classsroomName = new string[count];

            int x = 0;
            foreach (T_ClassRoom classrooms in classroom)
            {
                classsroomName[x] = classrooms.F_ClassRoomName;
                classroomID[x] = classrooms.F_ClassRoomID;
                x++;
            }
            //将第一个实验室信息显示到实验室信息区域
            classroomInfo(classroomID[0]);

            Border[] border = new Border[count];
            ckBox = new CheckBox[count];
            RowDefinition rowdef;
            for (int i=0;i<3;i++)
            {
                gridLaboratory.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i=0;i<count;i++)
            {
                column++;
                if (i % 3 == 0)
                {
                    rowdef = new RowDefinition();
                    rowdef.Height = new GridLength(180, GridUnitType.Pixel);
                    gridLaboratory.RowDefinitions.Add(rowdef);
                    row++;
                    column = 0;
                }
                StackPanel stPanel = new StackPanel();
                stPanel.Orientation = Orientation.Vertical;
                StackPanel stPanel1 = new StackPanel();
                stPanel1.Orientation = Orientation.Horizontal;
                stPanel1.HorizontalAlignment = HorizontalAlignment.Stretch;
                ckBox[i] = new CheckBox();
                ckBox[i].Tag = classroomID[i];
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Resources/laboratorylog.jpg", UriKind.Relative));
                img.Tag = classroomID[i];
                img.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                Image imgTo = new Image();
                imgTo.Source = new BitmapImage(new Uri("Resources/go-next.png", UriKind.Relative));
                imgTo.Tag = classroomID[i];
                imgTo.Width = 23;
                imgTo.HorizontalAlignment = HorizontalAlignment.Right;
                imgTo.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = classsroomName[i];
                stPanel1.Children.Add(txtBlock);
                stPanel1.Children.Add(imgTo);
                stPanel.Children.Add(ckBox[i]);
                stPanel.Children.Add(img);
                stPanel.Children.Add(stPanel1);
                border[i] = new Border();
                border[i].Width = 150;
                border[i].Tag = classroomID[i];
                border[i].MouseEnter += Border_MouseEnter;
                border[i].BorderBrush = Brushes.White;
                //border[i].BorderThickness = ;
                border[i].Child = stPanel;
                gridLaboratory.Children.Add(border[i]);
                Grid.SetColumn(border[i], column);
                Grid.SetRow(border[i], row);
            }
        }
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定关闭？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }
        private void btnToSign_Click(object sender, RoutedEventArgs e)
        {
            SignManager toSign = new SignManager();
            toSign.Show();
            this.Close();
        }

        private void btnToSysDesign_Click(object sender, RoutedEventArgs e)
        {
            SystemSetting toSystem = new SystemSetting();
            toSystem.Show();
            this.Close();
        }

        private void btnInsertLaboratory_Click(object sender, RoutedEventArgs e)
        {
            AddClassroom classroom = new AddClassroom();
            classroom.ShowDialog();
        }

        private void btnSraech_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearchLabo.Text.Trim() == "")
            {
                new FailureWindows("请输入查询内容！").ShowDialog();
                loadData();
                return;
            }
            List<T_ClassRoom> classroom = new List<T_ClassRoom>();
            classroom = new BLL.ClassRoom().getPartClassRoomInfo("F_ClassRoomName", txtSearchLabo.Text);
            test(classroom.Count, classroom);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new LaboratoryEnvironment(((Image)sender).Tag.ToString()).Show();
            this.Close();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void btnToCorridorLampManager_Click(object sender, RoutedEventArgs e)
        {
            CorridorLampManager toCorridorLamp = new CorridorLampManager();
            toCorridorLamp.Show();
            this.Close();
        }

        private void txtUName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isLogin)
            {
                new Login().Show();
                this.Close();
            }
        }

        private void btnToLaboratoryCtrl_Click(object sender, RoutedEventArgs e)
        {
            new LaboratoryCtrl().Show();
            this.Close();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            string classroomID = ((Border)sender).Tag.ToString();
            classroomInfo(classroomID);
        }
        /*
         * 根据实验室编号，获取实验室信息**/
        private void classroomInfo(string classroomID)
        {
            string[] info = new BLL.ClassRoom().getClassroomInfo(classroomID);
            txtClassroomName.Text = info[0];
            cmBoxClassroomType.Text = info[1];
            txtClassFunction.Text = info[2];
            txtClassroomLocation.Text = info[3];
            txtClassDescription.Text = info[4];
            txtClassroomRemark.Text = info[5];
            txtRemark.Text = info[6];
        }

        /*
* 添加实验室**/
        private void btnAddClassroom_Click(object sender, RoutedEventArgs e)
        {
            AddClassroom addClassroom = new AddClassroom();
            addClassroom.reloadData += loadData;
            addClassroom.ShowDialog();
        }
        public void loadData()
        {
            List<T_ClassRoom> classroom = Load();
            test(classroom.Count, classroom);
        }
        /*
         * 删除实验室**/
        private void btnDeleteClassroom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < ckBox.Length; i++)
                {
                    if (ckBox[i].IsChecked == true)
                    {
                        string message = new BLL.ClassRoom().deleteClassroom(ckBox[i].Tag.ToString());
                        if (message == SystemVar.Success)
                        {
                            count++;
                        }
                    }
                }
                MessageBox.Show("共删除" + count + "间实验室！");
                loadData();
            }
            catch (Exception exc)
            {
                new FailureWindows("部分实验室删除失败！").ShowDialog();
            }
        }
        
    }
}
