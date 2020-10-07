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
        [Parameter]
        public bool isOpen { get; set; }
        [Parameter]
        public string Accion { get; set; } = "";
        public async Task ObtenerEmpleados()
        {
            listaEmpleados = await EmpleadosBL.ObtenerEmpleadosAsync();
        }

        public async Task AgregarEmpleados() {
            await EmpleadosBL.AgregarEmpleadosAsync(empleado);
            NuevoEmpleado();
            await ObtenerEmpleados();
        }

        public async Task ActualizarEmpleado() {
            await EmpleadosBL.ActualizarEmpleadosAsync(empleado);
            await ObtenerEmpleados();
        }

        public async Task EliminarEmpleado(EmpleadosModel empleado) {
            await EmpleadosBL.EliminarEmpleadosAsync(empleado);
            await ObtenerEmpleados();
        }
        public void NuevoEmpleado()
        {
            empleado = new EmpleadosModel();
            isOpen = true;
            Accion = "Agregar";
        }
        public void AutoCompletar(EmpleadosModel emp)
        {
            empleado = emp;
            isOpen = true;
            Accion = "Editar";
        }

        public void nuevoEmpleado()
        {
            empleado = new EmpleadosModel();
            isOpen = true;
            Accion = "Agregar";
        }

        public async Task switchModal()
        {
            isOpen = !isOpen;
            await ObtenerEmpleados();
        }

    }
}
