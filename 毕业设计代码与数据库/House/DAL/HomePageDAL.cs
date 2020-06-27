using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

/// <summary>
/// 语句
/// </summary>
namespace DAL
{
    public class HomePageDAL
    {
        HouseEntities db = new HouseEntities();
        /// <summary>
        /// 查询金牌销售
        /// </summary>
        /// <returns></returns>
        public  List<Salesman>  SalesmenSelect()
        {
            return db.Salesman.Take(4).ToList(); 
        }
        /// <summary>
        /// 查询卖房数据
        /// </summary>
        /// <returns></returns>
        public List<Sell> SellsSelect() 
        {
            return db.Sell.Take(6).ToList(); 
        }
        /// <summary>
        /// 查询租房数据
        /// </summary>
        /// <returns></returns>
        public List<Lease> LeaseSelect()
        {
            return db.Lease.Take(6).ToList();
        }
       
    }
}
