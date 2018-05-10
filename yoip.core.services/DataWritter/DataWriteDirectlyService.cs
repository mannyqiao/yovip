

namespace Enjoy.Core.Services
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Data;
    using System;
    using System.Collections.Generic;

    public class DataWriteDirectlyService : IDataWriteDirectlyService<IDataEntity>
    {
        public void Save(IEnumerable<IDataEntity> entities)
        {
            if (entities == null) return;
            using (var service = new ShopDataWriter())
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                var database = factory.Create("Enjoy");
                //   DatabaseFactory.SetDatabaseProviderFactory(DatabaseProviderFactory)

                var queryString = service.GenerateExecuteNonQuery(entities);

                int i = database.ExecuteNonQuery(CommandType.Text, queryString);
                Console.WriteLine("Werite {0} ", i);
            }
        }
    }
}
