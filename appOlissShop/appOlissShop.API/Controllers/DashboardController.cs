using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using appOlissShop.Servicio.Contrato;
using appOlissShop.DTO;
using appOlissShop.Servicio.Implementacion;

namespace appOlissShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly iDashboardService _servicio;

        public DashboardController(DashboardServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = _servicio.Resumen();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}
