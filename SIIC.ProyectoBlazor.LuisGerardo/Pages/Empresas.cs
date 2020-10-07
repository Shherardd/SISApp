using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using SIIC.ProyectoBlazor.LuisGerardo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.Pages
{
    public partial class Empresas
    {
        protected override async Task OnInitializedAsync()
        {
            await ObtenerEmpresas();
        }
        [Parameter]
        public List<EmpresasModel> listaEmpresas { get; set; } = new List<EmpresasModel>();
        [Parameter]
        public EmpresasModel Empresa { get; set; } = new EmpresasModel();
        [Parameter]
        public bool isOpen { get; set; }
        [Parameter]
        public String accion { get; set; }
        [Inject]
        private EmpresasBL EmpresasBL { get; set; }

        public async Task ObtenerEmpresas()
        {
            listaEmpresas = await EmpresasBL.ObtenerEmpresasAsync();
        }

        public async Task agregarEmpresa()
        {
            //Empresa.IdSucursal = new Guid();
            await EmpresasBL.AgregarEmpresasAsync(Empresa);
        }

        private async Task ActualizarEmpresa()
        {
            await EmpresasBL.ActualizarEmpresasAsync(Empresa);
            await ObtenerEmpresas();
        }

        private async Task eliminarEmpresa(EmpresasModel empresa)
        {
            await EmpresasBL.EliminarEmpresasAsync(empresa);
            await ObtenerEmpresas();
        }

        public void autoCompletar(EmpresasModel empresa) {
            Empresa = empresa;
        }

        public void nuevaEmpresa() {
            Empresa = new EmpresasModel();
            isOpen = true;
            accion = "agregar";
        }

        public void switchModal() {
            isOpen = !isOpen;
        }
    }
}
