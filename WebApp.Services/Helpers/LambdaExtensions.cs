using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Helpers
{
    public static class LambdaExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> def = (item) => true;
            var param = Expression.Parameter(typeof(T), "x");

            var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], param);
            var leftVisited = leftVisitor.Visit(left.Body);

            var defVisitor = new ReplaceExpressionVisitor(def.Parameters[0], param);
            var defVisited = defVisitor.Visit(def.Body);

            if (leftVisited.ToString().Equals(defVisited.ToString()))
            {
                var lambda = Expression.Lambda<Func<T, bool>>(Expression.Invoke(right, param), param);
                return lambda;
            }
            else
            {
                var body = Expression.AndAlso(
                        Expression.Invoke(left, param),
                        Expression.Invoke(right, param)
                    );
                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                return lambda;
            }
        }
    }
}
