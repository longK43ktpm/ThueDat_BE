using System;
using System.Collections.Generic;
using System.Text;

namespace ThueDat.Core.Paging
{
    public class GridResult<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }

        public GridResult(List<T> items, int total)
        {
            Items = items;
            TotalCount = total;
        }
    }
}
