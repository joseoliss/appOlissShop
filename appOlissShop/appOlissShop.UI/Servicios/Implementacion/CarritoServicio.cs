using Blazored.LocalStorage;
using Blazored.Toast;
using appOlissShop.DTO;
using appOlissShop.UI.Servicios.Contrato;
using Blazored.Toast.Services;

namespace appOlissShop.UI.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService   _toastService;

        public CarritoServicio(
            ILocalStorageService localStorageService,
            ISyncLocalStorageService syncLocalStorageService,
            IToastService toastService
        )
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;   
        }



        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if ( carrito == null )
                {
                    carrito = new List<CarritoDTO>();
                }

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == modelo.Producto.IdProducto);

                if (encontrado != null)
                {
                    carrito.Remove(encontrado);
                }

                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if (encontrado != null)
                {
                    _toastService.ShowSuccess("Producto actualizado");
                }
                else
                {
                    _toastService.ShowSuccess("Producto agregado");
                }

                MostrarItems.Invoke();
            }
            catch 
            {
                _toastService.ShowError("No se pudo agregar al carrito"); 
            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");

            return carrito == null ? 0 : carrito.Count();
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

            if (carrito == null)
            {
                carrito = new List<CarritoDTO>();
            }
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                if (carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if (elemento != null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }

                }


            }
            catch
            {

                throw;
            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}
