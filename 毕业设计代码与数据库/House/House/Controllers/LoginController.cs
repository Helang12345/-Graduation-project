using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//登录界面
namespace House.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        public ActionResult PassWord()
        {
            return View();
        }
    }
}