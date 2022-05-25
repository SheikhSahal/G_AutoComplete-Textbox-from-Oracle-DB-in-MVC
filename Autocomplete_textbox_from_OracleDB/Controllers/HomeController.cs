using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using AutoComplete_Textbox_From_OracleDB.ModelView;
using AutoComplete_Textbox_From_OracleDB.Models;

namespace AutoComplete_Textbox_From_OracleDB.Controllers
{
    public class HomeController : Controller
    {
        db dblayer = new db();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRecord(string prefix)
        {
            DataSet ds = dblayer.GetName(prefix);
            List<search> searchlist = new List<search>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                searchlist.Add(new search
                {
                    EMPNO = dr["EMPNO"].ToString(),
                    ENAME = dr["ENAME"].ToString()
                });

            }

            return Json(searchlist, JsonRequestBehavior.AllowGet);
        }
    }
}