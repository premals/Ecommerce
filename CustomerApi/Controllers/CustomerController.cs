using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISearchService searchService;

        public CustomerController(
            ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet("Search/{customerId}")]
        public async Task<IActionResult> Search(int customerId)
        {
            var result = await searchService.SearchAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return NotFound();
        }
    }
}