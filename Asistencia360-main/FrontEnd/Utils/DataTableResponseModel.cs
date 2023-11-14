using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Utils
{
    public class DataTableResponseModel<T> where T : class
    {
        public int Draw { get; set; }

        public long RecordsTotal { get; set; }

        public long RecordsFiltered { get; set; }

        public IEnumerable<T> data { get; set; }

        public string Error { get; set; }

        public DataTableResponseModel()
        {
        }
    }
}