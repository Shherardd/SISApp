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
                return Lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpresasModel>();
                throw;
            }
        }

        public async Task<bool> AgregarEmpresasAsync(EmpresasModel empresa) {
            try {                
                var resultado = await this.PostAsJsonAsync("GuardarEmpresa", empresa);
                if (resultado.IsSuccessStatusCode) {
                    var httpRes = resultado.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<bool>(httpRes);
                    return res;
                }
                return false;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> actualizarEmpresasAsync(EmpresasModel empresa) 
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("ActualizarEmpresa", empresa);
                if (resultado.IsSuccessStatusCode)
                {
                    var httpRes = resultado.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<bool>(httpRes);
                    return res;
                } return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }           
        }

        public async Task<bool> eliminarEmpresasAsync(Guid idEmpresa) {
            try
            {
                var resultado = await this.PostAsJsonAsync("EliminarEmpresa", idEmpresa);
                if (resultado.IsSuccessStatusCode)
                {
                    var httpRes = resultado.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<bool>(httpRes);
                    return res;
                }return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
    }
}
