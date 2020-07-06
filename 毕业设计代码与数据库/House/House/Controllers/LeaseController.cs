using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using PagedList;
using PagedList.Mvc;


//出租界面
namespace House.Controllers
{
    public class LeaseController : Controller
    {
        static HouseEntities2 db = new HouseEntities2();
        // GET: Lease
        public ActionResult Index(int LeaseID)
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                ViewBag.a = LeaseHousesBLL.SFollow(LeaseID, userd.UserID).Count;
            }
            ViewBag.Facilities = LeaseHousesBLL.OnlyFacilities(LeaseID);
            ViewBag.Only = LeaseHousesBLL.Only(LeaseID);
            ViewBag.LImg = LeaseHousesBLL.OnlyLImg(LeaseID);
            return View();
        }
        public ActionResult LeaseDetails() 
        {
            return View();
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public ActionResult LeaseAll(int? a,int? page)
        {
            if (a == 1)
            {
                ViewBag.lease = LeaseHousesBLL.Higtlow();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 2)
            {
                ViewBag.lease = LeaseHousesBLL.Lowthig();
                ViewBag.a = a; //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 3)
            {
                ViewBag.lease = LeaseHousesBLL.Newest();
                ViewBag.a = a; //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 4)
            {
                ViewBag.lease = LeaseHousesBLL.Oldest();
                ViewBag.a = a; //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else
            {
                ViewBag.lease = LeaseHousesBLL.LeaseList();
                ViewBag.a = 0; //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
        }
        public ActionResult SFollow(int? id)
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                LeaseHousesBLL.AddSFollow(id ?? 0, userd.UserID);
                int sid = id ?? 0;
                return RedirectToAction("Index", new { LeaseID = sid });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult RFollow(int? id)
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                LeaseHousesBLL.DeleSFollow(id ?? 0, userd.UserID);
                int sid = id ?? 0;
                return RedirectToAction("Index", new { LeaseID = sid });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}