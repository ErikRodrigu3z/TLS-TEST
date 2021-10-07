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
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(
              "https://clienttest.ssllabs.com:8443/ssltest/viewMyClient.html");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Debug.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Debug.WriteLine(responseFromServer);
            }

            // Close the response.
            response.Close();


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
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                string json = JsonConvert.SerializeObject(res, settings);
                SSLdto dto = JsonConvert.DeserializeObject<SSLdto>(json);
               

                return Json(json);
            }
            catch (Exception ex) 
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore                    
                };

                string json = JsonConvert.SerializeObject(ex, settings);
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
    }
}
