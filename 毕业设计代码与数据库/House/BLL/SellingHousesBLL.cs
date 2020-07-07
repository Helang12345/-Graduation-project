using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Data;


namespace BLL
{
    public class SellingHousesBLL
    {
        HouseEntities db = new HouseEntities();
        //SellingHousesDAL dal = new SellingHousesDAL();
        public static List<Sell> SellsList()
        {
            return SellingHousesDAL.SellsList();
        }
        /// <summary>
        /// 单独查询
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Sell Only(int SellID)
        {
            return SellingHousesDAL.Only(SellID);
        }
        /// <summary>
        /// 查询卖点
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Selling OnlySelling(int SellID)
        {
            return SellingHousesDAL.OnlySelling(SellID);

        }
        /// <summary>
        /// 查询交易属性
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Transactions OnlyTransactions(int SellID)
        {
            return SellingHousesDAL.OnlyTransactions(SellID);

        }
        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static List<SImg> OnlySImg(int SellID)
        {
            return SellingHousesDAL.OnlySImg(SellID); ;

        }
        /// <summary>
        /// 价格排序从高到低
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Higtlow()
        {
            return SellingHousesDAL.Higtlow();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Lowthig()
        {
            return SellingHousesDAL.Lowthig();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Newest()
        {
            return SellingHousesDAL.Newest();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Oldest()
        {
            return SellingHousesDAL.Newest();
        }
        /// <summary>
        /// 查询关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<SCollection> SFollow(int id, int UserID) 
        {
            return SellingHousesDAL.SFollow(id, UserID);
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int AddSFollow(int id, int UserID) 
        {
            return SellingHousesDAL.AddSFollow(id, UserID);
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int DeleSFollow(int id, int UserID)
        {
            SellingHousesDAL dal = new SellingHousesDAL();
            return dal.DeleSFollow(id,UserID);
        }

    }
}
