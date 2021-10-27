using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Models;

namespace Project06.Controllers
{
    public class ClientesController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Clientes
        public ActionResult Clientes()
        {
            return View();
        }


        // GET: Monedas
       

        public ActionResult ClientesLista()
        {
            List<sp_RetornaCliente_Result> modeloVista = new List<sp_RetornaCliente_Result>();
            modeloVista = this.modeloBD.sp_RetornaCliente("", "", "", "").ToList();
            return View(modeloVista);
        }



        public ActionResult nuevoCliente()
        {

            return View();
        }



        [HttpPost]
        public ActionResult nuevoCliente(sp_RetornaCliente_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertCliente(
                       modeloVista.id_tipoCliente,
                       modeloVista.cedula,
                       modeloVista.genero,
                       modeloVista.fechaNacimiento,
                       modeloVista.primerApellido,
                       modeloVista.segundoApellido,
                       modeloVista.nombre,
                       modeloVista.direccionFisica,
                       modeloVista.telefonoPrincipal,
                       modeloVista.telefonoSecundario,
                       modeloVista.correo
                       );
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

        public ActionResult ClienteModifica(int id_cliente)
        {
            sp_RetornaClienteID_Result modeloVista = new sp_RetornaClienteID_Result();
            modeloVista = this.modeloBD.sp_RetornaClienteID(id_cliente).FirstOrDefault();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ClienteModifica(sp_RetornaClienteID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_UpdateCliente(
                   modeloVista.id_cliente,
                   modeloVista.id_tipoCliente,
                   modeloVista.cedula,
                   modeloVista.genero,
                   modeloVista.fechaNacimiento,
                   modeloVista.primerApellido,
                   modeloVista.segundoApellido,
                   modeloVista.nombre,
                   modeloVista.direccionFisica,
                   modeloVista.telefonoPrincipal,
                   modeloVista.telefonoSecundario,
                   modeloVista.correo);
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

        public ActionResult ClienteElimina(int id_cliente)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_TipoCiente
            sp_RetornaClienteID_Result modeloVista = new sp_RetornaClienteID_Result();
            modeloVista = this.modeloBD.sp_RetornaClienteID(id_cliente).FirstOrDefault();

            return View(modeloVista);


        }

        [HttpPost]
        public ActionResult ClienteElimina(sp_RetornaClienteID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_DeleteCliente(modeloVista.id_cliente);
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