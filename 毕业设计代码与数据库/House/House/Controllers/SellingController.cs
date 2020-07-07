using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;
using PagedList;
using PagedList.Mvc;

//出售
namespace House.Controllers
{
    public class SellingController : Controller
    {
        HouseEntities db = new HouseEntities();
        //SellingHousesBLL bll = new SellingHousesBLL();
        
        //出售界面
        // GET: Selling
        public ActionResult Index(int SellID)
        {
            //var SellID = 1;
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                ViewBag.a = SellingHousesBLL.SFollow(SellID, userd.UserID).Count;
            }
            ViewBag.Selling = SellingHousesBLL.OnlySelling(SellID);
            ViewBag.Only = SellingHousesBLL.Only(SellID);
            ViewBag.Tran = SellingHousesBLL.OnlyTransactions(SellID);
            ViewBag.SImg = SellingHousesBLL.OnlySImg(SellID);
            return View();

        }

        /// <summary>
        /// 首页模糊查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SellList(int? a, int? page)
        {
            if (a == 1)
            {
                //ViewBag.Sell = SellingHousesBLL.Higtlow();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Higtlow();
                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 2)
            {
                //ViewBag.Sell = SellingHousesBLL.Lowthig();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Lowthig();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 3)
            {
                //ViewBag.Sell = SellingHousesBLL.Newest();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Newest();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 4)
            {
                //ViewBag.Sell = SellingHousesBLL.Oldest();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Oldest();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else
            {
                ViewBag.Sell = SellingHousesBLL.SellsList();
                ViewBag.a = 0;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = db.Sell.OrderBy(p => p.SellID).Where(p => p.TransactionStatus == 1).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
        }
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SellAll(int? a,int? page)
        {
            if (a == 1)
            {
                //ViewBag.Sell = SellingHousesBLL.Higtlow();
                ViewBag.a = a;
              //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Higtlow();
                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 2)
            {
                //ViewBag.Sell = SellingHousesBLL.Lowthig();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Lowthig();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 3)
            {
                //ViewBag.Sell = SellingHousesBLL.Newest();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Newest();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else if (a == 4)
            {
                //ViewBag.Sell = SellingHousesBLL.Oldest();
                ViewBag.a = a;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = SellingHousesBLL.Oldest();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
            else 
            {
                ViewBag.Sell = SellingHousesBLL.SellsList();
                ViewBag.a = 0;
                //第几页  三目运算符
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 5;
                //排序
                List<Sell> kk = db.Sell.OrderBy(p => p.SellID).Where(p=>p.TransactionStatus==1).ToList();

                ///通过ToPagedList扩展方法进行分页  
                IPagedList<Sell> usePageList = kk.ToPagedList(pageNumber, pageSize);
                ViewBag.course = usePageList;
                return View(usePageList);
            }
           
        }
        /// <summary>
        /// 添加关注的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SFollow(int? id) 
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                SellingHousesBLL.AddSFollow(id ?? 0, userd.UserID);
                int sid = id ?? 0;
                return RedirectToAction("Index",new { SellID = sid });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RFollow(int? id) 
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd != null)
            {
                SellingHousesBLL.DeleSFollow(id??0, userd.UserID);
                int sid = id ?? 0;
                return RedirectToAction("Index", new { SellID=sid });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}