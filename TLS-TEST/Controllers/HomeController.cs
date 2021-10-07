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
using System.Net;
using System.IO;
using System.Security.Authentication;
using System.Net.Security;
using System.Reflection;
using System.IO.Compression;

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
                var TlsTest = ProcessProtocols(url);
                string json = JsonConvert.SerializeObject(TlsTest, Settings());
                return Json(TlsTest);  
            }
            catch (Exception ex) 
            {
                string json = JsonConvert.SerializeObject(ex, Settings());
                return Json(json);
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

        #region Methods

        public string GetProtocols(string url)
        {
            try
            {
                SslLabsClient ssl = new SslLabsClient();
                var res = ssl.GetAnalysisBlocking(url, 0, AnalyzeOptions.ReturnAll | AnalyzeOptions.ReturnAll);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                string protocolsJson = JsonConvert.SerializeObject(res.Endpoints[0].Details.Protocols, settings);
                return protocolsJson;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        private Dictionary<SecurityProtocolType, bool> ProcessProtocols(string address)
        {
            //diccionario de tls
            var protocolResultList = new Dictionary<SecurityProtocolType, bool>();
            var defaultProtocol = ServicePointManager.SecurityProtocol;

            ServicePointManager.Expect100Continue = true;
            foreach (var protocol in GetValues<SecurityProtocolType>())
            {
                try
                {                    
                    ServicePointManager.SecurityProtocol = protocol;
                    var request = WebRequest.Create(address);
                    var response = request.GetResponse();
                    //el protocolo encontrado
                    protocolResultList.Add(protocol, true);
                }
                catch
                {
                    //si falla agrega false al protocolo
                    protocolResultList.Add(protocol, false);
                }
            }

            ServicePointManager.SecurityProtocol = defaultProtocol;

            return protocolResultList;
        }

        public JsonSerializerSettings Settings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return settings;
        }


        #endregion




    }
}
