using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Models.DB;
using GenericCodebook.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Mappers
{
    public class TestCodebookMapper : IDomainSideMapper<TestCodebook, TestCodebookDTO>, IDatabaseSideMapper<TestCodebook, TestCodebookDTO>
    {
        public TestCodebook ToDatabase(TestCodebookDTO origin)
        {
            if (origin == null)
            {
                return null;
            }

            var result = new TestCodebook
            {
                Id = origin.Id,
                Name = origin.Name
            };

            return result;
        }

        public IEnumerable<TestCodebook> ToDatabaseList(IEnumerable<TestCodebookDTO> dtoList)
        {
            return ToDatabaseList(dtoList);
        }

        public List<TestCodebook> ToDatabaseList(List<TestCodebookDTO> dtoList)
        {
            List<TestCodebook> result = new List<TestCodebook>();

            if(dtoList == null)
            {
                return result;
            }

            foreach(var item in dtoList)
            {
                result.Add(ToDatabase(item));
            }

            return result;
        }

        public TestCodebookDTO ToDto(TestCodebook origin)
        {
            if (origin == null)
            {
                return null;
            }

            var result = new TestCodebookDTO
            {
                Id = origin.Id,
                Name = origin.Name
            };

            return result;
        }

        public List<TestCodebookDTO> ToDtoList(List<TestCodebook> databaseObjectList)
        {
            List<TestCodebookDTO> result = new List<TestCodebookDTO>();

            if (databaseObjectList == null)
            {
                return result;
            }

            foreach (var item in databaseObjectList)
            {
                result.Add(ToDto(item));
            }

            return result;
        }

        public IEnumerable<TestCodebookDTO> ToDtoList(IEnumerable<TestCodebook> databaseObjectList)
        {
            return ToDtoList(databaseObjectList);
        }

    }
}
