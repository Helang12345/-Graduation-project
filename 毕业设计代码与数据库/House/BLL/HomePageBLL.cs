using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

/// <summary>
/// 逻辑
/// </summary>
namespace BLL
{
    public class HomePageBLL
    {
        //实例化DAL层
        HomePageDAL dal = new HomePageDAL();
        /// <summary>
        /// 查询金牌销售
        /// </summary>
        /// <returns></returns>
        public List<Salesman> SalesmenSelect()
        {
            return dal.SalesmenSelect();
        }
        /// <summary>
        /// 查询卖房数据
        /// </summary>
        /// <returns></returns>
        public List<Sell> SellsSelect()
        {
            return dal.SellsSelect();
        }
        /// <summary>
        /// 查询租房数据
        /// </summary>
        /// <returns></returns>
        public List<Lease> LeaseSelect()
        {
            return dal.LeaseSelect();
        }
       
    }
}
