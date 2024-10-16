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
    public class SalidaRepository : BaseRepository, ISalidaRepository
    {
        public SalidaRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public bool RegistrarSalida(VentasCB ventaCb, List<VentasDT> ventasDT, ValeCB valeCb, List<ValeDT> valeDT)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                using (var command = new SqlCommand("usp_Registrar_Vale_Salida", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros básicos para CompraCB
                    command.Parameters.AddWithValue("@IdAlmacen", ventaCb.IdAlmacen);
                    command.Parameters.AddWithValue("@FechaCompra", ventaCb.FechaVenta);

                    // Parámetros básicos para ValeCB
                    command.Parameters.AddWithValue("@Periodo", valeCb.Periodo);
                    command.Parameters.AddWithValue("@IdTipoMovimiento", valeCb.IdTipoMovimiento);

                    // Convertir las listas a DataTable para pasarlas como parámetros de tipo tabla
                    var ventaDtTable = ConvertToVentaDTDataTable(ventasDT);
                    var valeDtTable = ConvertToValeDTDataTable(valeDT);

                    // Parámetros de tipo tabla
                    var ventaDtParam = command.Parameters.AddWithValue("@SalidaDT", ventaDtTable);
                    ventaDtParam.SqlDbType = SqlDbType.Structured;
                    ventaDtParam.TypeName = "dbo.SalidaDTType";

                    var valeDtParam = command.Parameters.AddWithValue("@ValeDT", valeDtTable);
                    valeDtParam.SqlDbType = SqlDbType.Structured;
                    valeDtParam.TypeName = "dbo.ValeDTType";

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        private DataTable ConvertToVentaDTDataTable(List<VentasDT> ventasDT)
        {
            var table = new DataTable();
            table.Columns.Add("IdProducto", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("Precio", typeof(decimal));
            table.Columns.Add("UsuarioRegistro", typeof(string));

            foreach (var item in ventasDT)
            {
                table.Rows.Add(item.IdProducto, item.Cantidad, item.Precio, item.UsuarioRegistro);
            }

            return table;
        }

        private DataTable ConvertToValeDTDataTable(List<ValeDT> valeDt)
        {
            var table = new DataTable();
            table.Columns.Add("IdProducto", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("Precio", typeof(decimal));
            table.Columns.Add("UsuarioRegistro", typeof(string));

            foreach (var item in valeDt)
            {
                table.Rows.Add(item.IdProducto, item.Cantidad, item.Precio, item.UsuarioRegistro);
            }

            return table;
        }
    }
}

