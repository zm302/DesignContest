using DesignContest.BLL;
using DesignContest.Common.DevicesOperate;
using DesignContest.Common.IPCamera;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Windows.Input;

namespace DesignContest.WebApp.Controllers
{
    public class LaboraEnvironmentController : Controller
    {
        // GET: LaboraEnvironment
        public ActionResult Index(string options)
        {
            if (Request["classroomID"] !=null)
            {
                string classroomID = Request["classroomID"];

                string[] classroomInfo = new ClassRoom().getClassroomInfo(classroomID);
                List<DateTime> time = getTimeValue(classroomID);
                List<string> cherry = getTemperatureValue(classroomID);
                List<string> pineapple = getHumidityValue(classroomID);
                List<string> newTime = timetolist(time);
                List<int> newCherry = stringtolist(cherry);
                List<int> newPineapple = stringtolist(pineapple);
                string jsonTime = JsonSerializer(newTime);
                string jsonCherry = JsonSerializer(newCherry);
                string jsonPineapple = JsonSerializer(newPineapple);
                ViewBag.modules = classroomInfo;
                ViewData["time"] = jsonTime;
                ViewData["cherry"] = jsonCherry;
                ViewData["pineapple"] = jsonPineapple;
            }
            
            return View();
        }
        
        public ActionResult ClassroomCamera()
        {
            return View();
        }
        
        private IPCameraHelper InitIpCamera()
        {
            IPCameraHelper CameraHelper = new IPCameraHelper();
            CameraHelper.Login("172.18.120.4", 8000, "admin", "12345");
            CameraHelper.PreviewStartWeb();
            return CameraHelper;

        }
        private static Common.DevicesOperate.ADAM4150 adamDevices;
        private bool LampStatus = false;
        
        public int OnOffCorridorLamp()
        {
            if (adamDevices == null)
            {
                return 0;
            }
            LampStatus = !LampStatus;
            adamDevices.ControlStreetLamp(LampStatus);
            return 1;
        }
        private void InitDevices()
        {
           
            adamDevices = new ADAM4150("COM4");
            adamDevices.Open();
        }
        public int aaa() { return 1; }

        public List<DateTime> getTimeValue(string classroomID)
        {
            List<string[]> temperatureValue = new BLL.Environment().getValue(classroomID, "温度传感器");
            List<DateTime> lsTime = new List<DateTime>();
            foreach (string[] str in temperatureValue)
            {
                lsTime.Add(Convert.ToDateTime(str[1]));
            }
            return lsTime;
        }

        public List<string> getTemperatureValue(string classroomID)
        {
            List<string[]> temperatureValue = new BLL.Environment().getValue(classroomID, "温度传感器");
            List<string> cherry = new List<string>();
            foreach (string[] str in temperatureValue)
            {
                cherry.Add(str[0]);
            }
            return cherry;
        }
        public List<string> getHumidityValue(string classroomID)
        {
            List<string[]> humidityValue = new BLL.Environment().getValue(classroomID, "湿度传感器");
            
            List<string> pineapple = new List<string>();
            
            foreach (string[] str in humidityValue)
            {
                pineapple.Add(str[0]);
            }
            return pineapple;
        }
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public List<string> timetolist(List<DateTime> listValue)
        {
            List<string> value = new List<string>();

            foreach (DateTime time in listValue)
            {
                value.Add(time.Hour.ToString());

            }
                return value;
        }
        public List<int> stringtolist(List<string> listValue)
        {
            List<int> value = new List<int>();
            
                foreach (string v in listValue)
                {
                double test = Convert.ToDouble(v);

                value.Add(Convert.ToInt32(test));

            }
           
            return value;
        }
    }
}