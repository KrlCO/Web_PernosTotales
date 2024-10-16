using JSD.PERNOS.Data.Access.Layer.Extensions;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class BaseRepository
    {
        protected readonly string cadenaConexion = null;
        public BaseRepository(DataProtector dataProtector)
         => cadenaConexion = dataProtector.cadenaConexion;

        public IEnumerable<T> GetEntities<T>(string storedProcedure, params SqlParameter[] parameters)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters);
            }
            sqlConnection.Open();
            using SqlDataReader dr = command.ExecuteReader();
            return dr.GetEntities<T>();
        }

        public T GetEntity<T>(string storedProcedure, params SqlParameter[] parameters)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            sqlConnection.Open();
            using SqlDataReader dr = command.ExecuteReader();
            return dr.GetEntity<T>();
        }

        public bool ExecuteProcedureCRUD(string storedProcedure, params SqlParameter[] sqlParams)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(sqlParams);
            sqlConnection.Open();
            return command.ExecuteNonQuery() > 0;

        }

        public bool ExisteEntidad(string storedProcedure, params SqlParameter[] sqlParams)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(sqlParams);
            sqlConnection.Open();
            return command.ExecuteScalar() is not null;

        }

        public int CountEntities(string storedProcedure, params SqlParameter[] sqlParams)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(sqlParams);
            sqlConnection.Open();
            return (int)command.ExecuteScalar();

        }

        public T GetValue<T>(string storedProcedure, params SqlParameter[] sqlParams)
        {
            using SqlConnection sqlConnection = new(cadenaConexion);
            using SqlCommand command = new(storedProcedure, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            if (sqlParams != null && sqlParams.Length > 0)
            {
                command.Parameters.AddRange(sqlParams);
            }
            sqlConnection.Open();
            return (T)command.ExecuteScalar();
        }

    }
}
