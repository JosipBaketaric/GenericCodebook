using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface IDomainSideMapper<DatabaseClass, DtoClass> where DatabaseClass : class, new() where DtoClass : class, new()
    {
        DtoClass ToDto(DatabaseClass origin);

        IEnumerable<DtoClass> ToDtoList(IEnumerable<DatabaseClass> databaseObjectList);

        List<DtoClass> ToDtoList(List<DatabaseClass> databaseObjectList);
    }
}
