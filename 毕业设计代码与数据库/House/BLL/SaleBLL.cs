using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class SaleBLL
    {
        SaleDAL dal = new SaleDAL();
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Salesman> MyInformation(int id)
        {
            //调用DAL查询
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
            //查询原密码
            var a = dal.MyInformation(id);
            int b = 0;
            //判断原密码是否正确
            if (a[0].SalesmanPassword == UserPassword)
            {
                //正确继续执行
                dal.EditPassword(newpassword1, id);
                b = 1;
                return b;
            }
            else
            {
                //返回提示
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
            //执行DAL修改
            return dal.EditContact(id, UserPhone, SalesmanEmail, SalesmanVX);
        }
        /// <summary>
        /// 通过ID查询售房订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Sell> SOrder(int id)
        {
            return dal.SOrder(id);
        }
        /// <summary>
        /// 通过ID查询租房订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Lease> LOrder(int id)
        {
            return dal.LOrder(id);
        }
        

        //售房订单修改
        /// <summary>
        /// 通过售房ID查询相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sell SSell(int id)
        {
            return dal.SSell(id);
        }
        /// <summary>
        /// 通过售房ID查询卖点相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Selling SSelling(int id)
        {
            return dal.SSelling(id);
        }
        /// <summary>
        /// 通过售房ID查询交易属性相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Transactions STransactions(int id)
        {
            return dal.STransactions(id);
        }
        /// <summary>
        /// 通过租房ID查询房屋图片相关信息（售房）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SImg> SSImg(int id)
        {
            return dal.SSImg(id);
        }

        //租房订单修改
        /// <summary>
        /// 通过租房ID查询相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lease SLease(int id)
        {
            return dal.SLease(id);
        }
        /// <summary>
        /// 通过租房ID查询交易属性相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Facilities SFacilities(int id)
        {
            return dal.SFacilities(id);
        }
        /// <summary>
        /// 通过租房ID查询房屋图片相关信息（租房）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LImg> SLImg(int id)
        {
            return dal.SLImg(id);
        }
        /// <summary>
        /// 修改售房信息
        /// </summary>
        /// <param name="sell"></param>
        /// <param name="selling"></param>
        /// <param name="transactions"></param>
        /// <param name="sImg"></param>
        /// <returns></returns>
        public bool EditSELL(Sell sell ,Selling selling ,Transactions transactions,SImg sImg) 
        {
            return dal.EditSELL(sell,selling,transactions,sImg);
        }
    /// <summary>
    /// 修改改租房信息
    /// </summary>
    /// <param name="sell"></param>
    /// <param name="selling"></param>
    /// <param name="transactions"></param>
    /// <param name="sImg"></param>
    /// <param name="id"></param>
    /// <returns></returns>
        public bool EditLEASE(Lease lease, Facilities facilities,  LImg  lImg)
        {
            return dal.EditLEASE(lease,facilities,lImg);
        }
    }
}
