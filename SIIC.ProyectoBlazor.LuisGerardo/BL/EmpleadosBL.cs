using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.BL
{
    public class EmpleadosBL
    {
        EmpleadosAPI empleadosAPI;
        public EmpleadosBL(EmpleadosAPI _EmpleadosAPI)
        {
            this.empleadosAPI = _EmpleadosAPI;
        }

        public async Task<List<EmpleadosModel>> ObtenerEmpleadosAsync() {
            var empleados = await empleadosAPI.ObtenerEmpleadosAsync();
            return empleados;
        }

        public async Task<bool> AgregarEmpleadosAsync(EmpleadosModel empleado)
        {
            var agrego = await empleadosAPI.agregarEmpleadoAsync(empleado);
            return agrego;
        }

        public async Task<bool> ActualizarEmpleadosAsync(EmpleadosModel empleado)
        {
            var actualizo = await empleadosAPI.agregarEmpleadoAsync(empleado);
            return actualizo;
        }

        public async Task<bool> EliminarEmpleadosAsync (EmpleadosModel empleado)
        {
            var elimino = await empleadosAPI.eliminarEmpleadoAsync(empleado.Id);
            return elimino;
        }
    }
}
