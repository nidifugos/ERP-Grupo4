using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Agendamento.Serviços.Utils;

namespace ERP.Agendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        Models.erp_agendamentoEntities entities = new Models.erp_agendamentoEntities();

        public ActionResult Evaluate()
        {
            return View((from agendamentos in entities.AgendamentoSets where agendamentos.Estado == "marcado" select agendamentos).ToList());
        }

        //
        // GET: /Agendamento/Confirm/5

        public ActionResult Confirm(int id)
        {
            Models.AgendamentoSet agendamento = (from agendamentos in entities.AgendamentoSets where agendamentos.Id == id select agendamentos).First();
            agendamento.Estado = "confirmado";
            entities.SaveChanges();
            return View();
        }

        public ActionResult Cancel(int id)
        {
            Models.AgendamentoSet agendamento = (from agendamentos in entities.AgendamentoSets where agendamentos.Id == id select agendamentos).FirstOrDefault();
            agendamento.Estado = "cancelado";
            entities.SaveChanges();
            return View();
        }

        public ActionResult Consolidate()
        {
            return View((from agendamentos in entities.AgendamentoSets where agendamentos.Estado == "remarcar" select agendamentos).ToList());
        }

        //
        // GET: /Agendamento/

        public ActionResult Index()
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            return View(entities.AgendamentoSets.ToList());
        }

        //
        // GET: /Agendamento/Details/5

        public ActionResult Details(int id)
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Create

        public ActionResult Create()
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            UpdateData();               
            return View();
        } 

        //
        // POST: /Agendamento/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Models.AgendamentoSet pAgendamento)
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            bool encontrou = false;
            foreach (KeyValuePair<int, string> medico in SolicitadorServiços.AccessRH_MedicoEspecialidade(0, DateTime.Now))
            {
                if (medico.Value == pAgendamento.Medico_Nome)
                {
                    pAgendamento.Medico_Id = medico.Key;
                    encontrou = true;
                    break;
                }
            }
            if (!encontrou)
            {
                //TODO Implementar tratamento do erro
                return RedirectToAction("Index");
            }
            
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
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            UpdateData();
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();            
            // ================================
            // mantém o correto pré-selecionado
            SelectList listaPacientes = (SelectList)ViewData["Pacientes"];
            foreach (SelectListItem pac in listaPacientes)
            {
                if (Convert.ToInt32(pac.Value) == id)
                {                    
                }                
            }
            // ================================            
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.AgendamentoSet agendamento)
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            bool encontrou = false;
            foreach (KeyValuePair<int, string> medico in SolicitadorServiços.AccessRH_MedicoEspecialidade(0, DateTime.Now))
            {
                if (medico.Value == agendamento.Medico_Nome)
                {
                    agendamento.Medico_Id = medico.Key;
                    encontrou = true;
                    break;
                }
            }
            if (!encontrou)
            {
                //TODO Implementar tratamento do erro
                return RedirectToAction("Index");
            }
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
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            var agendamento = (from ag in entities.AgendamentoSets where ag.Id == id select ag).First();
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Delete/5

        [HttpPost]
        public ActionResult Delete(Models.AgendamentoSet pAgendamento)
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
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
            List<String> listaEspecialidades = new List<string>();
            // Especialidades
            foreach (KeyValuePair<int, string> especialidade in SolicitadorServiços.AccessRH_Especialidade())
            {
                listaEspecialidades.Add(especialidade.Value);
            }
            
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
            List<string> listaMedicos = new List<string>();
            foreach (KeyValuePair<int, string> medico in SolicitadorServiços.AccessRH_MedicoEspecialidade(0, DateTime.Now))
            {
                listaMedicos.Add(medico.Value);
            }
            List<SelectListItem> medicos = new List<SelectListItem>();
            foreach (string med in listaMedicos)
            {
                medicos.Add(new SelectListItem
                {
                    Text = med,                    
                });
            }
            medicos.Add(new SelectListItem
            {
                Text = "José Piccina",
            });
            medicos.Add(new SelectListItem
            {
                Text = "Carlos Gomes",
            });
            ViewData["Medico_Nome"] = medicos;
        }
    }
}
