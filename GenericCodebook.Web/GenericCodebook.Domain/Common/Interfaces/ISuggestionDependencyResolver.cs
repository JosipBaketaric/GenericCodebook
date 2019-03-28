using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.Domain.Common.Interfaces
{
    public interface ISuggestionDependencyResolver
    {
        ISuggestionService GetSuggestionService(string suggestionServiceName);
        ISuggestionService GetSuggestionService(object suggestionServiceName);

    }
}
