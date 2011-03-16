using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Agendamento.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "ERP Clínica Médica - Módulo de Agendamento";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
