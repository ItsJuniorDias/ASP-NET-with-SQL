using BDProjeto.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
      

        public ActionResult Index()
        {
           
            return View();
        
        }

        public ActionResult Index1()
        {

            return WebFormViewEngine();

        }

        private ActionResult WebFormViewEngine()
        {
            throw new NotImplementedException();
        }
    }
}