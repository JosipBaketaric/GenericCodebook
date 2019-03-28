using GenericCodebook.Domain.Common.Enumerators;
using GenericCodebook.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Models
{
    public class PagingDTO : BaseCodebookFilter, IPaging
    {
        public PagingDTO()
        {
            this.SortingOrder = SortOrderEnum.Descending;
            this.CurrentPageIndex = 1;
            this.NumElementsPerPage = 10;
            this.NumToSkip = this.NumElementsPerPage * (this.CurrentPageIndex - 1);
        }

        public string OrderByColumnName { get; set; }
        public SortOrderEnum SortingOrder { get; set; }
        public int CurrentPageIndex { get; set; }
        public int NumElementsPerPage { get; set; }
        public int NumToSkip { get; }
    }
}
