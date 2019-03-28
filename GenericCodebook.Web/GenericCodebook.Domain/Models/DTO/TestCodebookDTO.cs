﻿using GenericCodebook.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Models.DTO
{
    public class TestCodebookDTO : BaseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
