using Microsoft.AspNetCore.Mvc;
using mwg.cms4.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace website.Controllers
{
    public class ArtikelController:Controller
    {
        private IUnitOfWork uow;

        public ArtikelController(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }


        [Route("[controller]/{id}")]
        //[Route("all")]
        [Route("~/")]
        public IActionResult Index(string id)
        {

            id = id ?? "Home";
            var model = uow.ContentRepository.GetContentByTitle(id);

            if (string.IsNullOrEmpty(model?.LayoutPage))
            {
                ViewBag.layout = "~/Views/Shared/_Layout.cshtml";

            }
            else
            {
                ViewBag.layout = $"~/Views/Shared/{model.LayoutPage}.cshtml";
            }
            return View( model);
        }
    }
}
