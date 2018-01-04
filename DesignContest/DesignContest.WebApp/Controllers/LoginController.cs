using DesignContest.Common.Encrypt;
using DesignContest.Common.SystemVar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignContest.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            string a = Request["username"];
            if (Request["username"] == null || Request["password"] == null)
            {
                return View();
            }
            else
            {
                string uName = Request["username"];
                string pwd = Request["password"];
                int value = ExistUser(uName, pwd);
                if (value == 1)
                {
                    Session["username"] = uName;
                    Response.Redirect("~/LaboraManagement/Index");
                }
                if(value == -1)
                {
                    //return JavaScript("\"Message\":\"NoData\"");
                    ViewData["message"] = "登录异常！";
                }
                if (value == 0)
                {
                    //return JavaScript("\"Message\":\"NoData\"");
                    ViewData["message"] = "用户名或密码有误！";
                }
            }
            return View();
        }

        public int ExistUser(string username,string password)
        {
            int value = 0;
            string pwd = MD5Encrypt.MD5Encrypt32(password);
            //从配置文件读取接口
            string manager = new BLL.User().Login(username, pwd);
            if (manager.Equals(SystemVar.Success))
            {
                value = 1;
            }
            else
            {
                if (manager.Equals(SystemVar.Exception))
                {
                    value = -1;
                }
                else
                {
                    value = 0;
                }
            }
            return value;
        }
    }
}