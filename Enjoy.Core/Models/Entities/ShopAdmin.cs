
namespace Enjoy.Core.Models.Entities
{
    using System;
    using Enjoy.Core.Database;
    public class ShopAdmin : MySQLDataEntity
    {
        public virtual long ShopId { get; set; }

        public virtual long MemberId { get; set; }

        public override string GenernateInsertValueString()
        {
            throw new NotImplementedException();
        }
    }
}
