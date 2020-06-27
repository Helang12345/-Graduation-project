using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using DAL;

//出售
namespace House.Controllers
{
    public class SellingController : Controller
    {
        //SellingHousesBLL bll = new SellingHousesBLL();


        //出售界面
        // GET: Selling

        public ActionResult Index(int SellID)
        {
            ViewBag.Selling = SellingHousesBLL.OnlySelling(SellID);
            ViewBag.Only = SellingHousesBLL.Only(SellID);
            ViewBag.Tran = SellingHousesBLL.OnlyTransactions(SellID);
            ViewBag.SImg = SellingHousesBLL.OnlySImg(SellID);
            return View();

        }
        public ActionResult SellList()
        {
            ViewBag.Sell = SellingHousesBLL.SellsList();
            return View();
        }

    }
}