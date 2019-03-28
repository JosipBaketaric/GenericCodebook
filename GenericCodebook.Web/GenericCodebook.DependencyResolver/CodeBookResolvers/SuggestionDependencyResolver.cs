using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Models.DTO;
using GenericCodebook.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.DependencyInjection;


namespace GenericCodebook.DependencyResolver.CodeBookResolvers
{
    /// <summary>
    /// Register every suggestion service here in order to work with generic controller
    /// </summary>
    public class SuggestionDependencyResolver : ISuggestionDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public SuggestionDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISuggestionService GetSuggestionService(string suggestionServiceName)
        {
            object service = null;

            // Mapping
            if (suggestionServiceName == "TestCodebook")
            {
                service = _serviceProvider.GetService<ICodebookTestService>();

            }


            //Last check if it implements ISuggestionService interface
            if (service != null && service is ISuggestionService)
            {
                return service as ISuggestionService;
            }

            return null;
        }

        public ISuggestionService GetSuggestionService(object suggestionServiceName)
        {
            if (suggestionServiceName == null)
            {
                return null;
            }

            var filter = JsonConvert.DeserializeObject<TestCodebookFilterDTO>(suggestionServiceName.ToString());

            if (filter == null)
            {
                return null;
            }

            return GetSuggestionService(filter.CodebookName);
        }
    }
}
