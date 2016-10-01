using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mwg.cms4.core.interfaces;

namespace website.ViewComponents
{
    public class ArtikelViewComponent: ViewComponent
    {
        private IUnitOfWork uow;

        public ArtikelViewComponent(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IViewComponentResult Invoke(string name)
        {
            var model1 = uow.ContentRepository.GetContentByTitle(name);
            return View(model1);
        }


    }
}
