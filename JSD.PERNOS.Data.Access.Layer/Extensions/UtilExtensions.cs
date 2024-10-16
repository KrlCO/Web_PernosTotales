using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace JSD.PERNOS.Data.Access.Layer.Extensions
{
    public static class UtilExtensions
    {
        public static T GetEntity<T>(this SqlDataReader dataReader)
        {
            var properties = typeof(T).GetProperties();
            T item = default;
            var columns = dataReader.GetColumnSchema();

            while (dataReader.Read())
            {
                item = (T)Activator.CreateInstance(typeof(T));
                foreach (var property in properties)
                {
                    if (columns.Any(c => c.ColumnName == property.Name))
                    {
                        var value = dataReader[property.Name];
                        if (value != DBNull.Value)
                            property.SetValue(item, value);
                    }
                }
            }

            return item;
        }

        public static List<T> GetEntities<T>(this SqlDataReader dataReader)
        {
            var properties = typeof(T).GetProperties();
            var columns = dataReader.GetColumnSchema();
            List<T> entities = new();
            while (dataReader.Read())
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                foreach (var property in properties)
                {
                    if (columns.Any(c => c.ColumnName == property.Name))
                    {
                        var value = dataReader[property.Name];
                        if (value != DBNull.Value)
                            property.SetValue(item, value);
                    }
                }
                entities.Add(item);
            }

            return entities;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string columnName)
        {
            DataTable table = new();
            table.Columns.Add(columnName, typeof(T));
            foreach (T item in data) table.Rows.Add(item);
            return table;
        }

        public static List<T> NextResult<T>(this SqlDataReader dataReader)
        {
            dataReader.NextResult();
            return dataReader.GetEntities<T>();
        }

    }
}
