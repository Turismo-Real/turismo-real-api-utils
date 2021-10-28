using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Entities;
using TurismoReal_Utils.Core.Interfaces;
using TurismoReal_Utils.Infra.Context;

namespace TurismoReal_Utils.Infra.Repositories
{
    public class UtilsRepository : IUtilsRepository
    {
        protected readonly OracleContext _context;

        public UtilsRepository()
        {
            _context = new OracleContext();
        }

        public async Task<List<string>> GetPaises()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_paises", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("paises", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader) await cmd.ExecuteReaderAsync();
            List<string> paises = new List<string>();

            while (reader.Read())
            {
                string pais = reader.GetValue(reader.GetOrdinal("pais")).ToString();
                paises.Add(pais);
            }
            _context.CloseConnection();
            return paises;
        }

        public async Task<List<string>> GetRegiones()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_regiones", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("regiones", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader) await cmd.ExecuteReaderAsync();
            List<string> regiones = new List<string>();

            while (reader.Read())
            {
                string region = reader.GetValue(reader.GetOrdinal("region")).ToString();
                regiones.Add(region);
            }
            _context.CloseConnection();
            return regiones;
        }

        public async Task<List<string>> GetComunasByRegion(Region region)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_comuna_por_region", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("region_in", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("comunas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters["region_in"].Value = region.region;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> comunas = new List<string>();

            while (reader.Read())
            {
                string comuna = reader.GetValue(reader.GetOrdinal("comuna")).ToString();
                comunas.Add(comuna);
            }
            _context.CloseConnection();
            return comunas;
        }

        public async Task<List<string>> GetInstalaciones()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_lista_instalaciones", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("instalaciones", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> instalaciones = new List<string>();

            while (reader.Read())
            {
                string instalacion = reader.GetValue(reader.GetOrdinal("instalacion")).ToString();
                instalaciones.Add(instalacion);
            }
            _context.CloseConnection();
            return instalaciones;
        }

        public async Task<List<string>> GetTiposServicios()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_tipo_servicios", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("t_servicios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> tiposServicios = new List<string>();

            while (reader.Read())
            {
                string tipoServicio = reader.GetValue(reader.GetOrdinal("tipo_servicio")).ToString();
                tiposServicios.Add(tipoServicio);
            }
            _context.CloseConnection();
            return tiposServicios;
        }

        public async Task<List<string>> GetTiposDepto()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_tipo_deptos", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tipo_deptos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> tiposDepto = new List<string>();

            while (reader.Read())
            {
                string tipoDepto = reader.GetValue(reader.GetOrdinal("tipo_departamento")).ToString();
                tiposDepto.Add(tipoDepto);
            }
            _context.CloseConnection();
            return tiposDepto;
        }

        public async Task<List<string>> GetEstadosDepto()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_estados_depto", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("estados", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> estadosDepto = new List<string>();

            while (reader.Read())
            {
                string estadoDepto = reader.GetValue(reader.GetOrdinal("estado")).ToString();
                estadosDepto.Add(estadoDepto);
            }
            _context.CloseConnection();
            return estadosDepto;
        }

        public async Task<List<string>> GetEstadosReserva()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_estados_reserva", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("estados", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> estadosReserva = new List<string>();

            while (reader.Read())
            {
                string estadoReserva = reader.GetValue(reader.GetOrdinal("estado")).ToString();
                estadosReserva.Add(estadoReserva);
            }
            _context.CloseConnection();
            return estadosReserva;
        }

        public async Task<List<string>> GetTiposMantencion()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_tipo_mantencion", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tipos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> tiposMantencion = new List<string>();

            while (reader.Read())
            {
                string tipoMantencion = reader.GetValue(reader.GetOrdinal("tipo")).ToString();
                tiposMantencion.Add(tipoMantencion);
            }
            _context.CloseConnection();
            return tiposMantencion;
        }

        public async Task<List<string>> GetEstadosMantencion()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_estados_mantencion", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("estados", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> estadosMantencion = new List<string>();

            while (reader.Read())
            {
                string estadoMantencion = reader.GetValue(reader.GetOrdinal("estado")).ToString();
                estadosMantencion.Add(estadoMantencion);
            }
            _context.CloseConnection();
            return estadosMantencion;
        }

        public async Task<List<string>> GetTiposGasto()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_tipos_gasto", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tipos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> tiposGasto = new List<string>();

            while (reader.Read())
            {
                string tipoGasto = reader.GetValue(reader.GetOrdinal("tipo_gasto")).ToString();
                tiposGasto.Add(tipoGasto);
            }
            _context.CloseConnection();
            return tiposGasto;
        }

        public async Task<List<string>> GetTiposPago()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_tipos_pago", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tipos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> tiposPago = new List<string>();

            while (reader.Read())
            {
                string tipoPago = reader.GetValue(reader.GetOrdinal("tipo_pago")).ToString();
                tiposPago.Add(tipoPago);
            }
            _context.CloseConnection();
            return tiposPago;
        }


    }
}
