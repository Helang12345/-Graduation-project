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
        HouseEntities db = new HouseEntities();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Loginname"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Userd Userds(string Loginname, string Password) 
        {
            return db.Userd.SingleOrDefault(p => p.UserdEmail == Loginname && p.UserPassword == Password &&p.UState==0);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Loginname"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public  Salesman Salesman(string Loginname, string Password)
        {
            return db.Salesman.SingleOrDefault(p => p.SalesmanEmail == Loginname && p.SalesmanPassword == Password&&p.UState == 0);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool AddUserd(Userd userd)
        {
            db.Userd.Add(userd);
            int a= db.SaveChanges();
            if (a == 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
       
    }
}
