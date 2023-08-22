using appOlissShop.DTO;
using appOlissShop.Model.DbModels;
using appOlissShop.Repositorio.Contrato;
using appOlissShop.Servicio.Contrato;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Servicio.Implementacion
{
    public class DashboardServicio : iDashboardService
    {
        private readonly iGenericoReporitorio<Venta> _ventaRepositorio;
        private readonly iGenericoReporitorio<Usuario> _usuarioRepositorio;
        private readonly iGenericoReporitorio<Producto> _productoRepositorio;
        private readonly IMapper _mapper;

        public DashboardServicio(
            iGenericoReporitorio<Venta> ventaRepositorio,
            iGenericoReporitorio<Usuario> usuarioRepositorio,
            iGenericoReporitorio<Producto> productoRepositorio,
            IMapper mapper
            )
        {
            _ventaRepositorio = ventaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public string GetIngresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return ingresos.ToString();
        }

        public int GetVentas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int ingresos = consulta.Count();
            return ingresos;
        }

        public int GetClientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        public int GetProductos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO tdo = new DashboardDTO()
                {
                    TotalIngresos = GetIngresos(),
                    TotalVentas = GetVentas(),
                    TotalCliente = GetClientes(),
                    TotalProductos = GetProductos(),
                };

                return tdo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
