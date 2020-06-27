using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

//二代首页
namespace House.Controllers
{
    public class HomePageController : Controller
    {
        HomePageBLL bll= new HomePageBLL();
        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        // GET: HomePage
        public ActionResult Index()
        {
            ViewBag.Salesman = bll.SalesmenSelect();
            ViewBag.Sells = bll.SellsSelect();
            ViewBag.Lease = bll.LeaseSelect();
            return View() ;
        }
    }
}