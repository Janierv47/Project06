using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class TipoCuentaController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();
        // GET: RegistroTipoCuenta
        [ValidarSesionFilter]
        public ActionResult TipoCuenta()
        {
            return View();
        }

        [ValidarSesionFilter]
        public ActionResult TipoCuentaLista()
        {
            List<sp_RetornaTipoCuenta_Result> modeloVista = new List<sp_RetornaTipoCuenta_Result>();
            modeloVista = this.modeloBD.sp_RetornaTipoCuenta().ToList();
            return View(modeloVista);
        }


        [ValidarSesionFilter]
        public ActionResult nuevoTipoCuenta()
        {

            return View();
        }



        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult nuevoTipoCuenta(sp_RetornaTipoCuenta_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertTipoCuenta(
                        modeloVista.nombre,
                        modeloVista.codigo);
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

        public ActionResult TipoCuentaModifica(int id_tipoCuenta)
        {
            sp_RetornaTipoCuentaID_Result modeloVista = new sp_RetornaTipoCuentaID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoCuentaID(id_tipoCuenta).FirstOrDefault();
            return View(modeloVista);
        }

        public ActionResult TipoClienteModifica(int id_tipoCliente)
        {
            sp_RetornaTipoClienteID_Result modeloVista = new sp_RetornaTipoClienteID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoClienteID(id_tipoCliente).FirstOrDefault();
            return View(modeloVista);
        }



        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult TipoCuentaModifica(sp_RetornaTipoCuentaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_UpdateTipoCuenta(
                   modeloVista.id_tipoCuenta,
                   modeloVista.nombre,
                   modeloVista.codigo);
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

        public ActionResult TipoCuentaElimina(int id_TipoCuenta)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_TipoCiente
            sp_RetornaTipoCuentaID_Result modeloVista = new sp_RetornaTipoCuentaID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoCuentaID(id_TipoCuenta).FirstOrDefault();

            return View(modeloVista);


        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult TipoCuentaElimina(sp_RetornaTipoCuentaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_DeleteTipoCuenta(modeloVista.id_tipoCuenta);
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