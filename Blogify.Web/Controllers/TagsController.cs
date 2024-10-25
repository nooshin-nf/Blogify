using Blogify.CoreAPI.V1;
using Blogify.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blogify.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly CoreApiV1 _coreApiV1;
        public TagsController(IOptions<ServiceUrls> options,
            IHttpClientFactory httpClientFactory)
        {
            var urls = options.Value;
            _coreApiV1 = new CoreApiV1(urls.CoreUrl, httpClientFactory.CreateClient());
        }
        public async Task<IActionResult> Index()
        {
            await _coreApiV1.TagsGETAsync();
            return View();
        }
    }
}
