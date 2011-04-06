using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Agendamento.Controllers
{
    public class PacienteController : Controller
    {
        Models.erp_agendamentoEntities entities = new Models.erp_agendamentoEntities(); 

        //
        // GET: /Paciente/

        public ActionResult Index()
        {
            return View(entities.PacienteSets.ToList());
        }

        //
        // GET: /Paciente/Details/5

        public ActionResult Details(int id)
        {
            var paciente = (from pac in entities.PacienteSets where pac.Id == id select pac).First();
            return View(paciente);
        }

        //
        // GET: /Paciente/Create

        public ActionResult Create()
        {
            return View();   
        } 

        //
        // POST: /Paciente/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Models.PacienteSet pPaciente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                entities.AddToPacienteSets(pPaciente);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Paciente/Edit/5
 
        public ActionResult Edit(int id)
        {
            var paciente = (from pac in entities.PacienteSets where pac.Id == id select pac).First();
            return View(paciente);
        }

        //
        // POST: /Paciente/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.PacienteSet paciente)
        {
            try
            {
                var original = (from pac in entities.PacienteSets where pac.Id == paciente.Id select pac).First();
                if (!ModelState.IsValid)
                    return View();
                entities.ApplyCurrentValues(original.EntityKey.EntitySetName, paciente);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Paciente/Delete/5
 
        public ActionResult Delete(int id)
        {
            var paciente = (from pac in entities.PacienteSets where pac.Id == id select pac).First();
            return View(paciente);
        }

        //
        // POST: /Paciente/Delete/5

        [HttpPost]
        public ActionResult Delete(Models.PacienteSet pPaciente)
        {
            var agendamento = (from ag in entities.AgendamentoSets where ag.Paciente_Id == pPaciente.Id select ag).First();
            if (agendamento != null)
            {
                ERP.Agendamento.Controllers.HomeController.ErrorMessage = 
                    "Existem agendamentos para o paciente; remova-os antes de prosseguir.";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var paciente = (from pac in entities.PacienteSets where pac.Id == pPaciente.Id select pac).First();
                entities.DeleteObject(paciente);
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


