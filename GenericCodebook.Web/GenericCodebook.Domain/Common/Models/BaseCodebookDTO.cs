using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Models
{
    public class BaseCodebookDTO : BaseDTO
    {
        public string CodebookName { get; set; }
        public object Item { get; set; }
    }
}
