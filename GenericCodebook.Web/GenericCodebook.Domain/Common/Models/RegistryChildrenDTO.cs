using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Models
{
    public class RegistryChildrenDTO : BaseDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string GroupTitle { get; set; }
        public string Group { get; set; }
    }
}
