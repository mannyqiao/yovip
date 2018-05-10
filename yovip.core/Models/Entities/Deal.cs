using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core.Models.Entities
{
    using System.Data.Linq.Mapping;
    using Enjoy.Core.Database;
    public class Deal : MySQLDataEntity
    {
        [Column]
        public virtual long? Id { get; set; }
        public virtual long ShopId { get; set; }
        public virtual long MemberId { get; set; }
        public virtual int DealingTypes { get; set; }
        public virtual decimal? RDealingAmountAs { get; set; }
        public virtual decimal? DDeallingAmountAs { get; set; }
        public virtual decimal? BDealingAmountAs { get; set; }
        public virtual decimal? ADealingAmountAs { get; set; }
        public virtual decimal? LoyaltyPoints { get; set; }
        public virtual long? RelatedCardId { get; set; }
        public virtual long? RelatedCouponId { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual string Addition { get; set; }

        public override string GenernateInsertValueString()
        {
            throw new NotImplementedException();
        }
    }
}
