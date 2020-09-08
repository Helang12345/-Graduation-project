using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        //实例化DAL层
        LoginDAL dal = new LoginDAL();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Loginname"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Userd Userds(string Loginname, string Password)
        {
            return dal.Userds(Loginname, Password);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Loginname"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Userd Userds2(string Loginname, string Password)
        {
            return dal.Userds2(Loginname, Password);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Loginname"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Salesman Salesman(string Loginname, string Password)
        {
            return dal.Salesman(Loginname, Password);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int AddUserd(Userd userd)
        {
            return dal.AddUserd(userd);
        }
       
    }
}
