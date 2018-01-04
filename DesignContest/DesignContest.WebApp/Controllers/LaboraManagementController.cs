using DesignContest.BLL;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignContest.WebApp.Controllers
{
    public class LaboraManagementController : Controller
    {
        // GET: LaboraManagement

        BLL.ClassRoom BLLclassroom = new BLL.ClassRoom();
        public ActionResult Index()
        {
            List<T_ClassRoom> list = BLLclassroom.getAllClassRoomInfo();
            List<string[]> classroominfo = new List<string[]>();
            foreach (T_ClassRoom classroom in list)
            {
                string classroomID = classroom.F_ClassRoomID;
                classroominfo.Add(new ClassRoom().getClassroomInfo(classroomID));
            }
            ViewData["classroomInfo"] = classroominfo;
            return View();
        }
    }
}