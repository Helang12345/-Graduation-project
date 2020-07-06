using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class LeaseHousesBLL
    {
        //LeaseingHousesDAL dal = new LeaseingHousesDAL();
        public static List<Lease> LeaseList()
        {
            return LeaseHousesDAL.LeaseList();
        }
        /// <summary>
        /// 单独查询
        /// </summary>
        /// <param name="LeaseID"></param>
        /// <returns></returns>
        public static Lease Only(int LeaseID)
        {
            return LeaseHousesDAL.Only(LeaseID);
        }
        public static Facilities OnlyFacilities(int LeaseID)
        {
            return LeaseHousesDAL.OnlyFacilities(LeaseID);
        }
        public static List<LImg> OnlyLImg(int LeaseID)
        {
            return LeaseHousesDAL.OnlyLImg(LeaseID);

        }
        /// <summary>
        /// 价格排序从高到低
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Higtlow()
        {
            return LeaseHousesDAL.Higtlow();
        }
        /// <summary>
        /// 接个排序从低到高
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Lowthig()
        {
            return LeaseHousesDAL.Lowthig();
        }
        /// <summary>
        /// 最新排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Newest()
        {
            return LeaseHousesDAL.Newest();
        }
        /// <summary>
        /// 最旧排序
        /// </summary>
        /// <returns></returns>
        public static List<Lease> Oldest()
        {
            return LeaseHousesDAL.Newest();
        }
        public static List<LCollection> SFollow(int id, int UserID)
        {
            return LeaseHousesDAL.SFollow(id, UserID);
        }
        public static int AddSFollow(int id, int UserID)
        {
            return LeaseHousesDAL.AddSFollow(id, UserID);
        }
        public static int DeleSFollow(int id, int UserID)
        {
            LeaseHousesDAL dal = new LeaseHousesDAL();
            return dal.DeleSFollow(id, UserID);
        }
    }
}
