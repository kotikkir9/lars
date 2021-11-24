using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Models.ResourceParameters
{
    public class SubjectResourceParameters
    {
        public string Education { get; set; }
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value;
        }
    }
}
