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
        public int SellsAdd(Sell sell)
        {
            return dal.SellsAdd(sell);
        }
        public int SellingAdd(Selling selling, int id)
        {
            selling.SellID = id;
            return dal.SellingAdd(selling);
        }
        public int TransactionsAdd(Transactions transactions, int id)
        {
            transactions.SellID = id;
            return dal.TransactionsAdd(transactions);
        }
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
        public List<Sell> MySell(int id)
        {
            return dal.MySell(id);
        }
        public List<Userd> MyInformation(int id)
        {
            return dal.MyInformation(id);
        }
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
        public int EditContact(int id, string UserPhone, string SalesmanEmail, string SalesmanVX)
        {
            return dal.EditContact(id, UserPhone, SalesmanEmail, SalesmanVX);
        }
        public List<SCollection> Follow(int id)
        {
            return dal.Follow(id);
        }
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
