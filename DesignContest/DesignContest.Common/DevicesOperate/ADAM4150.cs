using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.Common.DevicesOperate
{
    public class ADAM4150
    {
        static SerialPort CurrentSerialPort = null;
        public object mOpenLock = new object();

        /// <summary>
        /// 火焰
        /// </summary>
        public bool fireValue;
        /// <summary>
        /// 烟雾
        /// </summary>
        public bool smokeValue;
        /// <summary>
        /// 人体红外
        /// </summary>
        public bool bodyInfraredValue;
        /// <summary>
        /// 红外对射
        /// </summary>
        public bool infraredValue;

        //路灯开关命令
        byte[] onStreetLamp = new byte[] { 0x01, 0x05, 0x00, 0x12, 0xFF, 0x00, 0x2C, 0x3F };
        byte[] offStreetLamp = new byte[] { 0x01, 0x05, 0x00, 0x12, 0x00, 0x00, 0x6D, 0xCF };

        //楼道灯开关命令
        byte[] onCorridorLamp = new byte[] { 0x01, 0x05, 0x00, 0x11, 0xFF, 0x00, 0xDC, 0x3F };
        byte[] offCorridorLamp = new byte[] { 0x01, 0x05, 0x00, 0x11, 0x00, 0x00, 0x9D, 0xCF };

        //火警开关命令
        byte[] onAlarmLamp = new byte[] { 0x01, 0x05, 0x00, 0x10, 0xFF, 0x00, 0x8D, 0xFF };
        byte[] offAlarmLamp = new byte[] { 0x01, 0x05, 0x00, 0x10, 0x00, 0x00, 0xCC, 0x0F };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strCom">串口</param>
        /// <param name="baudRate">波特率</param>
        public ADAM4150(string strCom = "COM1", int baudRate = 9600)
        {
            CurrentSerialPort = new SerialPort();
            CurrentSerialPort.PortName = strCom;
            CurrentSerialPort.BaudRate = baudRate;
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="strCom"></param>
        /// <param name="baudRate"></param>
        public bool Open()
        {
            try
            {
                if (!CurrentSerialPort.IsOpen)
                {
                    //打开串口
                    lock (mOpenLock)
                    {
                        if (!CurrentSerialPort.IsOpen)
                        {
                            CurrentSerialPort.Open();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            return CurrentSerialPort.IsOpen;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (CurrentSerialPort.IsOpen)
            {
                lock (mOpenLock)
                {
                    if (CurrentSerialPort.IsOpen)
                    {
                        CurrentSerialPort.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 获取设置四模拟量的值
        /// </summary>
        public void SetData()
        {
            byte[] buffer = new byte[] { 0x01, 0x01, 0x00, 0x00, 0x00, 0x07, 0x7D, 0xC8 };
            Write(buffer, 0, buffer.Length);

            byte[] data = GetByteData();//

            if (data == null)
            {
                return;
            }
            byte[] results = data;

            Array.Resize(ref data, data.Length - 2);

            byte[] checkdata = CRC16.GetCRC16(data, true);//获取高低位

            //验证
            if (checkdata[0] == results[results.Length - 2] && checkdata[1] == results[results.Length - 1])
            {
                char[] statusValue = ToBinary7(results[3]);
                statusValue = statusValue.Reverse().ToArray();
                infraredValue = statusValue[4].ToString().Equals("1");
                smokeValue = statusValue[2].ToString().Equals("1");
                fireValue = statusValue[1].ToString().Equals("1");
                //人体红外要想相反处理
                bodyInfraredValue = statusValue[0].ToString().Equals("0");
            }

        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offs"></param>
        /// <param name="count"></param>
        private void Write(byte[] buffer, int offs, int count)
        {
            try
            {
                //清除缓冲区
                CurrentSerialPort.DiscardInBuffer();
                CurrentSerialPort.Write(buffer, offs, count);
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 获取串口数据
        /// </summary>
        /// <returns></returns>
        private byte[] GetByteData()
        {
            byte[] readBuffer = null;
            try
            {
                System.Threading.Thread.Sleep(1000);
                int bufferSize = CurrentSerialPort.BytesToRead;
                if (bufferSize <= 0)
                    return null;

                readBuffer = new byte[bufferSize];
                int count = CurrentSerialPort.Read(readBuffer, 0, bufferSize);
            }
            catch (Exception e)
            { }
            //Close();
            return readBuffer;
        }

        /// <summary>
        /// 控制路灯
        /// <param name="onOfff">开关</param>
        /// </summary>
        public void ControlStreetLamp(bool onOfff)
        {
            if (onOfff)
            {
                Write(onStreetLamp, 0, onStreetLamp.Length);
            }
            else
            {
                Write(offStreetLamp, 0, onStreetLamp.Length);
            }
        }

        /// <summary>
        /// 控制楼道灯
        /// </summary>
        public void ControlCorridorLamp(bool onOfff)
        {
            if (onOfff)
            {
                Write(onCorridorLamp, 0, onCorridorLamp.Length);
            }
            else
            {
                Write(offCorridorLamp, 0, onCorridorLamp.Length);
            }
        }

        /// <summary>
        /// 控制火警
        /// </summary>
        public void ControlAlarmLamp(bool onOfff)
        {
            if (onOfff)
            {
                Write(onAlarmLamp, 0, onAlarmLamp.Length);
            }
            else
            {
                Write(offAlarmLamp, 0, onAlarmLamp.Length);
            }
        }

        private char[] ToBinary7(int value)
        {
            char[] chars = new char[7];
            value = value & 0xFF;
            for (int i = 6; i >= 0; i--)
            {
                chars[i] = (value % 2 == 1) ? '1' : '0';
                value /= 2;
            }
            return chars;
        }

    }
}
