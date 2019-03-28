using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Models
{
    public class SuggestionFilterDTO : BaseDTO
    {
        public string CodebookName { get; set; }
        public string Filter { get; set; }
        public bool GetAll { get; set; }
        public string FilterBy { get; set; }
        public string FilterByVal { get; set; }
    }
}
