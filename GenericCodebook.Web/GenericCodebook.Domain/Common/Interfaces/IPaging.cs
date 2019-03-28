using GenericCodebook.Domain.Common.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface IPaging
    {
        string OrderByColumnName { get; set; }
        SortOrderEnum SortingOrder { get; set; }
        int CurrentPageIndex { get; set; }
        int NumElementsPerPage { get; set; }
        int NumToSkip { get; }
    }
}
