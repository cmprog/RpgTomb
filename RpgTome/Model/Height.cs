using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace RpgTome.Model
{
    public struct Height : IUserType
    {
        private readonly int mTotalInches;
        private readonly int mFeet;
        private readonly int mInches;

        public Height(int totalInches)
        {
            this.mTotalInches = totalInches;
            this.mFeet = totalInches/12;
            this.mInches = totalInches%12;
        }

        public int TotalInches
        {
            get { return this.mTotalInches; }
        }

        public int Feet
        {
            get { return this.mFeet; }
        }

        public int Inches
        {
            get { return this.mInches; }
        }

        public override int GetHashCode()
        {
            return this.mTotalInches;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is Height)
            {
                var lObjAsHeight = (Height) obj;
                return (this.mTotalInches == lObjAsHeight.mTotalInches);
            }

            return false;
        }

        public override string ToString()
        {
            return string.Concat(this.mFeet, "'", this.mInches, "''");
        }

        public static implicit operator int(Height height)
        {
            return height.mTotalInches;
        }

        public static implicit operator Height(int totalInches)
        {
            return new Height(totalInches);
        }

        bool IUserType.Equals(object x, object y)
        {
            if (x == null) return (y == null);
            if (x is Height)
            {
                var lHeightX = (Height) x;
                return lHeightX.Equals(y);
            }
            return false;
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var lObject = NHibernateUtil.Int32.NullSafeGet(rs, names);
            if (lObject == null) return null;
            return new Height((int) lObject);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var lDataParameter = ((IDataParameter)cmd.Parameters[index]);

            if (value == null)
            {
                lDataParameter.Value = DBNull.Value;
            }
            else
            {
                var lHeight = (Height) value;
                lDataParameter.Value = lHeight.mTotalInches;
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public SqlType[] SqlTypes
        {
            get { return new[] {SqlTypeFactory.Int32}; }
        }

        public Type ReturnedType
        {
            get { return typeof (Height); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}
