using System;
using System.Linq;
using System.Web.Mvc;
using SummatorInASPMVC.Models;

namespace SummatorInASPMVC.Controllers
{
    public class SummatorController : Controller
    {
        public ActionResult Sum(SummatorModel model)
        {
            var firstNumber = model.FirstNumber;
            var secondNumber = model.SecondNumber;
            var result = firstNumber + secondNumber;
            model.Result = result;
            return View(model);
        }
    }
}