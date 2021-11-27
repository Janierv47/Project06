using Project06.Filtros;
using Project06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using System.IO;  
using System.Net;  
using System.Net.Mail;


namespace Project06.Controllers
{
    
    public class DepositoController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Deposito
        [ValidarSesionFilter]
        public ActionResult Deposito()
        {
            return View();
        }

        /// <summary>
        /// Se muestran los datos del formulario del deposito
        /// </summary>
        /// <returns></returns>

        [ValidarSesionFilter]
        public ActionResult nuevoDeposito()
        {

                AccesoModel persona = null;

                if (Session["Usuario"] != null)
                {
                    persona = (AccesoModel)Session["Usuario"];

                   
                        ViewBag.ListaCuenta = this.modeloBD.sp_CuentasUsuario(persona.id_Cliente).ToList();
                }

            AgregaMonedaViewBag();
            return View("nuevoDeposito", ViewBag.ListaCuenta);
        }

        /// <summary>
        /// Se procesan los datos del método nuevoDeposito
        /// </summary>
        /// <param name="id_moneda"></param>
        /// <param name="id_cuenta"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        [ValidarSesionFilter]
        [HttpPost]
        public ActionResult nuevoDeposito(int id_moneda, int id_cuenta, double monto) 
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            int id_TipoMovimiento = 1;
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
                     this.modeloBD.sp_Deposito(id_TipoMovimiento, id_cuenta, monto, fechaDelMovimiento, id_moneda);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Depósito realizado correctamente";

                    Correo.EnviarCorreo(resultado, "Gracias por usar nuestros servicios", "jvalverdea338@castrocarazo.ac.cr");

                }
            

                else
                {
                    ///Las restricciones se realizaron en el procedimiento almacenado sp_Deposito, por lo tanto este es el mensaje de restricción
                    resultado += "No se pudo realizar el déposito, compruebe que el monto sea válido e intente nuevamente";
                    
                   
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
