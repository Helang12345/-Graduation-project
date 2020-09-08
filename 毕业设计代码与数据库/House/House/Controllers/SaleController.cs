using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.IO;
using PagedList;

namespace House.Controllers
{
    public class SaleController : Controller
    {
        SaleBLL bLL = new SaleBLL();
        HouseEntities db = new HouseEntities();
        BusinessBLL bll2 = new BusinessBLL();
        // GET: Sale
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SOrder(int? page)
        {
            Salesman salesman = Session["Salesman"] as Salesman;
            if (salesman == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var a = bLL.SOrder(salesman.SalesmanID);
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 2;
                ///通过ToPagedList扩展方法进行分页  
                var usePageList = a.ToPagedList(pageNumber, pageSize);
                return View(usePageList);
            }
        }
        // GET: Sale
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult LOrder(int? page)
        {
            Salesman salesman = Session["Salesman"] as Salesman;
            if (salesman == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var a = bLL.LOrder(salesman.SalesmanID);
                int pageNumber = page ?? 1;
                //每页显示多少条
                int pageSize = 2;
                ///通过ToPagedList扩展方法进行分页  
                var usePageList = a.ToPagedList(pageNumber, pageSize);
                return View(usePageList);
            }
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Information(Salesman salesman)
        {
            salesman = Session["Salesman"] as Salesman;
            if (salesman == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MyInformation = bLL.MyInformation(salesman.SalesmanID);
                return View();
            }
        }
        /// <summary>
        /// 修改售房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSelling(int SellID)
        {
            //int SellID = 1;
            //判断销售是否登录
            Salesman salesman = Session["Salesman"] as Salesman;
            if (salesman == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //查询订单详情
                ViewBag.SSell = bLL.SSell(SellID);
                ViewBag.SSelling = bLL.SSelling(SellID);
                ViewBag.STransactions = bLL.STransactions(SellID);
                ViewBag.SSImg = bLL.SSImg(SellID);
                return View();
            }
        }
        /// <summary>
        /// 修改租房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditLease(int LeaseID)
        {
            //int LeaseID = 1;
            //判断销售是否登录
            Salesman salesman = Session["Salesman"] as Salesman;
            if (salesman == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //查询订单详情
                ViewBag.SLease = bLL.SLease(LeaseID);
                ViewBag.SFacilities = bLL.SFacilities(LeaseID);
                ViewBag.SLImg = bLL.SLImg(LeaseID);
                return View();
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
            Salesman salesman = Session["Salesman"] as Salesman;
            int id = salesman.SalesmanID;
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
        public ActionResult EditContact(Salesman salesman, string SalesmanPhone, string SalesmanEmail, string SalesmanVX)
        {
            Userd u = Session["Userds"] as Userd;
            int id = u.UserID;
            if (bLL.EditContact(id, SalesmanPhone, SalesmanEmail, SalesmanVX) > 0)
            {
                return Content("<script>alert('修改成功');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sell"></param>
        /// <param name="selling"></param>
        /// <param name="sImg"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public ActionResult EditSELL(Sell sell ,Selling selling, SImg sImg,Transactions transactions) 
        {
            int a = sell.SellID;
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
                if (bll2.AddSImg(sell.SellID, strlist))
                {
                    //保存文件
                    //应用程序需要有服务器UploadFile文件夹的读写权限
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Request.Files[i].SaveAs(Server.MapPath("~/Content/Selling/" + Request.Files[i].FileName));
                    }

                }
            }
            if (bLL.EditSELL(sell, selling, transactions))
            {
                return RedirectToAction("EditSelling", "Sale", new { SellID = a });
            }
            else 
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sell"></param>
        /// <param name="selling"></param>
        /// <param name="sImg"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditLEASE(Lease lease, string[] list)
        {
            //初始化配套设置的值
            Facilities fcs = new Facilities()
            {
                FacilitiesWashing = 0,
                Facilitiesairconditioner = 0,
                Facilitieswardrobe = 0,
                FacilitiesTV = 0,
                FacilitiesRefrigerator = 0,
                FacilitiesBed = 0,
                FacilitiesWIFI = 0,
                FacilitiesNaturalgas = 0,
                FacilitiesHeater = 0,
                FacilitiesHeating = 0,
                LeaseID=lease.LeaseID,
                FacilitiesID=lease.LeaseID

            };
            //循环判断更新值
            foreach (var item in list)
            {
                if (item == "FacilitiesWashing")
                {
                    fcs.FacilitiesWashing = 1;
                }
                if (item == "Facilitiesairconditioner")
                {
                    fcs.Facilitiesairconditioner = 1;
                }
                if (item == "Facilitieswardrobe")
                {
                    fcs.Facilitieswardrobe = 1;
                }
                if (item == "FacilitiesTV")
                {
                    fcs.FacilitiesTV = 1;
                }
                if (item == "FacilitiesRefrigerator")
                {
                    fcs.FacilitiesRefrigerator = 1;
                }
                if (item == "FacilitiesBed")
                {
                    fcs.FacilitiesBed = 1;
                }
                if (item == "FacilitiesWIFI")
                {
                    fcs.FacilitiesWIFI = 1;
                }
                if (item == "FacilitiesNaturalgas")
                {
                    fcs.FacilitiesNaturalgas = 1;
                }
                if (item == "FacilitiesHeater")
                {
                    fcs.FacilitiesHeater = 1;
                }
                if (item == "FacilitiesHeating")
                {
                    fcs.FacilitiesHeating = 1;
                }
            }
            int a = lease.LeaseID;
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
                if (bll2.AddLImg(lease.LeaseID, strlist))
                {
                    //保存文件
                    //应用程序需要有服务器UploadFile文件夹的读写权限
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Request.Files[i].SaveAs(Server.MapPath("~/Content/Selling/" + Request.Files[i].FileName));
                    }

                }
            }
            if (bLL.EditLEASE(lease, fcs))
            {
                return RedirectToAction("EditLease", "Sale", new { LeaseID = a });
            }
            else
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
        public ActionResult Updata_g_deleteimg(int ID,int SellID) 
        {
            if (bLL.Updata_g_deleteimg(ID,SellID))
            {
                return RedirectToAction("EditSelling", "Sale", new { SellID = SellID });
            }
            else
            {
                return Content("<script>alert('删除失败');history.go(-1)</script>");
            }
        }
        public ActionResult Updata_g_deleteimg2(int ID, int LeaseID)
        {
            if (bLL.Updata_g_deleteimg2(ID, LeaseID))
            {
                return RedirectToAction("EditLease", "Sale",new { LeaseID = LeaseID } );
            }
            else
            {
                return Content("<script>alert('删除失败');history.go(-1)</script>");
            }
        }
        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="userd"></param>
        /// <returns></returns>
        public ActionResult EditUserd(Salesman salesman)
        {
            int a = 0;
            Salesman  salesmans = db.Salesman.Find(salesman.SalesmanID);
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
                        salesmans.Photo = fileName;
                        db.Entry(salesmans).State = System.Data.Entity.EntityState.Modified;//修改
                        a = db.SaveChanges();
                    }
                }
                if (a > 0)
                {
                    //保存文件
                    //应用程序需要有服务器UploadFile文件夹的读写权限
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Request.Files[i].SaveAs(Server.MapPath("~/Content/Photo/" + Request.Files[i].FileName));
                    }
                    Session["Salesman"] = db.Salesman.Find(salesmans.SalesmanID);
                    return Content("<script>alert('修改成功');history.back(-1)</script>");
                }
                else
                {
                    return Content("<script>alert('上传失败');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>alert('修改失败');history.go(-1)</script>");
            }
        }
    }
}