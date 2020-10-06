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
        protected override async Task OnInitializedAsync() {
            await ObtenerEmpresas();
        }
        [Parameter]
        public List<EmpresasModel> listaEmpresas { get; set; } = new List<EmpresasModel>();

        [Inject]
        private EmpresasBL EmpresasBL { get; set; }

        public async Task ObtenerEmpresas() {
            listaEmpresas = await EmpresasBL.ObtenerEmpresasAsync();
        }
    }
}
