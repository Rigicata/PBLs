using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBLCopos.Models;

namespace PBLCopos.Controllers
{
    public class BebedourosController : Controller
    {
        private PBLCoposContext db = new PBLCoposContext();

        // GET: Bebedouros
        public ActionResult Index()
        {
            var bebedouroes = db.Bebedouroes.Include(b => b.Estoque);
            return View(bebedouroes.ToList());
        }

        // GET: Bebedouros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            return View(bebedouro);
        }

        // GET: Bebedouros/Create
        public ActionResult Create()
        {
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId");
            return View();
        }

        // POST: Bebedouros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BebedouroId,Localizacao,StatusCopo,EstoqueId")] Bebedouro bebedouro)
        {
            if (ModelState.IsValid)
            {
                db.Bebedouroes.Add(bebedouro);
                
                bebedouro.Estoque.diminuiSacos();

                
                db.SaveChanges();
               

               
                return RedirectToAction("Index");
            }
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", bebedouro.EstoqueId);

            bebedouro.Estoque.diminuiSacos();
            
            return View(bebedouro);
        }

        // GET: Bebedouros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", bebedouro.EstoqueId);
            return View(bebedouro);
        }

        // POST: Bebedouros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BebedouroId,Localizacao,StatusCopo,EstoqueId")] Bebedouro bebedouro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bebedouro).State = EntityState.Modified;
                if (bebedouro.StatusCopo == StatusCopo.Tem)
                {

                    bebedouro.Estoque.diminuiSacos();

                }

                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", bebedouro.EstoqueId);
           

            return View(bebedouro);
        }

        // GET: Bebedouros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            return View(bebedouro);
        }

        // POST: Bebedouros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            db.Bebedouroes.Remove(bebedouro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BebedourosVazios()
        {
            var bebedouroes = db.Bebedouroes.Include(b => b.Estoque);
            return View(bebedouroes.ToList().Where(a => a.StatusCopo == StatusCopo.NaoTem));
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
