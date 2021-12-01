using Project06.Filtros;
using Project06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project06.Controllers
{
    public class TransferenciaController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Transferencia
        public ActionResult Transferencia()
        {
            return View();
        }


        /// <summary>
        /// Se muestran los datos del formulario de la transferencia
        /// </summary>
        /// <returns></returns>

        [ValidarSesionFilter]
        public ActionResult nuevaTransferencia()
        {

            AccesoModel persona = null;

            if (Session["Usuario"] != null)
            {
                persona = (AccesoModel)Session["Usuario"];


                ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
            }

            AgregaMonedaViewBag();
            return View("nuevaTransferencia", ViewBag.ListaCuenta);
        }



        /// <summary>
        /// Se procesan los datos del método nuevaTransferencia
        /// </summary>
        /// <param name="id_moneda"></param>
        /// <param name="id_cuenta"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        [ValidarSesionFilter]
        [HttpPost]
        public ActionResult nuevaTransferencia(double monto, int id_cuentaOrigen, int id_cuentaDestino, int id_moneda)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            DateTime fechaTransferencia = DateTime.Now;

            AccesoModel persona = null;

            if (Session["Usuario"] != null)
            {
                persona = (AccesoModel)Session["Usuario"];


                ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
            }

            else 
            {
                ViewBag.ListaCuentaDestino = this.modeloBD.sp_CuentasDestino(persona.id_Cliente).ToList();
            }



            try
            {

                cantRegistrosAfectados =
             this.modeloBD.sp_Transferencias(monto, id_cuentaOrigen, id_cuentaDestino, fechaTransferencia, id_moneda);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                var moned = this.modeloBD.sp_RetornaMonedaID(id_moneda).FirstOrDefault();

                if (cantRegistrosAfectados > 0)
                {
                    resultado = "<p>Su transferencia de " + moned.codigo + monto + " fue éxitoso a nombre de <b> " + persona.NombreCompleto + "</b> </p>";

                    Correo.EnviarCorreo(resultado, "Gracias por usar nuestros servicios.", "jvalverdea338@castrocarazo.ac.cr");

                }


                else
                {
                    ///Las restricciones se realizaron en el procedimiento almacenado sp_Deposito, por lo tanto este es el mensaje de restricción
                    resultado += "No se pudo realizar la transferencia, compruebe que el monto sea válido e intente nuevamente";


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