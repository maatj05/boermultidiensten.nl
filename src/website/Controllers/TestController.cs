using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace website.Controllers
{
    public class TestController : Controller
    {
        private IHostingEnvironment env;

        public TestController(IConfigurationRoot config,  IHostingEnvironment env)
        {
            this.Configuration = config;
            this.env = env;
        }

        public IConfigurationRoot Configuration { get; private set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var c = Configuration.GetConnectionString("DefaultConnection");

            ViewBag.Conn = c;
            ViewBag.Env = env.EnvironmentName;
            return View();
        }
    }
}
