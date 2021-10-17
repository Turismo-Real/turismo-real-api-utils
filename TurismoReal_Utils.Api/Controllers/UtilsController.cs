using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        
        [HttpGet]
        [Route("pais")]
        public async Task<List<string>> GetPaises()
        {
            List<string> paises = await _utilsRepository.GetPaises();
            return paises;
        }

        // GET: /api/v1/utils/region
        
        [HttpGet]
        [Route("region")]
        public async Task<List<string>> GetRegiones()
        {
            List<string> regiones = await _utilsRepository.GetRegiones();
            return regiones;
        }

        [HttpGet]
        [Route("comuna")]
        // GET: /api/v1/comuna
        public async Task<List<string>> GetComunasByRegion([FromBody] Region region)
        {
            List<string> comunas = await _utilsRepository.GetComunasByRegion(region);
            if (comunas.Count == 0)
            {
                comunas.Add("No hay comunas para la región especificada.");
            }
                
            return comunas;
        }

    }
}
