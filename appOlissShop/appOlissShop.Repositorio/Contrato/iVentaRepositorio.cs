using appOlissShop.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Repositorio.Contrato
{
    public interface iVentaRepositorio : iGenericoReporitorio<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
