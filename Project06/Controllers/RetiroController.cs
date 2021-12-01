using Project06.Filtros;
using Project06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project06.Controllers
{
    public class RetiroController : Controller
    {

        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Retiro
        public ActionResult Retiro()
        {
            return View();
        }

        /// <summary>
        /// Se muestran los datos del formulario del retiro
        /// </summary>
        /// <returns></returns>

        [ValidarSesionFilter]
        public ActionResult nuevoRetiro()
        {

            AccesoModel persona = null;

            if (Session["Usuario"] != null)
            {
                persona = (AccesoModel)Session["Usuario"];


                ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
            }

            AgregaMonedaViewBag();
            return View("nuevoRetiro", ViewBag.ListaCuenta);
        }



        /// <summary>
        /// Se procesan los datos del método nuevoRetiro
        /// </summary>
        /// <param name="id_moneda"></param>
        /// <param name="id_cuenta"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        [ValidarSesionFilter]
        [HttpPost]
        public ActionResult nuevoRetiro(int id_moneda, int id_cuenta, double monto)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            //int id_TipoMovimiento = 1;
            DateTime fechaDelMovimiento = DateTime.Now;

            AccesoModel persona = null;

            if (Session["Usuario"] != null)
            {
                persona = (AccesoModel)Session["Usuario"];


                ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
            }

            try
            {

                cantRegistrosAfectados =
             this.modeloBD.sp_Retiro(id_cuenta, monto, fechaDelMovimiento, id_moneda);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Retiro realizado correctamente";

                    Correo.EnviarCorreo(resultado, "Gracias por usar nuestros servicios", "jvalverdea338@castrocarazo.ac.cr");

                }


                else
                {
                    ///Las restricciones se realizaron en el procedimiento almacenado sp_Retiro, por lo tanto este es el mensaje de restricción
                    resultado += "No se pudo realizar el retiro, el retiro no puede ser mayor al monto disponible en la cuenta";

                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            AgregaMonedaViewBag();
            return View();


        }


        void AgregaMonedaViewBag()
        {
            ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMoneda().ToList();
        }



    }
}