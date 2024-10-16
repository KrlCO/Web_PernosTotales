using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class VentaRepository : BaseRepository, IVentaRepository
    {
        public VentaRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public bool RegistrarVenta(VentasCB ventaCb, List<VentasDT> ventasDt, ValeCB valeCb, List<ValeDT> valeDt)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                using (var command = new SqlCommand("usp_Registrar_Venta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros básicos
                    command.Parameters.AddWithValue("@FechaVenta", ventaCb.FechaVenta);
                    command.Parameters.AddWithValue("@IdAlmacen", ventaCb.IdAlmacen);
                    command.Parameters.AddWithValue("@Periodo", valeCb.Periodo);
                    command.Parameters.AddWithValue("@Tipo", valeCb.Tipo);

                    // Convertir las listas a DataTable para pasarlas como parámetros de tipo tabla
                    var ventasDtTable = ConvertToVentasDTDataTable(ventasDt);
                    var valeDtTable = ConvertToValeDTDataTable(valeDt);

                    // Parámetros de tipo tabla
                    var ventasDtParam = command.Parameters.AddWithValue("@VentasDT", ventasDtTable);
                    ventasDtParam.SqlDbType = SqlDbType.Structured;
                    ventasDtParam.TypeName = "dbo.VentasDTType";

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

        private DataTable ConvertToVentasDTDataTable(List<VentasDT> ventasDt)
        {
            var table = new DataTable();
            table.Columns.Add("IdProducto", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("Precio", typeof(decimal));
            table.Columns.Add("UsuarioRegistro", typeof(string));

            foreach (var item in ventasDt)
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
