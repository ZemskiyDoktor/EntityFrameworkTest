using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FE.Controllers
{
    [Route("[controller]")]
    public class IndexController : Controller
    {
        private readonly ILogger _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }
        public IActionResult SomeMethod()
        {
            int id = 3;
            _logger.LogWarning(234, $"log information {3} in some method");
            return Content("Hello SomeMethod");
        }

        [Route("an")]
        public IActionResult AnotherMethod()
        {
            return Content("Hello AnotherMethod");
        }
    }
}