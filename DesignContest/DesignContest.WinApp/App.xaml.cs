
using DesignContest.Common.IPCamera;
using DesignContest.Common.Log;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesignContest.WinApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /*关于日志的初始化*/

            //初始化日志配置
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "ConfigXML/log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            //注册日志
            LogHelper.Register(GetType());


            LogHelper.log.Info("日志配置成功。");

            /*IPCameraSDK初始化*/

            IPCameraHelper.IPCaneraInitSDK();

        }

    }
}
