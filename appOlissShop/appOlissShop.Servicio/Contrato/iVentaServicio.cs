﻿using appOlissShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Servicio.Contrato
{
    public interface iVentaServicio
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);
    }
}
