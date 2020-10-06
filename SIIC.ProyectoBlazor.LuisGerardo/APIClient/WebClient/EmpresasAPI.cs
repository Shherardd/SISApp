using Newtonsoft.Json;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace SIIC.ProyectoBlazor.LuisGerardo.APIClient.WebClient
{
    public class EmpresasAPI:HttpClient
    {
        public EmpresasAPI(String urlServer)
        {
            urlServer += (urlServer.EndsWith('/')) ? "api/Empresas/" : "/api/Empresas/";

            BaseAddress = new Uri(urlServer);
        }
        public async Task<List<EmpresasModel>> ObtenerEmpresasAsync()
        {
            try
            {
                List<EmpresasModel> Lista = new List<EmpresasModel>();
                Lista = await this.GetFromJsonAsync<List<EmpresasModel>>("ObtenerEmpresas");

                var Lista2 = Lista;



                return Lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpresasModel>();
                throw;
            }
        }
    }
}
