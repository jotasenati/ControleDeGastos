using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeGastos.Controllers
{
    public class DropDownListController : Controller
    {
        public ActionResult SelectCategory()
        {

            //List<SelectListItem> items = new List<SelectListItem>();

            //items.Add(new SelectListItem { Text = "Receita", Value = "0" });

            //items.Add(new SelectListItem { Text = "Despesa", Value = "1" });

            //ViewBag.TipoGasto = items;

            return View();

        }
    }
}


