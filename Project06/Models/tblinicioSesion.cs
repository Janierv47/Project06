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
    
    public partial class tblinicioSesion
    {
        public int id_inicioSesion { get; set; }
        public string usuario { get; set; }
        public int contraseña { get; set; }
        public System.DateTime ultimoIngreso { get; set; }
        public int id_tipoUsuario { get; set; }
    
        public virtual tblTipoUsuario tblTipoUsuario { get; set; }
    }
}
