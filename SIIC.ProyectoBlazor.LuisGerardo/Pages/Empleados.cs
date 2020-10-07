using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using SIIC.ProyectoBlazor.LuisGerardo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.Pages
{
    public partial class Empleados
    {
        protected override async Task OnInitializedAsync()
        {
            await ObtenerEmpleados();
        }
        [Inject]
        private EmpleadosBL EmpleadosBL { get; set; }
        [Parameter]
        public List<EmpleadosModel> listaEmpleados { get; set; } = new List<EmpleadosModel>();
        [Parameter]
        public EmpleadosModel empleado { get; set; } = new EmpleadosModel();
        public async Task ObtenerEmpleados()
        {
            listaEmpleados = await EmpleadosBL.ObtenerEmpleadosAsync();
        }
            
    }
}
