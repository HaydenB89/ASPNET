using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        public IActionResult Index() {
            ViewBag.FV = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(FutureValueModel model) {
            ViewBag.FV = model.CalculateFutureValue();
            return View(model);
        }

    }
}
