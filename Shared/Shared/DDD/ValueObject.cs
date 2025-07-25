using System.Collections;
using System.Reflection;

namespace Shared.DDD;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject obj)
    {
        return Equals(obj as object);
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null) return IsEmpty();
        if (GetType() != obj.GetType()) return false;

        var other = (ValueObject)obj;

        // Both empty = equal
        if (IsEmpty() && other.IsEmpty()) return true;

        // One empty, one not = not equal
        if (IsEmpty() || other.IsEmpty()) return false;

        return StructuralEquals(other);
    }

    public override int GetHashCode()
    {
        return IsEmpty() ? 0 : GetStructuralHashCode();
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null && right is null) return true;
        if (left is null) return right?.IsEmpty() == true;
        if (right is null) return left.IsEmpty();
        return left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    public virtual bool IsEmpty()
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return properties.All(prop => IsPropertyEmpty(prop.GetValue(this)));
    }

    protected virtual bool IsPropertyEmpty(object? value)
    {
        return value switch
        {
            null => true,
            string s => string.IsNullOrWhiteSpace(s),
            decimal d => d == 0,
            int i => i == 0,
            long l => l == 0,
            double d => d == 0,
            float f => f == 0,
            bool b => !b,
            DateTime dt => dt == default,
            ICollection collection => collection.Count == 0,
            IEnumerable enumerable => !enumerable.Cast<object>().Any(),
            ValueObject valueObject => valueObject.IsEmpty(),
            _ => false
        };
    }

    protected virtual bool StructuralEquals(ValueObject other)
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return properties.All(prop =>
        {
            var thisValue = prop.GetValue(this);
            var otherValue = prop.GetValue(other);

            // Handle ValueObject properties specially
            if (thisValue is ValueObject thisVO && otherValue is ValueObject otherVO)
            {
                // Both empty = equal
                if (thisVO.IsEmpty() && otherVO.IsEmpty()) return true;
                // One empty, one not = not equal
                if (thisVO.IsEmpty() || otherVO.IsEmpty()) return false;
                return thisVO.Equals(otherVO);
            }

            // Handle null vs empty ValueObject
            if (thisValue is ValueObject vo && otherValue is null)
                return vo.IsEmpty();
            if (thisValue is null && otherValue is ValueObject vo2)
                return vo2.IsEmpty();

            return Equals(thisValue, otherValue);
        });
    }

    protected virtual int GetStructuralHashCode()
    {
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var hashCode = new HashCode();

        foreach (var prop in properties)
        {
            hashCode.Add(prop.GetValue(this));
        }

        return hashCode.ToHashCode();
    }
}