using GenericCodebook.Domain.Common.Implementations;
using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Common.Models;
using GenericCodebook.Domain.Mappers;
using GenericCodebook.Domain.Models.DB;
using GenericCodebook.Domain.Models.DTO;
using GenericCodebook.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCodebook.Domain.Services.Implementations
{
    public class CodebookTestService : BaseCodeBookService, ICodebookTestService, ICodeBookService, ISuggestionService
    {
        private readonly List<TestCodebook> _db;
        private readonly TestCodebookMapper _mapper;

        public CodebookTestService()
        {
            _db = new List<TestCodebook>
            {
                new TestCodebook(1),
                new TestCodebook(2),
                new TestCodebook(3),
                new TestCodebook(4),
                new TestCodebook(5),
                new TestCodebook(6),
                new TestCodebook(7),
                new TestCodebook(8),
                new TestCodebook(9),
                new TestCodebook(10),
                new TestCodebook(11),
                new TestCodebook(12),
                new TestCodebook(13),
                new TestCodebook(14),
                new TestCodebook(15),
                new TestCodebook(16),
                new TestCodebook(17),
                new TestCodebook(18),
                new TestCodebook(19),
                new TestCodebook(20),
                new TestCodebook(21),
                new TestCodebook(22),
            };

            _mapper = new TestCodebookMapper();
        }


        #region ISuggestionService
        public IEnumerable<LongOptionDTO> GetAutocompleteSuggestions(SuggestionFilterDTO suggestionFilter)
        {
            var query = _db.AsQueryable();

            if (string.IsNullOrEmpty(suggestionFilter.Filter))
            {
                suggestionFilter.Filter = suggestionFilter.Filter.Trim().ToLower();
                query = query.Where(x => x.Name.Trim().ToLower().Contains(suggestionFilter.Filter));
            }

            query = query.OrderBy(x => x.Name);

            if (!suggestionFilter.GetAll)
            {
                query = query.Take(20);
            }

            var items = query.ToList();

            var result = new List<LongOptionDTO>();
            items.ForEach(x => result.Add(new LongOptionDTO { Id = x.Id, Text = x.Name }));

            return result;
        }
        #endregion



        #region ICodeBookService
        public object Create(object val)
        {
            // First needs to deserialize object to specific DTO
            var serializedObject = HandleObjectDeserialization<TestCodebookDTO>(val);

            // custom mapper can be used

            var itemToSave = _mapper.ToDatabase(serializedObject);
            this._db.Add(itemToSave);
            //this._unitOfWork.SaveChanges();
            // You can return anything but it is best to return same object (it has id in it)
            return _mapper.ToDto(itemToSave);

        }

        public object Update(object val)
        {
            var serializedObject = HandleObjectDeserialization<TestCodebookDTO>(val);

            //Find db object
            var itemToUpdate = this._db.FirstOrDefault(x => x.Id == serializedObject.Id);

            if (itemToUpdate == null)
            {
                throw new Exception($"Object with id: {serializedObject.Id} not found.");
            }

            // Handle update logic somewhere in service
            itemToUpdate.Name = serializedObject.Name;

            //this._unitOfWork.SaveChanges();

            return itemToUpdate;

        }

        public void Delete(long id)
        {
            var itemToDelete = this._db.FirstOrDefault(x => x.Id == id);

            if (itemToDelete == null)
            {
                throw new Exception($"Object with id: {id} not found.");
            }

            this._db.Remove(itemToDelete);
            //this._unitOfWork.SaveChanges();
        }



        public object GetById(long id)
        {
            var dbResult = this._db.FirstOrDefault(x => x.Id == id);


            return JsonConvert.SerializeObject(_mapper.ToDto(dbResult));

        }

        public PagingCollectionDTO<object> GetFiltered(object filter)
        {
            // Every filter has to derive from PagingDTO
            var serializedFilter = HandleObjectDeserialization<TestCodebookFilterDTO>(filter);

            // Apply filters
            var query = this._db.AsQueryable();

            // best practice is to set filters in other method to have clean code
            query = ApplyFilters(query, serializedFilter);

            // Result is always sent in PagingCollectionDTO<>
            PagingCollectionDTO<TestCodebookDTO> result = new PagingCollectionDTO<TestCodebookDTO>();

            return CreatePagingCollection(query, serializedFilter, _mapper);

        }

        /// <summary>
        /// Used for loading codebook children that have 1 to many relationship
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<RegistryChildrenDTO> LoadChildren(long id)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Helpers

        protected IQueryable<TestCodebook> ApplyFilters(IQueryable<TestCodebook> query, TestCodebookFilterDTO filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                filter.Name = filter.Name.ToLower().Trim();
                query = query.Where(x => x.Name.ToLower().Trim().Contains(filter.Name));
            }

            return query;
        }
        #endregion


    }
}
