using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Agendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        Models.erpEntities entities = new Models.erpEntities(); 

        //
        // GET: /Agendamento/

        public ActionResult Index()
        {
            return View(entities.AgendamentoSet.ToList());
        }

        //
        // GET: /Agendamento/Details/5

        public ActionResult Details(int id)
        {
            var agendamento = (from ag in entities.AgendamentoSet where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Agendamento/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Models.AgendamentoSet pAgendamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {                    
                    return View();
                }                
                entities.AddToAgendamentoSet(pAgendamento);
                Response.Write("<script>alert('Entity added')</script>");
                entities.SaveChanges();
                Response.Write("<script>alert('Changes saved!')</script>");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Response.Write(String.Format("<script>alert('{0}')</script>", e.StackTrace));
                return View();
            }
        }
        
        //
        // GET: /Agendamento/Edit/5
 
        public ActionResult Edit(int id)
        {
            var agendamento = (from ag in entities.AgendamentoSet where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.AgendamentoSet agendamento)
        {
            try
            {
                var original = (from ag in entities.AgendamentoSet where ag.Id == agendamento.Id select ag).First();
                if (!ModelState.IsValid)
                    return View();
                entities.ApplyCurrentValues(original.EntityKey.EntitySetName, agendamento);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agendamento/Delete/5
 
        public ActionResult Delete(int id)
        {
            var agendamento = (from ag in entities.AgendamentoSet where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Delete/5

        [HttpPost]
        public ActionResult Delete(Models.AgendamentoSet pAgendamento)
        {
            try
            {
                var agendamento = (from ag in entities.AgendamentoSet where ag.Id == pAgendamento.Id select ag).First();
                entities.DeleteObject(agendamento);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
