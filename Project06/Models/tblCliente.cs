//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project06.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCliente
    {
        public tblCliente()
        {
            this.tblCuenta = new HashSet<tblCuenta>();
            this.tblinicioSesion = new HashSet<tblinicioSesion>();
        }
    
        public int id_cliente { get; set; }
        public int id_tipoCliente { get; set; }
        public int cedula { get; set; }
        public string genero { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombre { get; set; }
        public string direccionFisica { get; set; }
        public string telefonoPrincipal { get; set; }
        public string telefonoSecundario { get; set; }
        public string correo { get; set; }
    
        public virtual tblTipoCliente tblTipoCliente { get; set; }
        public virtual ICollection<tblCuenta> tblCuenta { get; set; }
        public virtual ICollection<tblinicioSesion> tblinicioSesion { get; set; }
    }
}
