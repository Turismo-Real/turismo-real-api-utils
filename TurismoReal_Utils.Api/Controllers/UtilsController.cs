using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Entities;
using TurismoReal_Utils.Core.Interfaces;
using TurismoReal_Utils.Core.Log;

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
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/utils/pais";
            DateTime startService = DateTime.Now;

            List<string> paises = await _utilsRepository.GetPaises();

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = paises;
            Console.WriteLine(log.parseJson());
            // LOG
            return paises;
        }

        // GET: /api/v1/utils/region
        [HttpGet]
        [Route("region")]
        public async Task<List<string>> GetRegiones()
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/utils/region";
            DateTime startService = DateTime.Now;

            List<string> regiones = await _utilsRepository.GetRegiones();

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = regiones;
            Console.WriteLine(log.parseJson());
            // LOG
            return regiones;
        }

        [HttpGet]
        [Route("comuna")]
        // GET: /api/v1/comuna
        public async Task<List<string>> GetComunasByRegion([FromBody] Region region)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/utils/region";
            DateTime startService = DateTime.Now;

            List<string> comunas = await _utilsRepository.GetComunasByRegion(region);
            if (comunas.Count == 0)
            {
                comunas.Add(null);
                comunas.Add("No hay comunas para la región especificada.");
            }

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = comunas;
            Console.WriteLine(log.parseJson());
            // LOG
            return comunas;
        }

    }
}
