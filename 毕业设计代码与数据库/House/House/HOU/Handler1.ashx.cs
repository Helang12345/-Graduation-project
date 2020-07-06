using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Mvc;

namespace House.HOU
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        HouseEntities2 db = new HouseEntities2();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var num = context.Request.Files.Count;

            for (int i = 0; i < num; i++)
            {
                HttpPostedFile file = context.Request.Files[i];
                //上传的文件保存到目录(为了保证文件名不重复，加个Guid)
                string path = "../Content/Renting/" + Guid.NewGuid().ToString() + file.FileName;
                SImg sImg = new SImg() {
                    Photo = file.FileName,
                };
                db.SImg.Add(sImg);
                db.SaveChanges();
                file.SaveAs(context.Request.MapPath(path));//必须得是相对路径

            }
            context.Response.Write("上传成功");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}