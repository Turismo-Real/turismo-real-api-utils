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
        private LogModel log;

        public UtilsController(IUtilsRepository utilsRepository)
        {
            _utilsRepository = utilsRepository;
        }

        // GET: /api/v1/utils/pais
        [HttpGet]
        [Route("pais")]
        public async Task<List<string>> GetPaises()
        {
            log = new LogModel();
            log.InitLog(serviceName, "GET", "/api/v1/utils/pais", DateTime.Now);

            List<string> paises = await _utilsRepository.GetPaises();

            // LOG
            log.EndLog(DateTime.Now, 200, paises);
            Console.WriteLine(log.parseJson());
            // LOG
            return paises;
        }

        // GET: /api/v1/utils/region
        [HttpGet]
        [Route("region")]
        public async Task<List<string>> GetRegiones()
        {
            log = new LogModel();
            log.InitLog(serviceName, "GET", "/api/v1/utils/region", DateTime.Now);

            List<string> regiones = await _utilsRepository.GetRegiones();

            // LOG
            log.EndLog(DateTime.Now, 200, regiones);
            Console.WriteLine(log.parseJson());
            // LOG
            return regiones;
        }

        [HttpPost]
        [Route("comuna")]
        // POST: /api/v1/utils/comuna
        public async Task<List<string>> GetComunasByRegion([FromBody] Region region)
        {
            log = new LogModel();
            log.InitLog(serviceName, "GET", "/api/v1/utils/comuna", DateTime.Now);

            List<string> comunas = await _utilsRepository.GetComunasByRegion(region);
            if (comunas.Count == 0)
            {
                comunas.Add(null);
                comunas.Add("No hay comunas para la región especificada.");
            }

            // LOG
            log.EndLog(DateTime.Now, 200, comunas);
            Console.WriteLine(log.parseJson());
            // LOG
            return comunas;
        }

        [HttpGet]
        [Route("instalaciones")]
        // GET: /api/v1/utils/instalaciones
        public async Task<List<string>> GetInstalaciones()
        {
            List<string> instalaciones = await _utilsRepository.GetInstalaciones();
            return instalaciones;
        }

        [HttpGet]
        [Route("tiposservicio")]
        // GET: /api/v1/utils/tiposervicio
        public async Task<List<string>> GetTiposServicio()
        {
            List<string> tiposServicios = await _utilsRepository.GetTiposServicios();
            return tiposServicios;
        }

        [HttpGet]
        [Route("tiposdepto")]
        // GET: /api/v1/utils/tipodepto
        public async Task<List<string>> GetTiposDepto()
        {
            List<string> tiposDepto = await _utilsRepository.GetTiposDepto();
            return tiposDepto;
        }

        [HttpGet]
        [Route("estadosdepto")]
        // GET: /api/v1/utils/estadodepto
        public async Task<List<string>> GetEstadosDepto()
        {
            List<string> estadosDepto = await _utilsRepository.GetEstadosDepto();
            return estadosDepto;
        }

        [HttpGet]
        [Route("estadosreserva")]
        // GET: /api/v1/utils/estadosreserva
        public async Task<List<string>> GetEstadosReserva()
        {
            List<string> estadosReserva = await _utilsRepository.GetEstadosReserva();
            return estadosReserva;
        }

        [HttpGet]
        [Route("tiposmantencion")]
        // GET: /api/v1/utils/tiposmantencion
        public async Task<List<string>> GetTiposMantencion()
        {
            List<string> tiposMantencion = await _utilsRepository.GetTiposMantencion();
            return tiposMantencion;
        }

        [HttpGet]
        [Route("estadosmantencion")]
        // GET: /api/v1/utils/estadosmantencion
        public async Task<List<string>> GetEstadosMantencion()
        {
            List<string> estadosMantencion = await _utilsRepository.GetEstadosMantencion();
            return estadosMantencion;
        }

    }
}
