using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Models.DB
{
    public class TestCodebook
    {
        public TestCodebook()
        {
        }
        public TestCodebook(long id)
        {
            this.Id = id;
            this.Name = id.ToString();
        }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
