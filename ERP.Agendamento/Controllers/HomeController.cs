﻿using System;
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
            ViewData["Message"] = "Mensagem preparada programaticamente no controller.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}