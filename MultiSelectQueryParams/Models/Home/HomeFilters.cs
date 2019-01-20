using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiSelectQueryParams.Models.Home
{
    public partial class HomeFilters
    {
        public int[] situacaoId { get; set; }
        public int offSet { get; set; }
        public int limit { get; set; }
    }
}