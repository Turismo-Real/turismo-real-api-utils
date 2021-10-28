using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Entities;

namespace TurismoReal_Utils.Core.Interfaces
{
    public interface IUtilsRepository
    {
        Task<List<string>> GetPaises();
        Task<List<string>> GetRegiones();
        Task<List<string>> GetComunasByRegion(Region region);
        Task<List<string>> GetInstalaciones();
        Task<List<string>> GetTiposServicios();
        Task<List<string>> GetTiposDepto();
        Task<List<string>> GetEstadosDepto();
        Task<List<string>> GetEstadosReserva();
        Task<List<string>> GetTiposMantencion();
        Task<List<string>> GetEstadosMantencion();
        Task<List<string>> GetTiposGasto();
        Task<List<string>> GetTiposPago();
    }
}
