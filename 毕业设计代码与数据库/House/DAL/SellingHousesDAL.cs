using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SellingHousesDAL
    {
        static HouseEntities db = new HouseEntities();
        /// <summary>
        /// 查询SELL数据
        /// </summary>
        /// <returns></returns>
        public static List<Sell> SellsList()
        {
            return db.Sell.Where(p=>p.TransactionStatus==1).ToList(); ;
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Sell Only(int SellID)
        {
            return db.Sell.SingleOrDefault(p => p.SellID == SellID&& p.TransactionStatus == 1);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Selling OnlySelling(int SellID)
        {
            return db.Selling.SingleOrDefault(p => p.SellID == SellID );

        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static Transactions OnlyTransactions(int SellID)
        {
            return db.Transactions.SingleOrDefault(p => p.SellID == SellID);

        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="SellID"></param>
        /// <returns></returns>
        public static List<SImg> OnlySImg(int SellID)
        {
            return db.SImg.Where(p => p.SellID == SellID).ToList();

        }
        /// <summary>
        /// 价格排序从高到低
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Higtlow()
        {
            //降序排列
            return db.Sell.Where(p => p.TransactionStatus == 1).OrderByDescending(p => p.SellPrice).ToList();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Lowthig()
        {
            //升序排列
            return db.Sell.Where(p => p.TransactionStatus == 1).OrderBy(p => p.SellPrice).ToList();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Newest()
        {
            //降序排列
            return db.Sell.Where(p => p.TransactionStatus == 1).OrderByDescending(p => p.NewTime).ToList();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Oldest()
        {
            //升序排列
            return db.Sell.Where(p => p.TransactionStatus == 1).OrderBy(p => p.NewTime).ToList();
        }
        /// <summary>
        /// 查询关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<SCollection> SFollow(int id, int UserID)
        {
            return db.SCollection.Where(p => p.UserID == UserID && p.SellID == id).ToList();
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int AddSFollow(int id,int UserID)
        {
            //重新定义对象
            SCollection sc = new SCollection()
            {
                UserID = UserID,
                SellID = id
            };
            db.SCollection.Add(sc);
            return db.SaveChanges();
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public  int DeleSFollow(int id, int UserID)
        {
            //查询对象
            SCollection a = db.SCollection.FirstOrDefault(p => p.SellID == id && p.UserID == UserID);
            db.SCollection.Remove(a);
            return db.SaveChanges();
        }
    }
}
