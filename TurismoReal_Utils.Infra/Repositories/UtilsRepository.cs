using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Interfaces;
using TurismoReal_Utils.Infra.Context;
using TurismoReal_Utils.Core.Entities;

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

        public Task<List<object>> GetRegiones()
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetComunasByRegion(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
