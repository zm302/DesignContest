using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.Common.Log
{
    /// <summary>
    /// 调用这里的方法前
    /// 要先在程序开始执行时
    /// 添加下面的初始化代码，并保证配置文件存在且正确
    /// 
    /// //初始化日志配置
    /// var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "ConfigXML/log4net.config");
    /// XmlConfigurator.ConfigureAndWatch(logCfg);
    /// //注册日志     
    /// LogHelper.Register(Application.GetType()); 
    /// </summary>
    public class LogHelper
    {
        public static ILog log = null;

        public static void Register(Type type)
        {
            log = LogManager.GetLogger(type);
        }
        public void Log4NetTest()
        {
            log.Debug("log 调试信息");
            log.Info("log 消息");
            log.Warn("log 警告");
            log.Fatal("log 严重");
            log.Error("log 错误");
        }
    }
}