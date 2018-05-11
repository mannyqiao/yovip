
namespace Enjoy.Core
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Data.Linq.Mapping;
    using System.Data.SqlClient;
    public static class DatabaseExtension
    {
        public static string ESC(this string text)
        {
            return text.Replace("'", "\'")
                .Replace("\"", "\\\"");
        }
        public static bool IsDBNull(this object obj)
        {
            if (obj == null) return false;
            return obj.GetType().Name.Equals("DBNull");
        }
        //public static IEnumerable<T> SqlQuery<T>(this Database database, DbCommand command) where T : MSSqlDataEntity
        //{
        //    using (IDataReader reader = database.ExecuteReader(command))
        //    {
        //        while (reader.Read())
        //        {
        //            T t = Activator.CreateInstance<T>();
        //            var columns = reader.GetSchemaTable().Columns;
        //            foreach (var column in columns)
        //            {
        //                DataColumn col = column as DataColumn;
        //                t.Evaluation(col.ColumnName, reader[col.ColumnName]);
        //            }
        //            yield return t;
        //        }
        //    }
        //}
        //public static IEnumerable<T> SqlQuery<T>(this Database database, string queryString, SqlParameter[] parameters) where T : MSSqlDataEntity
        //{
        //    var command = new SqlCommand(queryString);
        //    command.Parameters.AddRange(parameters);
        //    return database.SqlQuery<T>(command);
        //}
    }
}
