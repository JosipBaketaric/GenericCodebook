using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Models
{
    /// <summary>
    /// Class that every grid should use.
    /// TODO: Move to IN2Components
    /// </summary>
    public class PagingCollectionDTO<T> : BaseDTO
    {
        public PagingCollectionDTO() { }

        public IEnumerable<T> Items { get; set; }
        public PagingDTO Paging { get; set; }
        public long NumOfTotalRecords { get; set; }
    }
}
