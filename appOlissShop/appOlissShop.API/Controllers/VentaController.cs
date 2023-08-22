using appOlissShop.DTO;
using appOlissShop.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appOlissShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly iVentaServicio _servicio;

        public VentaController(iVentaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("Registrar")]
        public async Task<IActionResult> Editar([FromBody] VentaDTO modelo)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicio.Registrar(modelo);
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
