using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCodebook.Web.Controllers
{
    /// <summary>
    /// Controller that handles every request for codebooks
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CodeBookController : ControllerBase
    {
        private readonly ICodeBookDependencyResolver _codeBookDependencyResolver;
        private readonly ISuggestionDependencyResolver _suggestionDependencyResolver;

        public CodeBookController(ICodeBookDependencyResolver codeBookDependencyResolver, ISuggestionDependencyResolver suggestionDependencyResolver)
        {
            this._codeBookDependencyResolver = codeBookDependencyResolver;
            this._suggestionDependencyResolver = suggestionDependencyResolver;
        }


        [HttpGet]
        [Route("getById/{sifName}/{id}")]
        public IActionResult GetById(string sifName, long id)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(sifName);
            var result = service.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Gets filtered and sorted values
        /// </summary>
        /// <param name="filter">Needs to be of type BaseCodebookFilter + other values that are injected from angular dynamically</param>
        /// <returns></returns>
        [HttpPost]
        [Route("getFiltered")]
        public IActionResult GetFiltered(object filter)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(filter);
            var result = service.GetFiltered(filter);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(object baseCodebook)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(baseCodebook);
            var codeBook = JsonConvert.DeserializeObject<BaseCodebookDTO>(baseCodebook.ToString());
            var result = service.Create(codeBook.Item);
            return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(object baseCodebook)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(baseCodebook);
            var codeBook = JsonConvert.DeserializeObject<BaseCodebookDTO>(baseCodebook.ToString());
            var result = service.Update(codeBook.Item);
            return Ok(result);
        }


        [HttpGet]
        [Route("delete/{sifName}/{id}")]
        public IActionResult Delete(string sifName, long id)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(sifName);
            service.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("loadChildren/{sifName}/{id}")]
        public IActionResult LoadChildren(string sifName, long id)
        {
            var service = this._codeBookDependencyResolver.GetCodeBookService(sifName);
            var result = service.LoadChildren(id);
            return Ok(result);
        }

        /// <summary>
        /// Used for dropdowns and autocomplete
        /// </summary>
        /// <param name="suggestionFilter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getAutocompleteSuggestions/{sifName}")]
        public IActionResult GetAutocompleteSuggestions(SuggestionFilterDTO suggestionFilter)
        {
            var service = this._suggestionDependencyResolver.GetSuggestionService(suggestionFilter);
            var result = service.GetAutocompleteSuggestions(suggestionFilter);
            return Ok(result);
        }

    }
}
