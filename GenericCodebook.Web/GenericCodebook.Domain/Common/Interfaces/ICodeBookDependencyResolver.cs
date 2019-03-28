using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface ICodeBookDependencyResolver
    {
        ICodeBookService GetCodeBookService(string codeBookServiceName);
        ICodeBookService GetCodeBookService(object baseCodebookFilter);

    }
}
