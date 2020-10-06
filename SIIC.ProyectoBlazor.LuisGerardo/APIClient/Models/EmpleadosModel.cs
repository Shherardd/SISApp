using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models
{
    public class EmpleadosModel
    {
        public Guid Id { get; set; }
        public Guid IdSucursal { get; set; }
        public String Rfc { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }

    }
}
