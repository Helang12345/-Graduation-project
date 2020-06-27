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
    }
}
