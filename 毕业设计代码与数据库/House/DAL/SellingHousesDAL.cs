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
        static HouseEntities2 db = new HouseEntities2();
        public static List<Sell> SellsList()
        {
            return db.Sell.ToList(); ;
        }
        public static Sell Only(int SellID)
        {
            return db.Sell.SingleOrDefault(p => p.SellID == SellID);
        }
        public static Selling OnlySelling(int SellID)
        {
            return db.Selling.SingleOrDefault(p => p.SellID == SellID);

        }
        public static Transactions OnlyTransactions(int SellID)
        {
            return db.Transactions.SingleOrDefault(p => p.SellID == SellID);

        }
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
            return db.Sell.OrderByDescending(p => p.SellPrice).ToList();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Lowthig()
        {
            //升序排列
            return db.Sell.OrderBy(p => p.SellPrice).ToList();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Newest()
        {
            //降序排列
            return db.Sell.OrderByDescending(p => p.SellID).ToList();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Sell> Oldest()
        {
            //升序排列
            return db.Sell.OrderBy(p => p.SellID).ToList();
        }
        public static List<SCollection> SFollow(int id, int UserID)
        {
            return db.SCollection.Where(p => p.UserID == UserID && p.SellID == id).ToList();
        }
        public static int AddSFollow(int id,int UserID)
        {
            SCollection sc = new SCollection()
            {
                UserID = UserID,
                SellID = id
            };
            db.SCollection.Add(sc);
            return db.SaveChanges();
        }
        public  int DeleSFollow(int id, int UserID)
        {
            SCollection a = db.SCollection.FirstOrDefault(p => p.SellID == id && p.UserID == UserID);
            db.SCollection.Remove(a);
            return db.SaveChanges();
        }
    }
}
