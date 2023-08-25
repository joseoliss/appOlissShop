using appOlissShop.DTO;

namespace appOlissShop.UI.Servicios.Contrato
{
    public interface IDashBoardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen(VentaDTO modelo);
    }
}
