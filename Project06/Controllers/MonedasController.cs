using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class MonedasController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Monedas
        [ValidarSesionFilter]
        public ActionResult Monedas()
        {
            return View();
        }

        [ValidarSesionFilter]
        public ActionResult MonedasLista()
        {
            List<sp_RetornaMoneda_Result> modeloVista = new List<sp_RetornaMoneda_Result>();
            modeloVista = this.modeloBD.sp_RetornaMoneda().ToList();
            return View(modeloVista);
        }


        [ValidarSesionFilter]
        public ActionResult nuevoMoneda()
        {

            return View();
        }



        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult nuevoMoneda(sp_RetornaMoneda_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertMoneda(
                        modeloVista.nombre,
                        modeloVista.codigo,
                        modeloVista.tipoCambio);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro Insertado";
                }
                else
                {
                    resultado += "No se pudo insertar";
                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");

            return View();

        }

        public ActionResult MonedasModifica(int id_moneda)
        {
            sp_RetornaMonedaID_Result modeloVista = new sp_RetornaMonedaID_Result();
            modeloVista = this.modeloBD.sp_RetornaMonedaID(id_moneda).FirstOrDefault();
            return View(modeloVista);
        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult MonedasModifica(sp_RetornaMonedaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_UpdateMoneda(
                   modeloVista.id_moneda,
                   modeloVista.nombre,
                   modeloVista.codigo,
                   modeloVista.tipoCambio);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                    resultado = "Registro modificado";
                else
                    resultado = "No se pudo modificar";


            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            return View(modeloVista);

        }

        public ActionResult MonedasElimina(int id_moneda)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_TipoCiente
            sp_RetornaMonedaID_Result modeloVista = new sp_RetornaMonedaID_Result();
            modeloVista = this.modeloBD.sp_RetornaMonedaID(id_moneda).FirstOrDefault();

            return View(modeloVista);


        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult MonedasElimina(sp_RetornaMonedaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_DeleteMoneda(modeloVista.id_moneda);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error:" + error.Message;

            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                    resultado = "Registro eliminado";
                else
                {
                    resultado += "No se pudo eliminar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }


    }
}
