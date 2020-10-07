using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.BL
{
    public class EmpresasBL
    {
        EmpresasAPI empresasAPI;
        public EmpresasBL(EmpresasAPI _EmpresasAPI)
        {
            this.empresasAPI = _EmpresasAPI;
        }

        public async Task<List<EmpresasModel>> ObtenerEmpresasAsync() {
            var empresas = await empresasAPI.ObtenerEmpresasAsync();
            return empresas;
        }

        public async Task<bool> AgregarEmpresasAsync(EmpresasModel empresa) {
            var agrego = await empresasAPI.AgregarEmpresasAsync(empresa);
            return agrego;
        }

        public async Task<bool> ActualizarEmpresasAsync(EmpresasModel empresa)
        {
            var actualizo = await empresasAPI.actualizarEmpresasAsync(empresa);
            return actualizo;
        }

        public async Task<bool> EliminarEmpresasAsync(EmpresasModel empresa)
        {
            var elimino = await empresasAPI.eliminarEmpresasAsync(empresa.Id);
            return elimino;
        }

    }
}
