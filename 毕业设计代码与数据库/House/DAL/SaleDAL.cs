using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SaleDAL
    {
        HouseEntities2 db = new HouseEntities2();
        /// <summary>
        /// 查询个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Salesman> MyInformation(int id)
        {
            return db.Salesman.Where(p => p.SalesmanID == id).ToList();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newpassword1">新密码</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditPassword(string newpassword1, int id)
        {
            db.Salesman.Find(id).SalesmanPassword = newpassword1;
            return db.SaveChanges();
        }
        /// <summary>
        /// 修改联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserPhone">电话</param>
        /// <param name="SalesmanEmail">邮箱</param>
        /// <param name="SalesmanVX">微信</param>
        /// <returns></returns>
        public int EditContact(int id, string UserPhone, string SalesmanEmail, string SalesmanVX)
        {
            Salesman salesman = db.Salesman.Find(id);
            salesman.SalesmanPhone = UserPhone;
            salesman.SalesmanEmail = SalesmanEmail;
            salesman.SalesmanVX = SalesmanVX;
            return db.SaveChanges();
        }
        /// <summary>
        /// 通过销售ID查询该销售的订单（售房）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Sell> SOrder(int id)
        {
            return db.Sell.Where(p => p.SalesmanID == id).ToList();
        }
        /// <summary>
        /// 通过销售ID查询该销售的订单（租房）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lease> LOrder(int id)
        {
            return db.Lease.Where(p => p.SalesmanID == id).ToList();
        }
       

        //售房修改
        /// <summary>
        /// 通过ID查询相关属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sell SSell(int id)
        {
            return db.Sell.Find(id);
        }
        /// <summary>
        /// 通过id查询卖点信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Selling SSelling(int id)
        {
            return db.Selling.Find(id);
        }
        /// <summary>
        /// 通过ID查询交易属性信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Transactions STransactions(int id) 
        {
            return db.Transactions.Find(id);
        }
        /// <summary>
        /// 通过ID查询图片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SImg> SSImg(int id)
        {
            return db.SImg.Where(p=>p.SellID==id).ToList();
        }

        //租房订单修改
        /// <summary>
        /// 通过ID查询相关属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lease SLease(int id)
        {
            return db.Lease.Find(id);
        }
        /// <summary>
        /// 通过id查询卖点信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Facilities SFacilities(int id)
        {
            return db.Facilities.Find(id);
        }
        /// <summary>
        /// 通过ID查询图片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LImg> SLImg(int id)
        {
            return db.LImg.Where(p => p.LeaseID == id).ToList();
        }
        public bool EditSELL(Sell sell, Selling selling, Transactions transactions, SImg sImg) 
        {
            db.Entry(sell).State = System.Data.Entity.EntityState.Modified;
            int a = db.SaveChanges();
            db.Entry(selling).State = System.Data.Entity.EntityState.Modified;
            int b = db.SaveChanges();
            db.Entry(sImg).State = System.Data.Entity.EntityState.Modified;
             int c = db.SaveChanges();
            db.Entry(transactions).State = System.Data.Entity.EntityState.Modified;
            int d = db.SaveChanges();
            if (d>0&&a>0&&b>0&&c>0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public bool EditLEASE(Lease lease, Facilities facilities, LImg lImg)
        {
            db.Entry(lease).State = System.Data.Entity.EntityState.Modified;
            int a = db.SaveChanges();
            db.Entry(facilities).State = System.Data.Entity.EntityState.Modified;
            int b = db.SaveChanges();
            db.Entry(lImg).State = System.Data.Entity.EntityState.Modified;
            int c = db.SaveChanges();
            if ( a > 0 && b > 0 && c > 0)
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
