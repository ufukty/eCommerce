using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class ListViewModel
    {
        public FilterList filterList;
        public ProductContext productContext;

        public ListViewModel(FilterList filterList, ProductContext productContext)
        {
            this.filterList = filterList;
            this.productContext = productContext;
        }


    }
}