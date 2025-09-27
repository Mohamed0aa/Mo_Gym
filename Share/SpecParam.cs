using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{//moahemd
    public  class SpecParam
    {
        public string? Sort { set; get;}
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;

        private int pageSize = 5;

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }


        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : value; }

        }

    }
}
