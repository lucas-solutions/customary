using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Custom
{
    using Custom.Models;

    public static class QuariableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> source, IEnumerable<Sort> sort)
        {
            if (sort != null)
            {
                var e = sort.GetEnumerator();

                if (e.MoveNext())
                {
                    IOrderedQueryable<T> ordered;

                    switch (e.Current.Direction)
                    {
                        case SortDirection.Desc:
                            ordered = source.OrderByDescending(e.Current.Property.PascalCase());
                            break;
                        default:
                            ordered = source.OrderBy(e.Current.Property.PascalCase());
                            break;
                    }

                    while (e.MoveNext())
                    {
                        switch (e.Current.Direction)
                        {
                            case SortDirection.Desc:
                                ordered = ordered.ThenByDescending(e.Current.Property.PascalCase());
                                break;
                            default:
                                ordered = ordered.ThenBy(e.Current.Property.PascalCase());
                                break;
                        }
                    }

                    source = ordered;
                }
            }

            return source;
        }

        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        } 

        // http://www.digitallycreated.net/Blog/37/dynamic-queries-in-entity-framework-using-expression-trees

        public static Expression<Func<TValue, bool>> BuildOrExpressionTree<TValue, TCompareAgainst>(IEnumerable<TCompareAgainst> wantedItems, Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes)
        {
            ParameterExpression inputParam = convertBetweenTypes.Parameters[0];

            Expression binaryExpressionTree = BuildBinaryOrTree(wantedItems.GetEnumerator(), convertBetweenTypes.Body, null);

            return Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam });
        }

        private static Expression BuildBinaryOrTree<T>(IEnumerator<T> itemEnumerator, Expression expressionToCompareTo, Expression expression)
        {
            if (itemEnumerator.MoveNext() == false)
                return expression;

            ConstantExpression constant = Expression.Constant(itemEnumerator.Current, typeof(T));
            BinaryExpression comparison = Expression.Equal(expressionToCompareTo, constant);

            BinaryExpression newExpression;

            if (expression == null)
                newExpression = comparison;
            else
                newExpression = Expression.OrElse(expression, comparison);

            return BuildBinaryOrTree(itemEnumerator, expressionToCompareTo, newExpression);
        }
    }
}