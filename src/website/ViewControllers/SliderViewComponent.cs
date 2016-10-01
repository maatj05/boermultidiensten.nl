using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mwg.cms4.core.interfaces;
using mwg.cms4.core.interfaces.entities;

namespace website.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private IUnitOfWork uow;

        public SliderViewComponent(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IViewComponentResult Invoke()
        {
            var p = RouteData.Values["Id"]?.ToString();
            p = p ?? "home";




            List<IImage> lst = uow.ContentRepository.GetContentByTitle(p)?.Photos;

            if (lst == null || !lst.Any() && p != "home")
            {
                lst = uow.ContentRepository.GetContentByTitle("home").Photos;
            }

            return View(lst);
        }
    }
}
