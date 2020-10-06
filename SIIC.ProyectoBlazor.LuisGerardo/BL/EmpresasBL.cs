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
    }
}
