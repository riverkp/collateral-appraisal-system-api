using System;
using System.Linq.Expressions;

namespace Shared.Data
{
    /// <summary>
    /// Base class for specifications that allows combining specifications using logical operators.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        /// <summary>
        /// Converts the specification to a LINQ expression.
        /// </summary>
        /// <returns>The LINQ expression representing this specification.</returns>
        public abstract Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Determines whether the specified entity satisfies this specification.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <returns>True if the entity satisfies the specification; otherwise, false.</returns>
        public virtual bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        /// <summary>
        /// Combines two specifications using logical AND.
        /// </summary>
        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        /// <summary>
        /// Combines two specifications using logical OR.
        /// </summary>
        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        /// <summary>
        /// Negates a specification using logical NOT.
        /// </summary>
        public static Specification<T> operator !(Specification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }

    /// <summary>
    /// Specification that combines two specifications using logical AND.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        /// <summary>
        /// Creates a new instance of AndSpecification.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        /// <summary>
        /// Combines the left and right expressions using logical AND.
        /// </summary>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(
                Expression.Invoke(leftExpression, parameter),
                Expression.Invoke(rightExpression, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    /// <summary>
    /// Specification that combines two specifications using logical OR.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        /// <summary>
        /// Creates a new instance of OrSpecification.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        /// <summary>
        /// Combines the left and right expressions using logical OR.
        /// </summary>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(
                Expression.Invoke(leftExpression, parameter),
                Expression.Invoke(rightExpression, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    /// <summary>
    /// Specification that negates another specification using logical NOT.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        /// <summary>
        /// Creates a new instance of NotSpecification.
        /// </summary>
        /// <param name="specification">The specification to negate.</param>
        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }

        /// <summary>
        /// Negates the underlying specification expression.
        /// </summary>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = _specification.ToExpression();
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.Not(Expression.Invoke(expression, parameter));

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
