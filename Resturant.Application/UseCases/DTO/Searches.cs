using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.DTO
{
    public class BaseSearch
    {
        public string Keyword { get; set; }
    }

    public class PagedSearch
    {
        public int? PerPage { get; set; } = 30;
        public int? Page { get; set; } = 1;
    }

    public class BasePagedSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }

}
