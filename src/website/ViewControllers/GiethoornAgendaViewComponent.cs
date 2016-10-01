using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mwg.cms4.core.interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace website.ViewComponents
{
    public class GiethoornAgendaViewComponent : ViewComponent
    {


        public GiethoornAgendaViewComponent(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {

        }

        public IViewComponentResult Invoke(int locationid, int aantal = 3)
        {
            var model = new mwg.library.giethoornagenda.apiclient().GetActivitiesByLocation(locationid, aantal);
            return View(model.OrderBy(x => x.Date));
            
        }


    }
}
