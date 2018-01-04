using DesignContest.BLL;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignContest.WebApp.Controllers
{
    public class SignManagementController : Controller
    {
        BLL.Staff BLLclassroom = new BLL.Staff();
        // GET: SignManagement
        public ActionResult Index()
        {
            List<T_Staff> list = BLLclassroom.getAllStaffInfo();
            List<string[]> staffinfo = new List<string[]>();
            foreach (T_Staff classroom in list)
            {
                string staffID = classroom.F_staffID;
                staffinfo.Add(new Staff().getStaffInfo(staffID));
            }
            ViewData["staffInfo"] = staffinfo;
            return View();
        }
        public ActionResult addStaff()
        {
            //"staffID").value;
            //@info[1] = document.getElementById("staffName").value;
            //@info[2] = document.getElementById("sex").value;
            //@info[3] = document.getElementById("staffAge").value;
            //@info[4] = document.getElementById("phone").value;
            //@info[5] = document.getElementById("address"
            string[] info = new string[6];
            info[0] = Request["staffID"];
            info[1] = Request["staffName"];
            info[2] = Request["sex"];
            info[3] = Request["staffAge"];
            info[4] = Request["phone"];
            info[5] = Request["address"];
            if (info != null && info[0]!="" && info[1]!="")
            {
               new Staff().addStaff(info);
            }
            return View();
        }

    }
}