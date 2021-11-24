using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IRowLightMSSQL
    {
        void Init(SqlDataReader readerSQL, string[] columnList = null);
    }

    public class CommandMSSQL
    {
        public CommandMSSQL() { }

        string connectionString = "";

        async public Task<object> ExecuteReaderAsync(string sqlStatement)
        {
            object result = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlStatement, connection);

                if (command.Connection == null)
                    throw new Exception("Немає зв'язку з сервером!");

                try
                {
                    await command.Connection.OpenAsync();
                    result = await command.ExecuteReaderAsync();
                }
                catch (Exception e) { throw e; }
            }

            return result;
        }

        async public Task ExecuteNonQueryAsync(string sqlStatement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlStatement, connection);

                if (command.Connection == null)
                    throw new Exception("Немає зв'язку з сервером!");

                try
                {
                    await command.Connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception e) { throw e; }
            }
        }

        async public Task<object> ExecuteScalar(string sqlStatement)
        {
            object result = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlStatement, connection);

                if (command.Connection == null)
                    throw new Exception("Немає зв'язку з сервером!");

                try
                {
                    await command.Connection.OpenAsync();
                    result = await command.ExecuteScalarAsync();
                }
                catch (Exception e) { throw e; }
            }

            return result;
        }

        public static T GetValue<T>(SqlDataReader reader, string key, string[] columnList = null)
        {
            if (columnList != null)
            {
                var index = Array.FindIndex(columnList, x => x.IndexOf(key, StringComparison.InvariantCultureIgnoreCase) == 0 && x.Length == key.Length);
                if (index < 0)
                    return default(T);
            }

            if (Convert.IsDBNull(reader[key]))
                return default(T);

            var type = typeof(T);
            var nullableType = Nullable.GetUnderlyingType(type);
            if (nullableType != null)
            {
                return (T)Convert.ChangeType(reader[key].ToString(), nullableType);
            }
            var result = (T)Convert.ChangeType(reader[key].ToString(), type);
            return result;
        }
    }
}
