using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//出租界面
namespace House.Controllers
{
    public class LeaseController : Controller
    {
        // GET: Lease
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeaseDetails() 
        {
            return View();
        }
    }
}