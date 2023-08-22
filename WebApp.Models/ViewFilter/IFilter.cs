using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.ViewFilter
{
    public interface IFilter<TModel>
    {
        public long Id { get; set; }

        IEnumerable<Expression<Func<TModel, bool>>> Get();
    }
}
