using Newtonsoft.Json;
using SIIC.ProyectoBlazor.LuisGerardo.APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisGerardo.APIClient.WebClient
{
    public class EmpleadosAPI:HttpClient
    {
        public EmpleadosAPI(String urlServer)
        {
            urlServer += (urlServer.EndsWith('/')) ? "api/Empleados/" : "/api/Empleados/";
            BaseAddress = new Uri(urlServer);
        }

        public async Task<List<EmpleadosModel>> ObtenerEmpleadosAsync() {
            try
            {
                List<EmpleadosModel> Lista = new List<EmpleadosModel>();
                Lista = await this.GetFromJsonAsync<List<EmpleadosModel>>("ObtenerEmpleados");
                return Lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EmpleadosModel>();
                throw;
            }
        }

        public async Task<bool> AgregarEmpleadoAsync(EmpleadosModel empleado) {
            try
            {
                var resultado = await this.PostAsJsonAsync("GuardarEmpleado", empleado);
                if (resultado.IsSuccessStatusCode)
                {
                    return true;
                } return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> ActualizarEmpleadoAsync(EmpleadosModel empleado)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("ActualizarEmpleado", empleado);
                if (resultado.IsSuccessStatusCode) {
                    var httpRes = resultado.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<bool>(httpRes);
                    return res;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public async Task<bool> EliminarEmpleadoAsync(Guid idEmpleado) {
            try
            {
                var resultado = await this.PostAsJsonAsync("EliminarEmpleado", idEmpleado);
                if (resultado.IsSuccessStatusCode) {
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
