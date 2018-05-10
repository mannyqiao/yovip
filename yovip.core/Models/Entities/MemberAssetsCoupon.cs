

namespace Enjoy.Core.Models.Entities
{
    using System;
    using Enjoy.Core.Database;
    public class MemberAssetsCoupon : MySQLDataEntity
    {
        public virtual long? Id { get; set; }
        public virtual long? ShopId { get; set; }
        public virtual long? AssetsId { get; set; }
        public virtual long? MemberId { get; set; }
        public virtual decimal? Amount { get; set; }
        public virtual bool? BeUsed { get; set; }
        public virtual DateTime? ExpireTime { get; set; }
        public virtual long? SharedFrom { get; set; }
        public virtual DateTime? CreatedTime { get; set; }

        public override string GenernateInsertValueString()
        {
            throw new NotImplementedException();
        }
    }
}
