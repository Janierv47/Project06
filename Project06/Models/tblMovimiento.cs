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
    
    public partial class tblMovimiento
    {
        public int id_movimiento { get; set; }
        public double monto { get; set; }
        public System.DateTime fechaDelMovimiento { get; set; }
        public int id_cuenta { get; set; }
        public int id_tipoMovimiento { get; set; }
    
        public virtual tblCuenta tblCuenta { get; set; }
        public virtual tblTipoMovimiento tblTipoMovimiento { get; set; }
    }
}