using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class TipoClienteController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();
        // GET: RegistroTipoCliente
        [ValidarSesionFilter]
        public ActionResult TipoCliente()
        {
            return View();
        }

        [ValidarSesionFilter]
        public ActionResult TipoClienteLista()
        {
            List<sp_RetornaTipoCliente_Result> modeloVista = new List<sp_RetornaTipoCliente_Result>();
            modeloVista = this.modeloBD.sp_RetornaTipoCliente("", "").ToList();
            return View(modeloVista);
        }


        [ValidarSesionFilter]
        public ActionResult nuevoTipoCliente() { 
       
            return View();
        }

       

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult nuevoTipoCliente(sp_RetornaTipoCliente_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertTipoCliente(
                        modeloVista.nombre,
                        modeloVista.descripcion);
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
            Response.Write("<script language=javascript>alert('" +resultado+ "')</script>");

            return View();

        }

        public ActionResult TipoClienteModifica(int id_tipoCliente)
        {
            sp_RetornaTipoClienteID_Result modeloVista = new sp_RetornaTipoClienteID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoClienteID(id_tipoCliente).FirstOrDefault();
            return View(modeloVista);
        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult TipoClienteModifica(sp_RetornaTipoClienteID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_UpdateTipoCliente(
                   modeloVista.id_tipoCliente,
                   modeloVista.nombre,
                   modeloVista.descripcion);
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

        public ActionResult TipoClienteElimina(int id_TipoCliente)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_TipoCiente
            sp_RetornaTipoClienteID_Result modeloVista = new sp_RetornaTipoClienteID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoClienteID(id_TipoCliente).FirstOrDefault();
            
            return View(modeloVista);


        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult TipoClienteElimina(sp_RetornaTipoClienteID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_DeleteTipoCliente(modeloVista.id_tipoCliente);
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

