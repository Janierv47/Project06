using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project06.Filtros;
using Project06.Models;

namespace Project06.Controllers
{
    public class InicioSesionController : Controller
    {
        //Acción inicial del programa
        // GET: InicioSesion
        public ActionResult Autenticacion()
        {
            return View("Autenticacion");
        }



        //Acción para loguearse
        [HttpPost]
        public ActionResult Acceso(AccesoModel Modelo)
        {
            try
            {
                //Validación del modelo

                AccesoModel consulta = null;

                using (proyecto06Entities BD = new proyecto06Entities())
                {

                    consulta = (from d in BD.sp_AutenticacionUsuario(Modelo.usuario, Modelo.clave)
                                select new AccesoModel
                                {
                                    usuario = d.usuario,
                                    clave = d.clave,
                                    ultimoIngreso = d.ultimoIngreso,
                                    NombreCompleto = d.NombreCompleto,
                                    id_tipoUsuario = d.TipoDeUsuario,
                                    id_Cliente = d.idCliente
                                }
                                ).FirstOrDefault();


                    //Variable de sesión
                    Session["Usuario"] = consulta;


                    if (consulta != null)
                    {

                        if (consulta.id_tipoUsuario == 1)
                        {
                            return RedirectToAction("Colaborador", "InicioColaborador");
                        }
                        else if (consulta.id_tipoUsuario == 2)
                        {
                            return RedirectToAction("ClienteInicio", "InicioCliente");
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "El usuario o contraseña son incorrectos";
                    }
                    return View("Autenticacion", Modelo);
                }
            }
            catch (Exception)
            {
                return View("_Error");
            }
        }
        //Final de acción para el tipo de usuario


        //Acción para salir del sistema
        [ValidarSesionFilter]
        [HttpGet]
        public ActionResult Salir()
        {
            try
            {
                Session.RemoveAll();
                return RedirectToAction("Autenticacion", "InicioSesion");
            }
            catch (Exception)
            {

                return View("_Error");
            }


        }

        //Final de acción para salir del sistema

    }
}
     
