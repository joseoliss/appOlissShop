using appOlissShop.DTO;
using appOlissShop.UI.Servicios.Contrato;
using System.Net.Http.Json;

namespace appOlissShop.UI.Servicios.Implementacion
{
    public class DashBoardServicio : IDashBoardServicio
    {
        private readonly HttpClient _httpClient;

        public DashBoardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen(VentaDTO modelo)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resumen");
        }

    }
}
