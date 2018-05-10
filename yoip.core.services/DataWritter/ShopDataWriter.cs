

namespace Enjoy.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enjoy.Core.Models.Entities;

    public class ShopDataWriter : IDataWritter<Shop>
    {
        public void Dispose() { }

        public string GenerateExecuteNonQuery(IEnumerable<IDataEntity> entities)
        {

            string queryString = @"INSERT INTO `Enjoy`.`shops`
(`Id`,
`Name`,
`License`,
`Contact`,
`ContactPhone`,
`Coordinate`,
`Address`,
`Description`,
`Addition`)
VALUES 
{0}
ON DUPLICATE KEY UPDATE 
`Id` = VALUES(`Id`),
`Name` =VALUES(`Name`),
`License` = VALUES(`License`),
`Contact` = VALUES(`Contact`),
`ContactPhone` = VALUES(`ContactPhone`),
`Coordinate` = VALUES(`Coordinate`),
`Address` = VALUES(`Address`),
`Description` = VALUES(`Description`);";
            return string.Format(queryString,
                string.Join(",", entities.Select(o => o.GenernateInsertValueString()).ToArray())
             );

        }
    }
}
