using Lesson05.Extensions;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lesson05.DAL
{
    internal static class DataAccessLayer
    {
        public const string Connection_String = "Data Source=EPUZTASW0537\\SQLEXPRESS;Initial Catalog=ExpenseManager;Integrated Security=True";

        public static async Task ExecuteNonQueryAsync(string command)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        int affectedRows = await sqlCommand.ExecuteNonQueryAsync();

                        ConsoleHelper.WriteSuccess($"Number of affected rows: {affectedRows}");
                    }
                }
            }
            catch (SqlException ex)
            {
                ConsoleHelper.WriteLineError($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLineError($"Something went wrong: {ex.Message}.");
            }
        }

        public static async Task<T> ExecuteQueryAsync<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        var dataReader = await sqlCommand.ExecuteReaderAsync();

                        return converter(dataReader);
                    }
                }
            }
            catch (SqlException ex)
            {
                ConsoleHelper.WriteLineError($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLineError($"Something went wrong: {ex.Message}.");
            }

            return default;
        }

        private static void ThrowIfNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
        }
    }
}
