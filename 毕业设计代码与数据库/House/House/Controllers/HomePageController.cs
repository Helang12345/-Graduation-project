using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//二代首页
namespace House.Controllers
{
    public class HomePageController : Controller
    {
        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}