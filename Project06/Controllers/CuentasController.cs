using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class CuentasController : Controller
    {
        proyecto06Entities modeloBD = new proyecto06Entities();

        // GET: Cuentas
        [ValidarSesionFilter]
        public ActionResult Cuentas()
        {
            return View();
        }

        [ValidarSesionFilter]
        public ActionResult CuentasLista()
        {
            List<sp_RetornaCuentas_Result> modeloVista = new List<sp_RetornaCuentas_Result>();
            modeloVista = this.modeloBD.sp_RetornaCuentas().ToList();
            return View(modeloVista);
        }

        [ValidarSesionFilter]
        public ActionResult nuevoCuentas()
        {
       
            ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMoneda().ToList();

            ViewBag.ListaTipoCuenta = this.modeloBD.sp_RetornaTipoCuenta().ToList();

            ViewBag.ListaIDClientes = this.modeloBD.sp_RetornaCliente().ToList();

            return View();
        }


        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult nuevoCuentas(sp_RetornaCuentas_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertCuenta(
                        modeloVista.numeroCuenta,
                        modeloVista.id_cliente,
                        modeloVista.id_tipoCuenta,
                        modeloVista.id_moneda,
                        modeloVista.saldo,
                        modeloVista.estado);
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

        public ActionResult CuentasModifica(int id_cuenta)
        {
            ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMoneda().ToList();

            ViewBag.ListaTipoCuenta = this.modeloBD.sp_RetornaTipoCuenta().ToList();

            ViewBag.ListaIDClientes = this.modeloBD.sp_RetornaCliente().ToList();

            sp_RetornaCuentaID_Result modeloVista = new sp_RetornaCuentaID_Result();
            modeloVista = this.modeloBD.sp_RetornaCuentaID(id_cuenta).FirstOrDefault();
            return View(modeloVista);
        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult CuentasModifica(sp_RetornaCuentaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_UpdateCuenta(
                   modeloVista.id_cuenta,
                   modeloVista.numeroCuenta,
                   modeloVista.id_cliente,
                   modeloVista.id_tipoCuenta,
                   modeloVista.id_moneda,
                   modeloVista.saldo,
                   modeloVista.estado);
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

        public ActionResult CuentasElimina(int id_cuenta)
        {
            ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMoneda().ToList();

            ViewBag.ListaTipoCuenta = this.modeloBD.sp_RetornaTipoCuenta().ToList();

            ViewBag.ListaIDClientes = this.modeloBD.sp_RetornaCliente().ToList();

            ViewBag.ListaCuentas = this.modeloBD.sp_RetornaCuentas().ToList();

            ///obtener el registro que se desea eliminar
            ///utilizando el parámetro del método id_cuenta
            sp_RetornaCuentaID_Result modeloVista = new sp_RetornaCuentaID_Result();
            modeloVista = this.modeloBD.sp_RetornaCuentaID(id_cuenta).FirstOrDefault();

            return View(modeloVista);


        }

        [HttpPost]
        [ValidarSesionFilter]
        public ActionResult CuentasElimina(sp_RetornaCuentaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_DeleteCuenta(modeloVista.id_cuenta);
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