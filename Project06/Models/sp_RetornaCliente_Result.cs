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
    
    public partial class sp_RetornaCliente_Result
    {
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
        public string nombreTipoCliente { get; set; }
    }
}
