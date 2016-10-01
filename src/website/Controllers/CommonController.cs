using Microsoft.AspNetCore.Mvc;
using mwg.cms4.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace website.Controllers
{
    public class CommonController : Controller
    {

        private IUnitOfWork uow;

        public CommonController(mwg.cms4.core.interfaces.IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public FileContentResult ContentImage(int PhotoId)
        {
            var document = uow.ContentImageRepository;


            var image = document.GetImageById(PhotoId);

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = image.FileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = true
            };

            var blob = document.GetBlobById(PhotoId);

            //Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(blob, image.MimeType);
        }

        public FileContentResult FotobookImage(int PhotoId, int width = 0, int height = 0)
        {
            var document = uow.FotoBookImageRepository;


            var image = document.GetImageById(PhotoId);

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = image.FileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = true
            };

            var blob = document.GetBlobById(PhotoId);


            if (width > 0 || height > 0)
            {
                blob = new mwg.library.imaging.ImageResizer().ResizeImage(blob, width, height);
            }

            //Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(blob, image.MimeType);
        }



    }
}
