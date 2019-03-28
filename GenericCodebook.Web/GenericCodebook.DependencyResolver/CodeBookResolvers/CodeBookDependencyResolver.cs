using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Common.Models;
using GenericCodebook.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.DependencyInjection;


namespace GenericCodebook.DependencyResolver.CodeBookResolvers
{
    /// <summary>
    /// Register every codebook service here in order to work with generic controller
    /// </summary>
    public class CodeBookDependencyResolver : ICodeBookDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public CodeBookDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICodeBookService GetCodeBookService(string codeBookServiceName)
        {
            object service = null;

            // Mapping
            if (codeBookServiceName == "TestCodebook") 
            {
                service = _serviceProvider.GetService<ICodebookTestService>();

            }


            //Last check if it implements ISuggestionService interface
            if (service != null && service is ICodeBookService)
            {
                return service as ICodeBookService;
            }

            return null;
        }

        public ICodeBookService GetCodeBookService(object baseCodebookFilter)
        {
            if (baseCodebookFilter == null)
            {
                return null;
            }

            var filter = JsonConvert.DeserializeObject<BaseCodebookFilter>(baseCodebookFilter.ToString());

            if (filter == null)
            {
                return null;
            }

            return GetCodeBookService(filter.CodebookName);
        }
    }
}
