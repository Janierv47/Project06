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
    
    public partial class tblTipoMovimiento
    {
        public tblTipoMovimiento()
        {
            this.tblMovimiento = new HashSet<tblMovimiento>();
        }
    
        public int id_tipoMovimiento { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<tblMovimiento> tblMovimiento { get; set; }
    }
}
