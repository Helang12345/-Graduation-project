using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
   public class LoginDAL
    {
        //引用model
        HouseEntities2 db = new HouseEntities2();
        public Userd Userds(string Loginname, string Password) 
        {
            return db.Userd.SingleOrDefault(p => p.UserdEmail == Loginname && p.UserPassword == Password);
        }
        public  Salesman Salesman(string Loginname, string Password)
        {
            return db.Salesman.SingleOrDefault(p => p.SalesmanEmail == Loginname && p.SalesmanPassword == Password);
        }
    }
}
