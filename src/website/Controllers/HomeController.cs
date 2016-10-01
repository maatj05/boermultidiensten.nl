using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mwg.cms4.core.interfaces;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork uow;

        public HomeController(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IActionResult Index()
        {
            
            var model = uow.ContentRepository.GetContentByTitle("home");

            if (string.IsNullOrEmpty(model.LayoutPage))
            {
                ViewBag.layout = "~/Views/Shared/_Layout.cshtml";
            }
            else
            {
                ViewBag.layout = $"~/Views/Shared/{model.LayoutPage}.cshtml";
            }
            return View(model);

        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
