using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class InicioClienteController : Controller
    {
        // GET: InicioCliente
        public ActionResult ClienteInicio()
        {
            return View();
        }
    }
}