using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThueDat.Core.Paging
{
    public class GridParam : PagedResultRequestDto
    {
        public string Sort { get; set; }
        public SortDirection SortDirection { get; set; }
        public string SearchText { get; set; }
    }

    public class SearchItem
    {
        public object SearchValue { get; set; }
        public string SearchProperty { get; set; }

        //public ComparisionOperator Comparison { get; set; }
    }

    public enum SortDirection : byte
    {
        ASC = 0,
        DESC = 1
    }
}
