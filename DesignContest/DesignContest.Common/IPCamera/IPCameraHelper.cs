using DesignContest.Common.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.Common.IPCamera
{
    public class IPCameraHelper
    {

        //初始化
        private Int32 m_lUserID = -1;
        private Int32 m_lRealHandle = -1;
        public CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();



        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <returns></returns>
        public static bool IPCaneraInitSDK()
        {
            try
            {
                bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
                return m_bInitSDK;
            }
            catch(Exception exc)
            {
                LogHelper.log.Fatal("类：IPCameraHelper，方法：IPCaneraInitSDK出错，异常信息为：" +exc.Message);

                return false;
            }
        }


        /// <summary>
        /// 登录设备
        /// </summary>
        /// <param name="IP">IP地址</param>
        /// <param name="Port">端口</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        public bool Login(string IP, Int16 Port, string Username, string Password)
        {
            try
            {
                string DVRIPAddress = IP; //设备IP地址或者域名
                Int16 DVRPortNumber = Port;//设备服务端口号
                string DVRUserName = Username;//设备登录用户名
                string DVRPassword = Password;//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    return false;
                }
                return true;

            }
            catch(Exception exc)
            {
                return false;
            }

            

        }


        /// <summary>
        /// 开始预览
        /// </summary>
        /// <param name="handle">显示控件的委托</param>
        public void PreviewStart(IntPtr handle)
        {
            
            lpPreviewInfo.hPlayWnd = handle; ;//预览窗口
            lpPreviewInfo.lChannel = 1;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数

            IntPtr pUser = new IntPtr();//用户数据
            //打开预览 Start live view 
            m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
        }

        public void PreviewStartWeb()
        {
            lpPreviewInfo.lChannel = 1;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数

            IntPtr pUser = new IntPtr();//用户数据
            //打开预览 Start live view 
            m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
        }
        /// <summary>
        /// 实时数据回调函数
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwDataType"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="pUser"></param>
        private void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {


        }

        private void Close()
        {
            CHCNetSDK.CLIENT_SDK_StopStream(m_lRealHandle);
        }














    }
}
