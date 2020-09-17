using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleDeGastos.Models;

namespace ControleDeGastos.Controllers
{
    public class ControleGastosController : Controller
    {
        private ControleGastoContext db = new ControleGastoContext();

        // GET: ControleGastos
        public ActionResult Index()
        {
            return View(db.ControleGastos.Where(x=> x.DataExcluido == null).ToList());
        }

        // GET: ControleGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleGastos controleGastos = db.ControleGastos.Find(id);
            if (controleGastos == null)
            {
                return HttpNotFound();
            }
            return View(controleGastos);
        }

        // GET: ControleGastos/Create
        public ActionResult Create()
        {
            CarregarViewBag();
            return View();
        }

        public void CarregarViewBag()
        {  

            List<SelectListItem> Listaitems = new List<SelectListItem>();

            Listaitems.Add(new SelectListItem { Text = "Selecione...", Value = "0" });
            Listaitems.Add(new SelectListItem { Text = "Receita", Value = "1" });
            Listaitems.Add(new SelectListItem { Text = "Despesa", Value = "2" }); 
 

            ViewBag.TipoGasto = Listaitems;
        }

        // POST: ControleGastos/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodGasto,TipoGasto,Descricao,Valor,DataCadastro,DataAlteracao,DataExcluido")] ControleGastos controleGastos)
        {
            if (ModelState.IsValid)
            {
                db.ControleGastos.Add(controleGastos);
                controleGastos.DataCadastro = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(controleGastos);
        }

        // GET: ControleGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleGastos controleGastos = db.ControleGastos.Find(id);
            if (controleGastos == null)
            {
                return HttpNotFound();
            }
            return View(controleGastos);
        }

        // POST: ControleGastos/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodGasto,TipoGasto,Descricao,Valor,DataCadastro,DataAlteracao,DataExcluido")] ControleGastos controleGastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controleGastos).State = EntityState.Modified;
                controleGastos.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controleGastos);
        }

        // GET: ControleGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControleGastos controleGastos = db.ControleGastos.Find(id);
            if (controleGastos == null)
            {
                return HttpNotFound();
            }
            return View(controleGastos);
        }

        // POST: ControleGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControleGastos controleGastos = db.ControleGastos.Find(id);
            controleGastos.DataExcluido = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
