using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//出售
namespace House.Controllers
{
    public class SellingController : Controller
    {
        //初代出售界面
        //// GET: Selling
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult SellList()
        {
            return View();
        }

    }
}