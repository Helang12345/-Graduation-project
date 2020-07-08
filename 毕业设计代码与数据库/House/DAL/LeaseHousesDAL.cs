using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using PagedList;
using PagedList.Mvc;
     

namespace DAL
{
    public class LeaseHousesDAL
    {
        static HouseEntities db = new HouseEntities();
        /// <summary>
        /// 查询表格
        /// </summary>
        /// <returns></returns>
        public static List<Lease> LeaseList()
        {
            return db.Lease.Where(p=>p.UState==0).ToList(); ;
        }
        /// <summary>
        /// 单独查询，显示详情
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public static Lease Only(int LeaseID)
        {
            return db.Lease.SingleOrDefault(p => p.LeaseID == LeaseID&&p.UState==0);
        }
        /// <summary>
        /// 单独查询
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public static Facilities OnlyFacilities(int LeaseID)
        {
            return db.Facilities.SingleOrDefault(p => p.LeaseID == LeaseID);

        }
        /// <summary>
        /// 单独查询
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public static List<LImg> OnlyLImg(int LeaseID)
        {
            return db.LImg.Where(p => p.LeaseID == LeaseID).ToList();

        }
        /// <summary>
        /// 价格排序从高到低
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Higtlow()
        {
            //降序排列
            return db.Lease.OrderByDescending(p => p.LeasePrice).Where(p => p.UState == 0).ToList();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Lowthig()
        {
            //升序排列
            return db.Lease.OrderBy(p => p.LeasePrice).Where(p => p.UState == 0).ToList();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Newest()
        {
            //降序排列
            return db.Lease.OrderByDescending(p => p.NewTime).Where(p => p.UState == 0).ToList();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Oldest()
        {
            //升序排列
            return db.Lease.OrderBy(p => p.NewTime).Where(p => p.UState == 0).ToList();
        }
       /// <summary>
       /// 查询关注
       /// </summary>
       /// <param name="id"></param>
       /// <param name="UserID"></param>
       /// <returns></returns>
        public static List<LCollection> SFollow(int id, int UserID)
        {
            return db.LCollection.Where(p => p.UserID == UserID && p.LeaseID == id).ToList();
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int AddSFollow(int id, int UserID)
        {
            LCollection sc = new LCollection()
            {
                UserID = UserID,
                LeaseID = id
            };
            db.LCollection.Add(sc);
            return db.SaveChanges();
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int DeleSFollow(int id, int UserID)
        {
            LCollection a = db.LCollection.FirstOrDefault(p => p.LeaseID == id && p.UserID == UserID);
            db.LCollection.Remove(a);
            return db.SaveChanges();
        }
    }
}
