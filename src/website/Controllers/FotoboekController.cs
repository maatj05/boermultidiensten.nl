using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mwg.cms4.core.interfaces;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace website.Controllers
{
    public class FotoboekController : Controller
    {
        private IUnitOfWork uow;
        private IHostingEnvironment hostingEnvironment;

        // GET: /<controller>/

        public FotoboekController(mwg.cms4.core.interfaces.IUnitOfWork uow, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.uow = uow;
        }

        public IActionResult Index()
        {


            //Maak hardcopies



            var rep = uow.FotoBookRepository;
            var rep2 = uow.FotoBookImageRepository;
            foreach (var fb in rep.FotoBooks)
            {
                foreach (var item in fb.Fotos)
                {
                    string fileName = System.IO.Path.Combine(hostingEnvironment.WebRootPath, $"images\\img_{item.Id}.jpg");
                    if (!System.IO.File.Exists(fileName))
                    {
                        using (var file = System.IO.File.OpenWrite(fileName))
                        {
                            var blob = rep2.GetBlobById(item.Id);

                            file.Write(blob, 0, blob.Length);
                        }
                    }
                }
            }


            return View("fancybox", rep);
        }
        public IActionResult Detail(int id)
        {
            return View(uow.FotoBookRepository.FotoBooks.Single(x => x.FotoboekId == id));
        }
    }
}
