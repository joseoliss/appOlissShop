using appOlissShop.DTO;

namespace appOlissShop.UI.Servicios.Contrato
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
