using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ThueDat.Core.Paging;

namespace ThueDat.Core.Extensions
{
    public static class QueryableEx
    {
        public static async Task<GridResult<T>> GetGridResult<T>(this IQueryable<T> query, GridParam param) where T : class
        {
            var list = await query.TakePage<T>(param).ToListAsync();
            var total = await query.CountAsync();
            return new GridResult<T>(list, total);
        }

        public static IQueryable<T> TakePage<T>(this IQueryable<T> query, GridParam param) where T: class
        {
            return query.Skip(param.SkipCount).Take(param.MaxResultCount);
        }
    }
}
