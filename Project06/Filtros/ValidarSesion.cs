using Project06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project06.Filtros
{
    public class ValidarSesionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var sesion = (AccesoModel)HttpContext.Current.Session["Usuario"];


            if (sesion == null)
            {
                filterContext.HttpContext.Response.Redirect("~/InicioSesion/Autenticacion");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}