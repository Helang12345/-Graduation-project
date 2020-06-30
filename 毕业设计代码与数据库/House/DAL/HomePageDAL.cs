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
        HouseEntities1 db = new HouseEntities1();
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
        public List<Sell> SellSelect() 
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
        //条件查询出售表
        public List<Sell> SelectSell(int OpenHome, int House0rientation, int Area, int Renovation)
        {
            //全不选择
            if (OpenHome == 0 && House0rientation == 0 && Area == 0 && Renovation == 0)
            {
                return db.Sell.ToList();
            }
            //选择看房时间
            else if (OpenHome != 0 && House0rientation == 0 && Area == 0 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome).ToList();
            }
            //选择看房时间和房屋朝向
            else if (OpenHome != 0 && House0rientation != 0 && Area == 0 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation).ToList();
            }
            //选择看时间和房屋朝向面积小于50
            else if (OpenHome != 0 && House0rientation != 0 && Area == 1 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 20).ToList();
            }
            //选择看时间和房屋朝向面积在50到80
            else if (OpenHome != 0 && House0rientation != 0 && Area == 2 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 80 && p.SellArea > 50).ToList();
            }
            //选择看时间和房屋朝向面积在80到120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 3 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 120 && p.SellArea > 80).ToList();
            }
            //选择看时间和房屋朝向面积大于120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 4 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea > 120).ToList();
            }
            //全部选择面积在50以下
            else if (OpenHome != 0 && House0rientation != 0 && Area == 1 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 50 && p.SellRenovation == Renovation).ToList();
            }
            //全部选择面积在50~80
            else if (OpenHome != 0 && House0rientation != 0 && Area == 2 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 80 && p.SellArea > 50 && p.SellRenovation == Renovation).ToList();
            }
            //全部选择面积在80~120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 3 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea < 120 && p.SellArea > 80 && p.SellRenovation == Renovation).ToList();
            }
            //全部选择面积在120以上
            else if (OpenHome != 0 && House0rientation != 0 && Area == 4 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellOrientation == House0rientation && p.SellArea > 120 && p.SellRenovation == Renovation).ToList();
            }
            //看房时间面积50以下
            else if (OpenHome != 0 && House0rientation == 0 && Area == 1 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea < 50).ToList();
            }
            //看房时间面积50~80
            else if (OpenHome != 0 && House0rientation == 0 && Area == 2 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea < 80 && p.SellArea > 50).ToList();
            }
            //看房时间面积80~120
            else if (OpenHome != 0 && House0rientation == 0 && Area == 3 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea < 120 && p.SellArea > 80).ToList();
            }
            //看房时间面积120以上
            else if (OpenHome != 0 && House0rientation == 0 && Area == 4 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea > 120).ToList();
            }
            //看房时间面积50以下装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 1 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea < 50 && p.SellRenovation == Renovation).ToList();
            }
            //看房时间面积50~80装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 2 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea > 50 && p.SellArea < 80 && p.SellRenovation == Renovation).ToList();
            }
            //看房时间面积50~80装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 3 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea > 80 && p.SellArea < 120 && p.SellRenovation == Renovation).ToList();
            }
            //看房时间面积120以上装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 4 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellArea > 120 && p.SellRenovation == Renovation).ToList();
            }
            //看房时间面积装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 0 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellTime == OpenHome && p.SellRenovation == Renovation).ToList();
            }
            //只选择房屋朝向
            else if (OpenHome == 0 && House0rientation != 0 && Area == 0 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation).ToList();
            }
            //选择房屋朝向面积50以下
            else if (OpenHome == 0 && House0rientation != 0 && Area == 1 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea < 50).ToList();
            }
            //选择房屋朝向面积50~80
            else if (OpenHome == 0 && House0rientation != 0 && Area == 2 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 50 && p.SellArea < 80).ToList();
            }
            //选择房屋朝向面积80~120
            else if (OpenHome == 0 && House0rientation != 0 && Area == 3 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 80 && p.SellArea < 120).ToList();
            }
            //选择房屋朝向面积120以上
            else if (OpenHome == 0 && House0rientation != 0 && Area == 4 && Renovation == 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 120).ToList();
            }
            //选择房屋朝向面积50以下有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 1 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea < 50 && p.SellRenovation == Renovation).ToList();
            }
            //选择房屋朝向面积50~80有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 2 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 50 && p.SellArea < 80 && p.SellRenovation == Renovation).ToList();
            }
            //选择房屋朝向面积80~120有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 3 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 80 && p.SellArea < 120 && p.SellRenovation == Renovation).ToList();
            }
            //选择房屋朝向面积120以上有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 4 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellArea > 120 && p.SellRenovation == Renovation).ToList();
            }
            //选择房屋朝向装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 0 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellOrientation == House0rientation && p.SellRenovation == Renovation).ToList();
            }
            //选择面积50以下有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 1 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellArea < 50 && p.SellRenovation == Renovation).ToList();
            }
            //选择面积50~80有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 2 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellArea > 50 && p.SellArea < 80 && p.SellRenovation == Renovation).ToList();
            }
            //选择面积80~120有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 3 && Renovation != 0)
            {
                return db.Sell.Where(p => p.SellArea > 80 && p.SellArea < 120 && p.SellRenovation == Renovation).ToList();
            }
            //选择面积120以上有装修情况
            else
            {
                return db.Sell.Where(p => p.SellArea > 120 && p.SellRenovation == Renovation).ToList();
            }
        }
        //条件查询出租表
        public List<Lease> SelectLease(int OpenHome, int House0rientation, int Area, int Renovation)
        {
            //全不选择
            if (OpenHome == 0 && House0rientation == 0 && Area == 0 && Renovation == 0)
            {
                return db.Lease.ToList();
            }
            //选择看房时间
            else if (OpenHome != 0 && House0rientation == 0 && Area == 0 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome).ToList();
            }
            //选择看房时间和房屋朝向
            else if (OpenHome != 0 && House0rientation != 0 && Area == 0 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation).ToList();
            }
            //选择看时间和房屋朝向面积小于50
            else if (OpenHome != 0 && House0rientation != 0 && Area == 1 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 20).ToList();
            }
            //选择看时间和房屋朝向面积在50到80
            else if (OpenHome != 0 && House0rientation != 0 && Area == 2 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 80 && p.LeaseArea > 50).ToList();
            }
            //选择看时间和房屋朝向面积在80到120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 3 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 120 && p.LeaseArea > 80).ToList();
            }
            //选择看时间和房屋朝向面积大于120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 4 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea > 120).ToList();
            }
            //全部选择面积在50以下
            else if (OpenHome != 0 && House0rientation != 0 && Area == 1 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 50 && p.LeaseCheckin == Renovation).ToList();
            }
            //全部选择面积在50~80
            else if (OpenHome != 0 && House0rientation != 0 && Area == 2 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 80 && p.LeaseArea > 50 && p.LeaseCheckin == Renovation).ToList();
            }
            //全部选择面积在80~120
            else if (OpenHome != 0 && House0rientation != 0 && Area == 3 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea < 120 && p.LeaseArea > 80 && p.LeaseCheckin == Renovation).ToList();
            }
            //全部选择面积在120以上
            else if (OpenHome != 0 && House0rientation != 0 && Area == 4 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseOrientation == House0rientation && p.LeaseArea > 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //看房时间面积50以下
            else if (OpenHome != 0 && House0rientation == 0 && Area == 1 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea < 50).ToList();
            }
            //看房时间面积50~80
            else if (OpenHome != 0 && House0rientation == 0 && Area == 2 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea < 80 && p.LeaseArea > 50).ToList();
            }
            //看房时间面积80~120
            else if (OpenHome != 0 && House0rientation == 0 && Area == 3 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea < 120 && p.LeaseArea > 80).ToList();
            }
            //看房时间面积120以上
            else if (OpenHome != 0 && House0rientation == 0 && Area == 4 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea > 120).ToList();
            }
            //看房时间面积50以下装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 1 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea < 50 && p.LeaseCheckin == Renovation).ToList();
            }
            //看房时间面积50~80装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 2 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea > 50 && p.LeaseArea < 80 && p.LeaseCheckin == Renovation).ToList();
            }
            //看房时间面积50~80装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 3 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea > 80 && p.LeaseArea < 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //看房时间面积120以上装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 4 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseArea > 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //看房时间面积装修情况
            else if (OpenHome != 0 && House0rientation == 0 && Area == 0 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseTime == OpenHome && p.LeaseCheckin == Renovation).ToList();
            }
            //只选择房屋朝向
            else if (OpenHome == 0 && House0rientation != 0 && Area == 0 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation).ToList();
            }
            //选择房屋朝向面积50以下
            else if (OpenHome == 0 && House0rientation != 0 && Area == 1 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea < 50).ToList();
            }
            //选择房屋朝向面积50~80
            else if (OpenHome == 0 && House0rientation != 0 && Area == 2 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 50 && p.LeaseArea < 80).ToList();
            }
            //选择房屋朝向面积80~120
            else if (OpenHome == 0 && House0rientation != 0 && Area == 3 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 80 && p.LeaseArea < 120).ToList();
            }
            //选择房屋朝向面积120以上
            else if (OpenHome == 0 && House0rientation != 0 && Area == 4 && Renovation == 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 120).ToList();
            }
            //选择房屋朝向面积50以下有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 1 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea < 50 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择房屋朝向面积50~80有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 2 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 50 && p.LeaseArea < 80 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择房屋朝向面积80~120有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 3 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 80 && p.LeaseArea < 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择房屋朝向面积120以上有装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 4 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseArea > 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择房屋朝向装修情况
            else if (OpenHome == 0 && House0rientation != 0 && Area == 0 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseOrientation == House0rientation && p.LeaseCheckin == Renovation).ToList();
            }
            //选择面积50以下有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 1 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseArea < 50 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择面积50~80有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 2 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseArea > 50 && p.LeaseArea < 80 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择面积80~120有装修情况
            else if (OpenHome == 0 && House0rientation == 0 && Area == 3 && Renovation != 0)
            {
                return db.Lease.Where(p => p.LeaseArea > 80 && p.LeaseArea < 120 && p.LeaseCheckin == Renovation).ToList();
            }
            //选择面积120以上有装修情况
            else
            {
                return db.Lease.Where(p => p.LeaseArea > 120 && p.LeaseCheckin == Renovation).ToList();
            }
        }
    }
}
