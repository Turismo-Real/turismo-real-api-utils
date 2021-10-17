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
        Task<List<object>> GetRegiones();
        Task<List<object>> GetComunasByRegion(Region region);
    }
}
