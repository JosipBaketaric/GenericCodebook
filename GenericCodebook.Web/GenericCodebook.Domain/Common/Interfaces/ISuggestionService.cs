using GenericCodebook.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface ISuggestionService
    {
        IEnumerable<LongOptionDTO> GetAutocompleteSuggestions(SuggestionFilterDTO suggestionFilter);

    }
}
