using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Entities;
using TurismoReal_Utils.Core.Interfaces;

namespace TurismoReal_Utils.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        private readonly IUtilsRepository _utilsRepository;
        private readonly string serviceName = "turismo_real_utils";

        public UtilsController(IUtilsRepository utilsRepository)
        {
            _utilsRepository = utilsRepository;
        }

        // GET: /api/v1/utils/pais
        [HttpGet("{pais}")]
        public async Task<List<string>> GetPaises()
        {
            List<string> paises = await _utilsRepository.GetPaises();
            return paises;
        }

        // GET: /api/v1/utils/region
        public async Task<List<object>> GetRegiones()
        {
            throw new NotImplementedException();
            //List<Region> regiones = await _utilsRepository.GetRegiones();
            //return regiones;
        }

        // GET: /api/v1/comuna/{region}
        public async Task<List<object>> GetComunasByRegion([FromBody] Region region)
        {
            throw new NotImplementedException();
            //List<Comuna> comunas = _utilsRepository.GetComunasByRegion(region);
            //return comunas;
        }

    }
}
