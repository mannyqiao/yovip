



namespace Enjoy.Core.Models.Entities
{
    using System;
    using Enjoy.Core.Database;
    public class Shop : MySQLDataEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string License { get; set; }
        public virtual string Contact { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual string Coordinate { get; set; }
        public virtual string Address { get; set; }
        public virtual string Description { get; set; }
        public virtual string Addition { get; set; }
        public override string GenernateInsertValueString()
        {
            //`Id`,`Name`,`License`,`Contact`,`ContactPhone`,`Coordinate`,`Address`,`Description`,`Addition` 
            return string.Format("({0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')",
                this.Id,
                this.Name.ESC(),
                this.License.ESC(),
                this.Contact.ESC(),
                this.ContactPhone.ESC(),
                this.Coordinate.ESC(),
                this.Address.ESC(),
                this.Description.ESC(),
                this.Addition.ESC()
                );
        }
    }
}
