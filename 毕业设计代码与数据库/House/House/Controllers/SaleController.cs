using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace House.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SOrder()
        {
            return View();
        }
        // GET: Sale
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult LOrder()
        {
            return View();
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Information()
        {
            return View();
        }
        /// <summary>
        /// 修改售房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSelling()
        {
            return View();
        }
        /// <summary>
        /// 修改租房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditLease()
        {
            return View();
        }
    }
}