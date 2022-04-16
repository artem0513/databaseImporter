using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    [DataContract]
    public abstract class BaseDto<TId> : IEquatable<BaseDto<TId>>, IEqualityComparer<BaseDto<TId>>
    {
        [DataMember(Name = "id")]
        public virtual TId Id { get; set; }

        public bool Equals(BaseDto<TId> x, BaseDto<TId> y) => x != null && y != null && x.Id.Equals(y.Id);

        public int GetHashCode(BaseDto<TId> obj)
        {
            return Id.GetHashCode();
        }

        public bool Equals(BaseDto<TId> other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj?.GetType() == GetType() && Equals((BaseDto<TId>) obj);
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
    }
}