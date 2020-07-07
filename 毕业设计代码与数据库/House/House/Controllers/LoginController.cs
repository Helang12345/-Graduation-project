using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Data.Entity;

//登录界面
namespace House.Controllers
{
    public class LoginController : Controller
    {
        LoginBLL bll = new LoginBLL();
        // GET: Login
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        public ActionResult PassWord()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Loginmethod(string SalesmanEmail, string Password,int? Role)
        {
            //点击注销按钮，清空 Session
            Session["Userds"] = null;
            Session["Salesman"] = null;
            if (Role == 1)
            {

                if (bll.Userds(SalesmanEmail, Password) != null)
                {
                    Session["Userds"] = bll.Userds(SalesmanEmail, Password);
                    return RedirectToAction("Index", "HomePage");
                }
                else
                {
                    return Content("<script>alert('账号或密码不正确');history.go(-1)</script>");
                }
            }
            else if (Role == 2)
            {
                if (bll.Salesman(SalesmanEmail, Password) != null)
                {
                    Session["Salesman"] = bll.Salesman(SalesmanEmail, Password);
                    return RedirectToAction("Index", "HomePage");
                }
                else
                {
                    return Content("<script>alert('账号或密码不正确');history.go(-1)</script>");
                }
            }
            else 
            {
                return View();
            }
        }
        /// <summary>
        /// 注销按钮
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //点击注销按钮，清空 Session
            Session["Userds"] = null;
            Session["Salesman"] = null;
            //跳转到登录界面
            return RedirectToAction("Index","HomePage");

        }
        public ActionResult Add(Userd userd) 
        {
            if (bll.AddUserd(userd))
            {
                return RedirectToAction("Index", "HomePage");
            }
            else 
            {
                return Content("<script>alert('注册失败')</script>");
            }
        }
    }
}