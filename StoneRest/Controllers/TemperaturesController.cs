using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoneRest.Models;
using StoneRest.Util;

namespace StoneRest.Controllers
{
    [RoutePrefix("temperatures")]
    public class TemperaturesController : Controller
    {
        private string DB_Name;

        public TemperaturesController()
        {
            DB_Name = "DBCities.db";
        }

        public TemperaturesController(string DBName)
        {
            DB_Name = DBName;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(this.GetList(1));
        }

        // Controle de páginas exibidas com 10 linhas/pag
        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            return View(this.GetList(currentPageIndex));
        }

        private ListModel GetList(int currentPage)
        {
            int maxRows = 10; // Número de linhas na tabela

            ListModel listModel = new ListModel();

            listModel.Temperatures = DB.AllTemperatures(DB_Name);

            double pageCount = (double)((decimal)listModel.Temperatures.Count() / Convert.ToDecimal(maxRows));

            listModel.PageCount = (int)Math.Ceiling(pageCount);

            listModel.Temperatures = listModel.Temperatures
                                     .Skip((currentPage - 1) * maxRows)
                                     .Take(maxRows);

            listModel.CurrentPageIndex = currentPage;

            return listModel;
        }
    }
}
