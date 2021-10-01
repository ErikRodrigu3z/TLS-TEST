using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TLS_TEST.Models;
using SslLabsLib;
using SslLabsLib.Enums;
using Newtonsoft.Json;

namespace TLS_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Test(string url)
        {
            try
            {
                SslLabsClient ssl = new SslLabsClient();
                var res = ssl.GetAnalysisBlocking(url, 24, AnalyzeOptions.Publish | AnalyzeOptions.IgnoreMismatch);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                string json = JsonConvert.SerializeObject(res, settings);
                SSLdto dto = JsonConvert.DeserializeObject<SSLdto>(json);
               

                return Json(json);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
