using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChinookMusicStore.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace ChinookMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Home"] = _localizer["Home"];
            ViewData["About"] = _localizer["About"];
            ViewData["Contact"] = _localizer["Contact"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["Login"] = _localizer["Login"];
            ViewData["Featured"] = _localizer["Featured"];
            ViewData["Album1Name"] = _localizer["Album1Name"];
            ViewData["Album1Descr"] = _localizer["Album1Descr"];
            ViewData["Album2Name"] = _localizer["Album2Name"];
            ViewData["Album2Descr"] = _localizer["Album2Descr"];
            ViewData["Album3Name"] = _localizer["Album3Name"];
            ViewData["Album3Descr"] = _localizer["Album3Descr"];
            ViewData["Album4Name"] = _localizer["Album4Name"];
            ViewData["Album4Descr"] = _localizer["Album4Descr"];
            ViewData["Album5Name"] = _localizer["Album5Name"];
            ViewData["Album5Descr"] = _localizer["Album5Descr"];
            ViewData["Album6Name"] = _localizer["Album6Name"];
            ViewData["Album6Descr"] = _localizer["Album6Descr"];
            return View();
        }

        public IActionResult About()
        {
            ViewData["Home"] = _localizer["Home"];
            ViewData["About"] = _localizer["About"];
            ViewData["Contact"] = _localizer["Contact"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["Login"] = _localizer["Login"];
            ViewData["AboutUs"] = _localizer["AboutUs"];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Home"] = _localizer["Home"];
            ViewData["About"] = _localizer["About"];
            ViewData["Contact"] = _localizer["Contact"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["Login"] = _localizer["Login"];
            ViewData["AboutUs"] = _localizer["AboutUs"];

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
