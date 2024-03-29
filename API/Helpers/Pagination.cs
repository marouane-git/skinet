using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int totalItems, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            count = totalItems;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int count {get;set;}
        public IReadOnlyList<T> Data { get; set; }
    }
}