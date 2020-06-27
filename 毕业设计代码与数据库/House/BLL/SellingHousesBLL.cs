using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace BLL
{
    public class SellingHousesBLL
    {
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
        public static Selling OnlySelling(int SellID)
        {
            return SellingHousesDAL.OnlySelling(SellID);

        }
        public static Transactions OnlyTransactions(int SellID)
        {
            return SellingHousesDAL.OnlyTransactions(SellID);

        }
        public static List<SImg> OnlySImg(int SellID)
        {
            return SellingHousesDAL.OnlySImg(SellID);;

        }
    }
}
