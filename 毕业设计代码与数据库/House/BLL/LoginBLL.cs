using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
  public  class LoginBLL
    {
        //实例化DAL层
        LoginDAL dal = new LoginDAL();
        public Userd Userds(string Loginname, string Password) 
        {
            return dal.Userds(Loginname, Password);
        }
        public Salesman Salesman(string Loginname, string Password)
        {
            return dal.Salesman(Loginname, Password);
        }
    }
}
