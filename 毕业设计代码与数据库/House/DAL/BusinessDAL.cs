using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.Entity;

namespace DAL
{
    public class BusinessDAL
    {
        HouseEntities db = new HouseEntities();
        /// <summary>
        /// 添加售房表
        /// </summary>
        /// <param name="sell"></param>
        /// <returns></returns>
        public int SellsAdd(Sell sell)
        {
            int a = 0;
            if (db.Sell.Where(p => p.SellAddress == sell.SellAddress && p.SellVillage == sell.SellVillage && p.SellFloor == sell.SellFloor && p.UserID == sell.UserID&&p.TransactionStatus!=2).Count() == 0)
            {
                db.Sell.Add(sell);
                a = db.SaveChanges();
                return a;
            }
            else 
            {
                return a;
            }
        }
        /// <summary>
        /// 添加卖点表
        /// </summary>
        /// <param name="selling"></param>
        /// <returns></returns>
        public int SellingAdd(Selling selling)
        {
            
            db.Selling.Add(selling);
            int a = db.SaveChanges();
            return a;
        }
        /// <summary>
        /// 添加交易属性表
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public int TransactionsAdd(Transactions transactions)
        {
            db.Transactions.Add(transactions);
            int a = db.SaveChanges();
            return a;
        }
        /// <summary>
        /// 获取最新添加的信息id
        /// </summary>
        /// <returns></returns>
        public List<Sell> Last() 
        {
            return db.Sell.OrderByDescending(p => p.SellID).Where(p=>p.UState == 0).Take(1).ToList();
        }
        /// <summary>
        /// 添加租房信息
        /// </summary>
        /// <param name="lease"></param>
        /// <returns></returns>
        public int LeaseAdd( Lease lease) 
        {
            int a = 0;
            if (db.Lease.Where(p => p.LeaseAddress == lease.LeaseAddress && p.LeaseVillage == lease.LeaseVillage && p.LeaseFloor == lease.LeaseFloor && p.UserID == lease.UserID && p.TransactionStatus != 2).Count() == 0)
            {
                db.Lease.Add(lease);
                a = db.SaveChanges();
                return a;
            }
            else 
            {
                return a;
            }
        }
        /// <summary>
        /// 添加租房的配套设施
        /// </summary>
        /// <param name="facilities"></param>
        /// <returns></returns>
        public int FacilitiesAdd(Facilities facilities) 
        {
            db.Facilities.Add(facilities);
            int a = db.SaveChanges();
            return a;
        }
        /// <summary>
        /// 返回最新添加的ID
        /// </summary>
        /// <returns></returns>
        public List<Lease> Last2() 
        {
            return db.Lease.OrderByDescending(p => p.LeaseID).Where(p => p.UState == 0).Take(1).ToList();
        }
        /// <summary>
        /// 查询我的资产
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Sell> MySell(int id)
        {
            return db.Sell.Where(p=>p.UserID==id&&p.UState==0).ToList();
        }
        /// <summary>
        /// 我的资产
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lease> MyLease(int id)
        {
            return db.Lease.Where(p => p.UserID == id&&p.UState==0).ToList();
        }
        /// <summary>
        /// 查询个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Userd> MyInformation(int id) 
        {
            return db.Userd.Where(p => p.UserID == id&&p.UState==0).ToList();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newpassword1"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditPassword(string newpassword1,int id) 
        {
            db.Userd.Find(id).UserPassword = newpassword1;
            return db.SaveChanges();
        }
        /// <summary>
        /// 联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserPhone"></param>
        /// <param name="SalesmanEmail"></param>
        /// <param name="SalesmanVX"></param>
        /// <returns></returns>
        public int EditContact(int id,string UserPhone, string SalesmanEmail,string SalesmanVX)
        {
            Userd userd = db.Userd.Find(id);
            userd.UserPhone = UserPhone;
            userd.UserdEmail = SalesmanEmail;
            userd.UserdVX = SalesmanVX;
            return db.SaveChanges();
        }
        /// <summary>
        /// 查询联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SCollection> Follow(int id) 
        {
            return db.SCollection.Where(p=>p.UserID==id).ToList();
        }
        public List<Salesman> SelectMan() 
        {
            return db.Salesman.ToList();
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strlist"></param>
        /// <returns></returns>
        public bool AddPhono(int id, List<string> strlist)
        {
            foreach (var item in strlist)
            {
                db.Userd.Add(new Userd { UserID = id, Photo = item });
            }
            int a = db.SaveChanges();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strlist"></param>
        /// <returns></returns>
        public bool AddSImg(int id, List<string> strlist)
        {
            foreach (var item in strlist)
            {
                db.SImg.Add(new SImg {SellID=id,Photo=item });
            }
            int a= db.SaveChanges();
            if (a > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strlist"></param>
        /// <returns></returns>
        public bool AddLImg(int id, List<string> strlist)
        {
            foreach (var item in strlist)
            {
                db.LImg.Add(new LImg { LeaseID = id, Photo = item });
            }
            int a = db.SaveChanges();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
