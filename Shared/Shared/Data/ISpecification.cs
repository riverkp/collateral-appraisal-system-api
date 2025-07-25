using System;
using System.Linq.Expressions;

namespace Shared.Data
{
    /// <summary>
    /// Represents a specification pattern interface for encapsulating query logic.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Converts the specification to a LINQ expression.
        /// </summary>
        /// <returns>The LINQ expression representing this specification.</returns>
        Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Determines whether the specified entity satisfies this specification.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <returns>True if the entity satisfies the specification; otherwise, false.</returns>
        bool IsSatisfiedBy(T entity);
    }
}
