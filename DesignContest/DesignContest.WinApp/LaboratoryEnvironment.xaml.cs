using DesignContest.Common.IPCamera;
using DesignContest.Entity.Models;
using DigitalLibrary;
using SpeechLib;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using ZigBeeLibrary;
using Visifire.Charts;
using System.IO.Ports;
using LEDLibrary;

namespace DesignContest.WinApp
{
    /// <summary>
    /// LaboratoryEnvironment.xaml 的交互逻辑
    /// </summary>
    public partial class LaboratoryEnvironment : Window
    {
        //private PerformanceCounter pcEnvironment = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        private string classroomID = null;

        private static bool IsWarnning = false;


        //调度
        private Dispatcher dispatcher;

        //声明委托
        private delegate void UpdateUIHandler(int index, string text);
        private static UpdateUIHandler UpdateUI;

        //声明线程
        private Thread GetZigBeeData, GetAdam4150Data;


        //四模拟量
        private static ZigBee zigBeeDeivce;


        //ADAM4150
        private static Common.DevicesOperate.ADAM4150 adamDevices;

        //LED
        private LEDPlayer ledPlayer;


        //系统声音
        private static SpVoice Voice = new SpVoice();


        private IPCameraHelper CameraHelper = new IPCameraHelper();
        public LaboratoryEnvironment()
        {
            InitializeComponent();
        }
        public LaboratoryEnvironment(string classroomID)
        {
            InitializeComponent();
            this.classroomID = classroomID;
            string[] info = new BLL.ClassRoom().getClassroomInfo(classroomID);
            txtClassroomName.Text = info[0];
            cmBoxClassroomType.Text = info[1];
            txtClassFunction.Text = info[2];
            txtClassroomLocation.Text = info[3];
            txtClassDescription.Text = info[4];
            txtClassroomRemark.Text = info[5];
            txtRemark.Text = info[6];
        }
        public void CloseWindow()
        {
            this.Close();
            DevicesDispose();
        }
        
        private void btnRoomSwitch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            WarningWindows windows = new WarningWindows("确定退出系统？");
            windows.close += CloseWindow;
            windows.ShowDialog();
        }

        private void imgBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitIpCamera();

            dispatcher = this.Dispatcher;

            InitDelegate();
            InitDevices();
            InitThread();

            GetZigBeeData.Start();
            GetAdam4150Data.Start();
            CreateChartSpline();
        }


        private void InitIpCamera()
        {
            CameraHelper.Login("172.18.120.4", 8000, "admin", "12345");
            CameraHelper.PreviewStart(Picture_monitor.Handle);
            
        }

        public void CreateChartSpline(string name = null, List<DateTime> LsTime = null, List<string> cherry1 = null, List<string> pineapple1 = null)
        {
            List<string[]> temperatureValue = new BLL.Environment().getValue(classroomID, "温度传感器");
            List<string[]> humidityValue = new BLL.Environment().getValue(classroomID, "湿度传感器");
            List<DateTime> lsTime = new List<DateTime>();
            List<string> cherry = new List<string>();
            List<string> pineapple = new List<string>();
            foreach (string[] str in temperatureValue)
            {
                lsTime.Add(Convert.ToDateTime(str[1]));
                cherry.Add(str[0]);
            }
            foreach (string[] str in humidityValue)
            {
                pineapple.Add(str[0]);
            }
            

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
            xaxis.IntervalType = IntervalTypes.Hours;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "HH:00";
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
            for (int i = 0; i < cherry.Count; i++)
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
            for (int i = 0; i < pineapple.Count; i++)
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

        /// <summary>
        /// 初始化线程
        /// </summary>
        private void InitThread()
        {
            //GetZigBeeData,GetAdam4150Data,SocketThread,MattThread;

            //初始化GetZigBeeData线程
            GetZigBeeData = new Thread(new ThreadStart(() => {

                while (true)
                {
                    zigBeeDeivce.GetSet();
                    dispatcher.Invoke(UpdateUI, 1, zigBeeDeivce.temperatureValue+"℃");
                    dispatcher.Invoke(UpdateUI, 2, zigBeeDeivce.humidityValue+"%RH");
                    dispatcher.Invoke(UpdateUI, 3, zigBeeDeivce.lightValue);
                    Thread.Sleep(1000);
                }
            }));


            //初始化GetAdam4150Data线程
            GetAdam4150Data = new Thread(new ThreadStart(() => {
                while (true)
                {
                    if (adamDevices == null)
                    {
                        return;
                    }
                    adamDevices.SetData();
                    dispatcher.Invoke(UpdateUI, 4, adamDevices.smokeValue? "有" : "无");

                    dispatcher.Invoke(UpdateUI, 5, adamDevices.fireValue ? "有" : "无");

                    dispatcher.Invoke(UpdateUI, 6, adamDevices.infraredValue ? "无" : "有");

                    if (!adamDevices.infraredValue)
                    {
                        //dispatcher.Invoke(UpdateUI, 7, "有入侵，请及时处理");
                    }
                    if (adamDevices.fireValue)
                    {
                        dispatcher.Invoke(UpdateUI, 7, "有火情，请及时处理");
                        Speak("有火情，请及时处理");
                        if(!IsWarnning)
                        {
                            ledPlayer.DisplayText("实验室501发生火情，请及时处理");
                            IsWarnning = true;
                        }
                    }
                    if (adamDevices.smokeValue)
                    {
                        dispatcher.Invoke(UpdateUI, 7, "有火情，请及时处理");
                        Speak("有火情，请及时处理");
                        if (!IsWarnning)
                        {
                            ledPlayer.DisplayText("实验室501发生火情，请及时处理");
                            IsWarnning = true;
                        }
                    }
                    if(adamDevices.fireValue==false & adamDevices.smokeValue==false)
                    {
                        if(IsWarnning)
                        {
                            IsWarnning = false;
                        }
                    }

                    Thread.Sleep(1000);
                }
            }));
        }

        /// <summary>
        /// 初始化委托
        /// </summary>
        private void InitDelegate()
        {
            UpdateUI += (int index, string text) => {
                switch (index)
                {
                    //温度
                    case 1:
                        txtTemperature.Text = text;
                        break;
                    //湿度
                    case 2:
                        txtHumidity.Text = text;
                        break;
                    //光照
                    case 3:
                        //lab_light.Content = text;
                        break;
                    //烟雾
                    case 4:
                        lblSmoke.Text = text;
                        break;
                    //火焰
                    case 5:
                        lblFire.Text = text;
                        break;
                    //人体
                    case 6:
                        //lab_person.Content = text;
                        break;
                    default:
                        break;
                }
            };



        }



        /// <summary>
        /// 初始化设备
        /// </summary>
        private void InitDevices()
        {
            zigBeeDeivce = new ZigBee(new ZigBeeLibrary.ComSettingModel { ZigbeeCom = "COM29" });
            zigBeeDeivce.InitSerialPort();
            zigBeeDeivce.Open();


            //adamDevices = new ADAM4150(new DigitalLibrary.ComSettingModel { DigitalQuantityCom = "COM19" });
            //adamDevices.InitSerialPort();
            //adamDevices.Open();
            //try
            //{
            //    string[] port = SerialPort.GetPortNames();
            //    if (port.Length <= 0)
            //    {
            //        return;
            //    }
                adamDevices = new Common.DevicesOperate.ADAM4150("COM4");
                adamDevices.Open();
            //}
            //catch (Exception e)
            //{
            //    return;
            //}

            ledPlayer = new LEDPlayer("COM28");

            //ledPlayer.InitSerialPort();
            ledPlayer.Open();


        }

        /// <summary>
        /// 释放设备资源
        /// </summary>
        private void DevicesDispose()
        {
            zigBeeDeivce.Close();
            if (adamDevices != null)
            {
                adamDevices.Close();
            }
            GetAdam4150Data.Abort();
            GetZigBeeData.Abort();
            GetAdam4150Data = null;
            GetZigBeeData = null;
        }



        /// <summary>
        /// 播放语音
        /// </summary>
        /// <param name="text"></param>

        private void Speak(string text)
        {
            Voice.Speak(text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }
        private bool indoorLampStatus = false;

        private void imgSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OnOffCorridorLamp();
        }
        private void OnOffCorridorLamp()
        {
            indoorLampStatus = !indoorLampStatus;
            
            OnOffCorridorLamp(indoorLampStatus, true);
        }
        private void OnOffCorridorLamp(bool onOff, bool infrared)
        {
            if (adamDevices == null)
            {
                return;
            }
            adamDevices.ControlCorridorLamp(onOff);
            SetImageLamp(imgRoomLamp0, indoorLampStatus);
            SetImageLamp(imgRoomLamp1, indoorLampStatus);
            SetImageLamp(imgRoomLamp2, indoorLampStatus);
            SetImageLamp(imgRoomLamp3, indoorLampStatus);
            SetImageLamp(imgRoomLamp4, indoorLampStatus);
            setImageSwitch(imgSwitch, indoorLampStatus);
        }
        private void SetImageLamp(Image imgLamp, bool status)
        {
            if (status == true)
            {
                imgLamp.Source = new BitmapImage(new Uri("Resources/lamp_on.png", UriKind.Relative));
            }
            else
            {
                imgLamp.Source = new BitmapImage(new Uri("Resources/lamp_off.png", UriKind.Relative));
            }
        }
        private void setImageSwitch(Image imgLampSwitch, bool status)
        {
            if (status == true)
            {
                imgLampSwitch.Source = new BitmapImage(new Uri("Resources/lampswitchOn.png", UriKind.Relative));
            }
            else
            {
                imgLampSwitch.Source = new BitmapImage(new Uri("Resources/lampswitchOff.png", UriKind.Relative));
            }
        }
        
    }
}
