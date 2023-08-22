using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using appOlissShop.Servicio.Contrato;
using appOlissShop.DTO;

namespace appOlissShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly iProductoServicio _servicio;

        public ProductoController(iProductoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("Lista/{buscar:alpha}")]
        public async Task<IActionResult> Lista(string buscar = "N/A")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "N/A") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _servicio.List(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "N/A")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "N/A") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _servicio.List(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicio.Eliminar(Id);
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
