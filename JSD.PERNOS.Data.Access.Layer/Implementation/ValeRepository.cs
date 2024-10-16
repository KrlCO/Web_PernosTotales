using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class ValeRepository : BaseRepository, IValeRepository
    {
        public ValeRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public IEnumerable<ValeCB> Listar(int? idAlmacen = null, int? idTipoMovimiento = null, string codigoVale = null, DateTime? fechaRegistro = null)
        {
            var vales = new List<ValeCB>();

            using (var connection = new SqlConnection(cadenaConexion))
            {
                var command = new SqlCommand("usp_Listar_Vale", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@IdAlmacen", idAlmacen ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IdTipoMovimiento", idTipoMovimiento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CodigoVale", codigoVale ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro ?? (object)DBNull.Value);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var vale = new ValeCB
                        {
                            CodigoVale = reader["CodigoVale"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            FechaRegistro = (DateTime)reader["FechaRegistro"],
                            TipoMovimiento = reader["TipoMovimiento"].ToString()
                        };

                        vales.Add(vale);
                    }
                }
            }

            return vales;
        }

    }
}
