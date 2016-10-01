using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace website.Controllers
{
    public class FormulierenController:Controller
    {
        public IActionResult Jeugdzeilen()
        {
            return View("index",  "https://form.jotformeu.com/jsform/62593195047361");
        }
    }
}
