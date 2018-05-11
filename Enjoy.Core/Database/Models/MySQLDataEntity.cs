


namespace Enjoy.Core.Database
{
    using Org.Joey.Common;
    using System;
    using System.Data.Linq.Mapping;
    public abstract class MySQLDataEntity : IDataEntity
    {
        public MySQLDataEntity()
        {
            this.ModifyTime = DateTime.Now;
        }
        [Column]
        public System.Int32 Count { get; private set; }

        public DateTime ModifyTime { get; }

        public virtual void Evaluation(string name, object data)
        {
            switch (name)
            {
                case "Count":
                    this.Count = GetIntData(data) ?? 0;
                    break;
            }
        }
        protected virtual System.Int64? GetBigintData(object data)
        {
            if (data.IsDBNull()) return null;
            System.Int64 result;
            if (System.Int64.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        protected virtual int? GetIntData(object data)
        {
            if (data.IsDBNull()) return null;
            System.Int32 result;
            if (System.Int32.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        protected virtual string GetnVarcharData(object data)
        {
            if (data.IsDBNull()) return string.Empty;
            return data.ToString();
        }
        protected virtual string GetNvarcharData(object data)
        {
            if (data.IsDBNull()) return string.Empty;
            return data.ToString();
        }
        protected virtual DateTime? GetDateTimeData(object data)
        {
            if (data.IsDBNull()) return null;
            System.DateTime result;
            if (System.DateTime.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        protected virtual System.Single? GetSingleData(object data)
        {
            if (data.IsDBNull()) return null;
            System.Single result;

            if (System.Single.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        protected virtual System.Double? GetDoubletData(object data)
        {
            if (data.IsDBNull()) return null;
            System.Double result;

            if (System.Double.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        protected virtual System.Decimal? GetDecimalData(object data)
        {
            if (data.IsDBNull()) return null;
            System.Decimal result;

            if (System.Decimal.TryParse(data.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public abstract string GenernateInsertValueString();
        
    }
}
