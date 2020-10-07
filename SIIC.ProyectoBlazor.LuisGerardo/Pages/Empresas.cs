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
        [Inject]
        private EmpresasBL EmpresasBL { get; set; }

        public async Task ObtenerEmpresas()
        {
            listaEmpresas = await EmpresasBL.ObtenerEmpresasAsync();
        }

        public async Task agregarEmpresa()
        {
            await EmpresasBL.AgregarEmpresasAsync(Empresa);
        }

        public void autoCompletar(EmpresasModel empresa) {
            Empresa = empresa;
        }

        public void nuevaEmpresa() {
            Empresa = new EmpresasModel();
        }

        public void switchModal() {
            isOpen = !isOpen;
        }
    }
}
