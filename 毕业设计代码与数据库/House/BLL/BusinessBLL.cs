using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class BusinessBLL
    {
        BusinessDAL dal = new BusinessDAL();
        /// <summary>
        /// 添加售房信息
        /// </summary>
        /// <param name="sell"></param>
        /// <returns></returns>
        public int SellsAdd(Sell sell)
        {
            return dal.SellsAdd(sell);
        }
        /// <summary>
        /// 添加卖点信息
        /// </summary>
        /// <param name="selling"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SellingAdd(Selling selling, int id)
        {
            selling.SellID = id;
            return dal.SellingAdd(selling);
        }
        /// <summary>
        /// 添加交易属性
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int TransactionsAdd(Transactions transactions, int id)
        {
            transactions.SellID = id;
            return dal.TransactionsAdd(transactions);
        }
        /// <summary>
        /// 获取最新添加的信息id
        /// </summary>
        /// <returns></returns>
        public List<Sell> Last()
        {
            return dal.Last();
        }
        /// <summary>
        /// 添加出租信息
        /// </summary>
        /// <param name="lease"></param>
        /// <returns></returns>
        public int LeaseAdd(Lease lease)
        {
            return dal.LeaseAdd(lease);
        }

        public int FacilitiesAdd(Facilities facilities, int id)
        {
            facilities.LeaseID = id;
            return dal.FacilitiesAdd(facilities);
        }
        /// <summary>
        /// 查询ID
        /// </summary>
        /// <returns></returns>
        public List<Lease> Last2()
        {
            return dal.Last2();
        }
        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Sell> MySell(int id)
        {
            return dal.MySell(id);
        }
        /// <summary>
        /// 关注查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lease> MyLease(int id)
        {
            return dal.MyLease(id);
        }
        /// <summary>
        /// 查询个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Userd> MyInformation(int id)
        {
            return dal.MyInformation(id);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newpassword1"></param>
        /// <param name="id"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public int EditPassword(string newpassword1, int id, string UserPassword)
        {
            var a = dal.MyInformation(id);
            int b = 0;
            if (a[0].UserPassword == UserPassword)
            {
                dal.EditPassword(newpassword1, id);
                b = 1;
                return b;
            }
            else
            {
                return b;
            }
        }
        /// <summary>
        /// 修改联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserPhone"></param>
        /// <param name="SalesmanEmail"></param>
        /// <param name="SalesmanVX"></param>
        /// <returns></returns>
        public int EditContact(int id, string UserPhone, string SalesmanEmail, string SalesmanVX)
        {
            return dal.EditContact(id, UserPhone, SalesmanEmail, SalesmanVX);
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SCollection> Follow(int id)
        {
            return dal.Follow(id);
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <returns></returns>
        public List<Salesman> SelectMan() 
        {
            return dal.SelectMan();
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sImg"></param>
        /// <returns></returns>
        public bool AddSImg(int id, List<string> strlist) 
        {
            return dal.AddSImg(id, strlist);
        }
        public bool AddPhono(int id, List<string> strlist)
        {
            return dal.AddPhono(id, strlist);
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sImg"></param>
        /// <returns></returns>
        public bool AddLImg(int id, List<string> strlist)
        {
            return dal.AddLImg(id, strlist);
        }
    }
}
