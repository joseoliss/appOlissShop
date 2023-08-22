using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using appOlissShop.Model;
using appOlissShop.Repositorio.Contrato;
using appOlissShop.DTO;
using appOlissShop.Servicio.Contrato;
using AutoMapper;
using appOlissShop.Model.DbModels;

namespace appOlissShop.Servicio.Implementacion
{
    public class VentaServicio : iVentaServicio
    {
        private readonly iVentaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public VentaServicio(iVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _modeloRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo registrar.");

                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
