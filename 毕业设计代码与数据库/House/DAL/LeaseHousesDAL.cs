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
        static HouseEntities2 db = new HouseEntities2();
        public static List<Lease> LeaseList()
        {
            return db.Lease.ToList(); ;
        }
        public static Lease Only(int LeaseID)
        {
            return db.Lease.SingleOrDefault(p => p.LeaseID == LeaseID);
        }
        public static Facilities OnlyFacilities(int LeaseID)
        {
            return db.Facilities.SingleOrDefault(p => p.LeaseID == LeaseID);

        }
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
            return db.Lease.OrderByDescending(p => p.LeasePrice).ToList();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Lowthig()
        {
            //升序排列
            return db.Lease.OrderBy(p => p.LeasePrice).ToList();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Newest()
        {
            //降序排列
            return db.Lease.OrderByDescending(p => p.LeaseID).ToList();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Oldest()
        {
            //升序排列
            return db.Lease.OrderBy(p => p.LeaseID).ToList();
        }
        //public static List<Lease> PagedList(int page) 
        //{
        //    //第几页  三目运算符
        //    int pageNumber = page ?? 1;
        //    //每页显示多少条
        //    int pageSize = 5;
        //    //排序
        //    List<Lease> kk = db.Lease.OrderBy(p => p.LeaseID).ToList();

        //    ///通过ToPagedList扩展方法进行分页  
        //    IPagedList<Lease> usePageList = kk.ToPagedList(pageNumber, pageSize);
        //    return kk.ToPagedList(pageNumber, pageSize);
        //}
        public static List<LCollection> SFollow(int id, int UserID)
        {
            return db.LCollection.Where(p => p.UserID == UserID && p.LeaseID == id).ToList();
        }
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
        public int DeleSFollow(int id, int UserID)
        {
            LCollection a = db.LCollection.FirstOrDefault(p => p.LeaseID == id && p.UserID == UserID);
            db.LCollection.Remove(a);
            return db.SaveChanges();
        }
    }
}
