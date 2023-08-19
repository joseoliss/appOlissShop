using appOlissShop.Model.DbModels;
using appOlissShop.Repositorio.Contrato;
using appOlissShop.Repositorio.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, iVentaRepositorio
    {
        private readonly DbEcommerceContext _dbContext;

        public VentaRepositorio(DbEcommerceContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaccion = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;
                    transaccion.Commit();
                }
                catch 
                {
                    transaccion.Rollback();
                    throw;
                }
            }

            return ventaGenerada;
        }
    }
}
