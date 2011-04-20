using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Agendamento.Controllers
{
    public class AgendaController : Controller
    {
        Models.erp_agendamentoEntities entities = new Models.erp_agendamentoEntities();

        //
        // GET: /Agenda/

        public ActionResult Index()
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            ViewData["Medicos"] = (from agendamento in entities.AgendamentoSets group agendamento by agendamento.Medico_Id into medicos select medicos).ToList();
            return View();
        }

        //
        // GET: /Agenda/Details/5

        public ActionResult Details(int id)
        {
            if ((string)Session["logged"] == "")
                return RedirectToAction("Logon", "Account");
            ERP.Agendamento.Dados.GerenciadorRelatórios.AgendaMédica agenda = new ERP.Agendamento.Dados.GerenciadorRelatórios.AgendaMédica(id, 6);
            ViewData["Agendamentos"] = agenda.Agenda;
            return View();
        }
    }
}
