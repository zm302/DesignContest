using DesignContest.Common.DevicesOperate;
using DesignContest.Common.IPCamera;
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
using Visifire.Charts;

namespace DesignContest.WinApp
{
    /// <summary>
    /// LaboratoryCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class LaboratoryCtrl : Window
    {
        private IPCameraHelper IpCameraHalper1, IpCameraHalper2, IpCameraHalper3, IpCameraHalper4, IpCameraHalper5, IpCameraHalper6, IpCameraHalper7,
            IpCameraHalper8, IpCameraHalper9;

        private ADAM4150 adamDevices = null;

        private bool LampStatus = false;

        private void imgSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (adamDevices == null)
            {
                return;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlCorridorLamp(LampStatus);
            adamDevices.ControlStreetLamp(LampStatus);
        }

        public LaboratoryCtrl()
        {
            InitializeComponent();
            IPCameraHelper.IPCaneraInitSDK();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitIpCamera();
            InitDevices();

            CreateChartSpline();
            initText();
        }

        private void InitIpCamera()
        {
            IpCameraHalper1 = new IPCameraHelper();
            IpCameraHalper2 = new IPCameraHelper();
            IpCameraHalper3 = new IPCameraHelper();
            IpCameraHalper4 = new IPCameraHelper();
            IpCameraHalper5 = new IPCameraHelper();
            IpCameraHalper6 = new IPCameraHelper();
            IpCameraHalper7 = new IPCameraHelper();
            IpCameraHalper8 = new IPCameraHelper();
            IpCameraHalper9 = new IPCameraHelper();

            IpCameraHalper1.Login("172.18.120.4", 8000, "admin", "12345");
            IpCameraHalper1.PreviewStart(IpCamera1.Handle);

            IpCameraHalper2.Login("172.18.120.2", 8000, "admin", "12345");
            IpCameraHalper2.PreviewStart(IpCamera2.Handle);

            IpCameraHalper3.Login("172.18.120.3", 8000, "admin", "12345");
            IpCameraHalper3.PreviewStart(IpCamera3.Handle);

            IpCameraHalper4.Login("172.18.120.5", 8000, "admin", "12345");
            IpCameraHalper4.PreviewStart(IpCamera4.Handle);

            IpCameraHalper5.Login("172.18.120.6", 8000, "admin", "12345");
            IpCameraHalper5.PreviewStart(IpCamera5.Handle);

            IpCameraHalper6.Login("172.18.240.29", 8000, "admin", "12345");
            IpCameraHalper6.PreviewStart(IpCamera6.Handle);

            IpCameraHalper7.Login("172.18.240.32", 8000, "admin", "12345");
            IpCameraHalper7.PreviewStart(IpCamera7.Handle);

            IpCameraHalper8.Login("172.18.120.4", 8000, "admin", "12345");
            IpCameraHalper8.PreviewStart(IpCamera8.Handle);

            IpCameraHalper9.Login("172.18.120.4", 8000, "admin", "12345");
            IpCameraHalper9.PreviewStart(IpCamera9.Handle);

            IpCamera1.Click +=(sender,arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };

            IpCamera2.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };

            IpCamera3.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };

            IpCamera4.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };
            IpCamera5.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };
            IpCamera6.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };
            IpCamera7.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };
            IpCamera8.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };
            IpCamera9.Click += (sender, arg) => {
                MainMonitoring main = new MainMonitoring();
                main.Show();
            };

        }


        private void InitDevices()
        {
            string[] port = SerialPort.GetPortNames();
            if (port.Length <= 0)
            {
                return;
            }
            adamDevices = new ADAM4150(port[0]);
            adamDevices.Open();
        }

        public void CreateChartSpline(string name = null, List<DateTime> LsTime = null, List<string> cherry1 = null, List<string> pineapple1 = null)
        {
            List<DateTime> lsTime = new List<DateTime>()
            {
               new DateTime(2012,1,1),
               new DateTime(2012,2,1),
               new DateTime(2012,3,1),
               new DateTime(2012,4,1),
               new DateTime(2012,5,1),
               new DateTime(2012,6,1),
               new DateTime(2012,7,1),
               new DateTime(2012,8,1),
               new DateTime(2012,9,1),
               new DateTime(2012,10,1),
               new DateTime(2012,11,1),
               new DateTime(2012,12,1),
            };

            List<string> cherry = new List<string>() { "33", "30", "32", "28", "29", "26", "30", "34", "32", "32", "30", "28" };
            List<string> pineapple = new List<string>() { "20", "18", "15", "17", "18", "20", "18", "18", "23", "22", "20", "21" };

            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = chartGrid.Width;
            chart.Height = chartGrid.Height;
            chart.Margin = new Thickness(0, 0, 0, 0);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = false;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = "温湿度曲线图";
            title.Padding = new Thickness(0, 10, 5, 0);
            chart.Background = new SolidColorBrush(Color.FromArgb(100, 100, 100, 100));

            //向图标添加标题
            chart.Titles.Add(title);

            //X轴

            //初始化一个新的Axis
            Axis xaxis = new Axis();
            //设置Axis的属性
            //图表的X轴坐标按什么来分类，如时分秒
            xaxis.IntervalType = IntervalTypes.Months;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "MM月";
            //给图标添加Axis            
            chart.AxesX.Add(xaxis);


            //Y轴

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值为-20           
            yAxis.AxisMinimum = -20;
            //设置图标中Y轴的最大值为100
            yAxis.AxisMaximum = 100;
            //设置间隔为10
            yAxis.Interval = 10;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "℃";
            chart.AxesY.Add(yAxis);


            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();
            // 设置数据线的格式。               
            dataSeries.LegendText = "温度";

            dataSeries.RenderAs = RenderAs.Spline;//折线图

            dataSeries.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(cherry[i]);
                dataPoint.MarkerSize = 8;
                //dataPoint.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                //dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);


            // 创建一个新的数据线。               
            DataSeries dataSeriesPineapple = new DataSeries();
            // 设置数据线的格式。         
            dataSeriesPineapple.LegendText = "湿度";

            dataSeriesPineapple.RenderAs = RenderAs.Spline;//折线图

            dataSeriesPineapple.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              

            DataPoint dataPoint2;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint2 = new DataPoint();
                // 设置X轴点                    
                dataPoint2.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint2.YValue = double.Parse(pineapple[i]);
                dataPoint2.MarkerSize = 8;
                //dataPoint2.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                //dataPoint2.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeriesPineapple.DataPoints.Add(dataPoint2);
            }
            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeriesPineapple);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);

            chartGrid.Children.Add(gr);
        }

        public void initText()
        {
            txtInfoAnalyze.Text = "室内湿度过大时，会抑制人体散热，使人感到十分闷热、烦躁,建议通风、制冷。";
        }
    }
}
