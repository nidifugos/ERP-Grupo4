using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.ServiceModel.Samples;

namespace ERP.Agendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        Models.erp_agendamentoEntities entities = new Models.erp_agendamentoEntities();         

        //
        // GET: /Agendamento/

        public ActionResult Index()
        {
            return View(entities.AgendamentoSets.ToList());
        }

        //
        // GET: /Agendamento/Details/5

        public ActionResult Details(int id)
        {
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Create

        public ActionResult Create()
        {
            UpdateData();               
            return View();
        } 

        //
        // POST: /Agendamento/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Models.AgendamentoSet pAgendamento)
        {     
            FornecedorServiços fs = new FornecedorServiços();
            pAgendamento.Medico_Id = fs.RH_MedicoId(pAgendamento.Medico_Nome);
            try
            {
                if (!ModelState.IsValid)
                {                    
                    return View();
                }                
                entities.AddToAgendamentoSets(pAgendamento);                
                entities.SaveChanges();                
                return RedirectToAction("Index");
            }
            catch
            {                
                return View();
            }
        }
        
        //
        // GET: /Agendamento/Edit/5
 
        public ActionResult Edit(int id)
        {
            UpdateData();
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();            
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.AgendamentoSet agendamento)
        {
            FornecedorServiços fs = new FornecedorServiços();
            agendamento.Medico_Id = fs.RH_MedicoId(agendamento.Medico_Nome);
            try
            {
                var original = (from ag in entities.AgendamentoSets where ag.Id == agendamento.Id select ag).First();
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
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Delete/5

        [HttpPost]
        public ActionResult Delete(Models.AgendamentoSet pAgendamento)
        {
            try
            {
                var agendamento = (from ag in entities.AgendamentoSets where ag.Id == pAgendamento.Id select ag).First();
                entities.DeleteObject(agendamento);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string ShowPaciente()
        {
            int id = 15;
            string nome = (from paciente in entities.PacienteSets.ToList() where paciente.Id == id select paciente).First().Nome;
            string cpf = (from paciente in entities.PacienteSets.ToList() where paciente.Id == id select paciente).First().Cpf;
            return nome + " [" + cpf + "]";
        }

        /// <summary>
        /// Atualiza informações sobre médicos e especialidades.
        /// </summary>
        private void UpdateData()
        {
            // Especialidades
            FornecedorServiços fs = new FornecedorServiços();
            List<String> listaEspecialidades = fs.RH_Especialidade();
            List<SelectListItem> especialidades = new List<SelectListItem>();
            foreach (String espec in listaEspecialidades)
            {
                especialidades.Add(new SelectListItem
                {
                    Text = espec,
                });
            }
            ViewData["Especialidade"] = especialidades;
            // Pacientes                       
            List<Models.PacienteSet> listaPacientes = entities.PacienteSets.ToList();
            List<SelectListItem> pacientes = new List<SelectListItem>();
            foreach (Models.PacienteSet pac in listaPacientes)
            {
                pacientes.Add(new SelectListItem
                {
                    Text = pac.Nome + " [" + pac.Cpf + "]",
                    Value = Convert.ToString(pac.Id),
                });
            }
            ViewData["Pacientes"] = pacientes;
            ViewData["Paciente_Id"] = pacientes.AsEnumerable<SelectListItem>();
            // Médicos
            List<string> listaMedicos = fs.RH_Medicos();
            List<SelectListItem> medicos = new List<SelectListItem>();
            foreach (string med in listaMedicos)
            {
                medicos.Add(new SelectListItem
                {
                    Text = med,
                });
            }
            ViewData["Medico_Nome"] = medicos;
        }
    }
}
