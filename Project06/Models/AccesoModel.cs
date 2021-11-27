using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project06.Models
{
    public class AccesoModel
    {
        //Este modelo contiene los datos del los usuarios 
            public string usuario { get; set; }

            public DateTime ultimoIngreso { get; set; }

            public string NombreCompleto { get; set; }

            public int id_tipoUsuario { get; set; }

            public int clave { get; set; }

            public int id_Cliente { get; set; }

    }



}
