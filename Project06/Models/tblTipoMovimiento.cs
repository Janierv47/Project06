//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
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
