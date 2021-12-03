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
                ViewBag.ListaCuentaDestino = this.modeloBD.sp_RetornaCuentas().ToList();
            }

            AgregaMonedaViewBag();
            return View("nuevaTransferencia");
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
        public ActionResult nuevaTransferencia(double monto, int id_cuentaOrigen, int id_cuentaDestino)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            DateTime fechaTransferencia = DateTime.Now;

            AccesoModel persona = null;

            if (Session["Usuario"] != null)
            {
                persona = (AccesoModel)Session["Usuario"];


                ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
                ViewBag.ListaCuentaDestino = this.modeloBD.sp_RetornaCuentas().ToList();
            }


            try
            {

                cantRegistrosAfectados =
             this.modeloBD.sp_Transferencias(monto, id_cuentaOrigen, id_cuentaDestino, fechaTransferencia);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
            
                var infoCuentaOrg = this.modeloBD.sp_RetornaCuentaID(id_cuentaOrigen).FirstOrDefault();
                var moned = this.modeloBD.sp_RetornaMonedaID(infoCuentaOrg.id_moneda).FirstOrDefault();
                var infoCuentaDest = this.modeloBD.sp_RetornaCuentaID(id_cuentaDestino).FirstOrDefault();

                if (cantRegistrosAfectados > 0)
                {
                    resultado = "La transferencia se realizo exitosamente";

                    Correo.EnviarCorreo("Estimado " + infoCuentaOrg.primerApellido + " " + infoCuentaOrg.segundoApellido + " " + infoCuentaOrg.nombre + " usted a realizado una tranferencia de "+ moned.codigo + monto + " de la cuenta "+ infoCuentaOrg.numeroCuenta +" a la cuenta "+ infoCuentaDest.numeroCuenta + " del usuario " + infoCuentaDest.primerApellido + " " + infoCuentaDest.segundoApellido + " " + infoCuentaDest.nombre, "Gracias por usar nuestros servicios.", "ryvqsd@gmail.com");
                    Correo.EnviarCorreo("Estimado " + infoCuentaDest.primerApellido + " " + infoCuentaDest.segundoApellido + " " + infoCuentaDest.nombre + " usted a recibido una tranferencia de " + moned.codigo + monto + " de la cuenta " + infoCuentaOrg.numeroCuenta + " del usuario " + infoCuentaOrg.primerApellido + " " + infoCuentaOrg.segundoApellido + " " + infoCuentaOrg.nombre + " a la cuenta " + infoCuentaDest.numeroCuenta, "Gracias por usar nuestros servicios.", "ryvqsd@gmail.com");
                }


                else
                {
                    ///Las restricciones se realizaron en el procedimiento almacenado sp_Transferencias, por lo tanto este es el mensaje de restricción
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