using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mwg.cms4.core.interfaces;

namespace website.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private IUnitOfWork uow;

        public MenuViewComponent(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IViewComponentResult Invoke(int id)
        {
            var model1 = uow.MenuRepository.GetMenuItem(id);
            return View(model1);
        }
    }
}
