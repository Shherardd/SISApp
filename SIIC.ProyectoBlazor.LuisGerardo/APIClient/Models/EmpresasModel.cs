using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models
{
    public class EmpresasModel
    {
        public Guid Id { get; set; }
        public Guid? IdSucursal { get; set; }
        public String Rfc { get; set; }
        public String RazonSocial { get; set; }
        public String NombreComercial { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
    }
}
