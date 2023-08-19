using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Repositorio.Contrato
{
    public interface iGenericoReporitorio<T> where T : class
    {
        IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null);
        Task<T> Crear(T modelo);
        Task<bool> Editar(T modelo);
        Task<bool> Eliinar(T modelo);
    }
}
