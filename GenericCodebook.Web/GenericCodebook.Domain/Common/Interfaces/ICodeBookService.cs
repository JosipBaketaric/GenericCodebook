using GenericCodebook.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface ICodeBookService
    {
        object GetById(long id);
        PagingCollectionDTO<object> GetFiltered(object filter);
        object Create(object val);
        object Update(object val);
        void Delete(long id);
        IEnumerable<RegistryChildrenDTO> LoadChildren(long id);
    }
}
