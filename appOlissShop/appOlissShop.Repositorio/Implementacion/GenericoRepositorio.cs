using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using appOlissShop.Repositorio.Contrato;
using appOlissShop.Repositorio.DBContext;

namespace appOlissShop.Repositorio.Implementacion
{
    public class GenericoRepositorio<T> : iGenericoReporitorio<T> where T : class
    {
        private readonly DbEcommerceContext _dbContext;

        public GenericoRepositorio(DbEcommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> consulta = (filtro == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filtro);
            return consulta;
        }

        public async Task<T> Crear(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Editar(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Eliinar(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
