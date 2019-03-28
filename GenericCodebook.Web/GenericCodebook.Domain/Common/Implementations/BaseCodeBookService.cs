using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericCodebook.Domain.Common.LINQ;

namespace GenericCodebook.Domain.Common.Implementations
{
    public abstract class BaseCodeBookService
    {
        protected T HandleObjectDeserialization<T>(object filter) where T : BaseDTO
        {
            T filterSerialized = null;
            //De-serialize filter 
            if (filter != null)
            {
                filterSerialized = JsonConvert.DeserializeObject<T>(filter.ToString());
            }
            return filterSerialized;
        }

        /// <summary>
        /// Used for datatables. Handles sorting and paging.
        /// </summary>
        /// <typeparam name="DatabaseClass"></typeparam>
        /// <typeparam name="DomainClass"></typeparam>
        /// <param name="query"></param>
        /// <param name="paging"></param>
        /// <param name="mapper">Provide mapper that implements IDomainSideMapper. (that is in Mapper.Interface)</param>
        /// <returns></returns>
        protected PagingCollectionDTO<object> CreatePagingCollection<DatabaseClass, DomainClass>(IQueryable<DatabaseClass> query, IPaging paging, IDomainSideMapper<DatabaseClass, DomainClass> mapper)
            where DatabaseClass : class, new()
            where DomainClass : BaseDTO, new()
        {

            PagingCollectionDTO<object> pagingCollection = new PagingCollectionDTO<object>();

            if (string.IsNullOrEmpty(paging.OrderByColumnName))
            {
                paging.OrderByColumnName = "Id";
            }

            if (paging.SortingOrder == Enumerators.SortOrderEnum.Ascending)
            {
                query = query.OrderBy(paging.OrderByColumnName);
            }
            else
            {
                query = query.OrderByDescending(paging.OrderByColumnName);
            }

            pagingCollection.NumOfTotalRecords = query.Count();

            query = query.Skip(paging.NumElementsPerPage * (paging.CurrentPageIndex - 1));
            query = query.Take(paging.NumElementsPerPage);

            var items = query.ToList();

            var mappedItems = mapper.ToDtoList(items);

            pagingCollection.Items = mappedItems.Cast<object>().ToList();

            return pagingCollection;
        }





    }
}
