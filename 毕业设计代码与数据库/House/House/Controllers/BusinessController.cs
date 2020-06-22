using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//销售后台
namespace House.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        /// <summary>
        /// 添加订单（出售）
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加订单（出租）
        /// </summary>
        /// <returns></returns>
        public ActionResult LIndex()
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
        /// 我的订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Order()
        {
            return View();
        }
        /// <summary>
        /// 我的财产
        /// </summary>
        /// <returns></returns>
        public ActionResult Property()
        {
            return View();
        }
        /// <summary>
        /// 我的关注
        /// </summary>
        /// <returns></returns>
        public ActionResult Follow()
        {
            return View();
        }
    }
}