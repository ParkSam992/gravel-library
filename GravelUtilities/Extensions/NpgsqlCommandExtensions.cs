using Npgsql;
using NpgsqlTypes;

namespace Gravel.Utilities.Extensions;

public static class NpgsqlCommandExtensions
{
    public static void AddParam(this NpgsqlCommand command, object value,
        NpgsqlDbType type = NpgsqlDbType.Varchar)
    {
        if (value == null)
        {
            command.Parameters.AddWithValue(DBNull.Value);
            return;
        }

        if (type == NpgsqlDbType.Varchar)
        {
            if (Convert.ToString(value) == null)
            {
                command.Parameters.AddWithValue(DBNull.Value);
                return;
            }

            command.Parameters.AddWithValue(type, value);
        }

        command.Parameters.AddWithValue(type, value).Value = value;
    }
}