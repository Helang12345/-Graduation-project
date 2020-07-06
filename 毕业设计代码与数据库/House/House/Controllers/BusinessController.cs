using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.IO;

//销售后台
namespace House.Controllers
{

    public class BusinessController : Controller
    {
        BusinessBLL bLL = new BusinessBLL();
        // GET: Business
        /// <summary>
        /// 添加订单（出售）
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Userd userds = Session["Userds"] as Userd;
            if (userds == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.saman = bLL.SelectMan();
                return View();
            }
        }
        /// <summary>
        /// 添加订单（出租）
        /// </summary>
        /// <returns></returns>
        public ActionResult LIndex()
        {
            Userd userds = Session["Userds"] as Userd;
            if (userds == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.saman = bLL.SelectMan();
                return View();
            }
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Information(Userd userd)
        {
            userd = Session["Userds"] as Userd;
            if (userd == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MyInformation = bLL.MyInformation(userd.UserID);
                return View();
            }
        }
        /// <summary>
        /// 我的财产
        /// </summary>
        /// <returns></returns>
        public ActionResult Property(Userd userd)
        {
            userd = Session["Userds"] as Userd;
            if (userd == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MySell = bLL.MySell(userd.UserID);
                return View();
            }
        }
        /// <summary>
        /// 我的关注
        /// </summary>
        /// <returns></returns>
        public ActionResult Follow(int? id)
        {
            Userd userd = Session["Userds"] as Userd;
            if (userd == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Follow = bLL.Follow(userd.UserID);
                return View();
            }
        }
        /// <summary>
        /// 新增售房
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSell(Sell sell, Selling selling, Transactions transactions)
        {
            int id = 0;
            int a = bLL.SellsAdd(sell);
            //拿到  id
            if (a == 1)
            {
                id = bLL.Last()[0].SellID;
            }
            else
            {
                return Content("<script>alert('添加失败');history.go(-1)</script>");
            }

            int b = bLL.SellingAdd(selling, id);
            int c = bLL.TransactionsAdd(transactions, id);
            //添加商品图片
            if (Request.Files.Count > 0)
            {
                string[] fileTypeStr = { "image/gif", "image/png", "image/jpeg", "image/jpg", "image/bmp" };
                List<string> strlist = new List<string>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (fileTypeStr.Contains(Request.Files[i].ContentType))
                    {
                        string fileName = Path.GetFileName(Request.Files[i].FileName);
                        strlist.Add(fileName);
                    }
                }
                if (bLL.AddSImg(id, strlist))
                {
                    //保存文件
                    //应用程序需要有服务器UploadFile文件夹的读写权限
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Request.Files[i].SaveAs(Server.MapPath("~/Content/Selling/" + Request.Files[i].FileName));
                    }

                }
            }
                if (b == 1 && c == 1)
            {
                return Content("<script>alert('添加成功');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');history.go(-1)</script>");
            }

        }
        public ActionResult AddLease(Lease lease, Facilities facilities)
        {
            
            int id = 0;
            int a = bLL.LeaseAdd(lease);
            if (a == 1)
            {
                id = bLL.Last2()[0].LeaseID;
                Session["int"] = id;
            }
            else
            {
                return Content("<script>alert('添加失败');history.go(-1)</script>");
            }
            //添加商品图片
            if (Request.Files.Count > 0)
            {
                string[] fileTypeStr = { "image/gif", "image/png", "image/jpeg", "image/jpg", "image/bmp" };
                List<string> strlist = new List<string>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (fileTypeStr.Contains(Request.Files[i].ContentType))
                    {
                        string fileName = Path.GetFileName(Request.Files[i].FileName);
                        strlist.Add(fileName);
                    }
                }
                if (bLL.AddLImg(id, strlist))
                {
                    //保存文件
                    //应用程序需要有服务器UploadFile文件夹的读写权限
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Request.Files[i].SaveAs(Server.MapPath("~/Content/Selling/" + Request.Files[i].FileName));
                    }

                }
            }
            //添加配套设施
            int b = bLL.FacilitiesAdd(facilities, id);
            if (b == 1)
            {
                return Content("<script>alert('添加成功');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');history.go(-1)</script>");
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newpassword1"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public ActionResult EditPassword(string newpassword1, string UserPassword)
        {
            Userd userd = Session["Userds"] as Userd;
            int id = userd.UserID;
            int a = bLL.EditPassword(newpassword1, id, UserPassword);
            if (a == 1)
            {
                return Content("<script>alert('修改成功');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
        /// <summary>
        /// 修改联系方式
        /// </summary>
        /// <param name="userd"></param>
        /// <param name="UserPhone"></param>
        /// <param name="SalesmanEmail"></param>
        /// <param name="SalesmanVX"></param>
        /// <returns></returns>
        public ActionResult EditContact(Userd userd, string UserPhone, string SalesmanEmail, string SalesmanVX)
        {
            Userd u = Session["Userds"] as Userd;
            int id = u.UserID;
            if (bLL.EditContact(id, UserPhone, SalesmanEmail, SalesmanVX) > 0)
            {
                return Content("<script>alert('修改成功');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
    }
}