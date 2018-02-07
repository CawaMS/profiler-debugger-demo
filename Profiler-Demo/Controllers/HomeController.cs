using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Profiler_Demo.Models;

namespace Profiler_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public HomeController(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This webpage has been fetched from Mars ...";

            var list = new List<byte[]>();
            for (var i = 0; i < 1000 ; i++)
            {
                list.Add(new byte[1024]); 
                Thread.Sleep(50); 
            }


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "An error has occurred and has been handled";

            var array = new string[10];

            try
            {
                for (int i = 0; i < 11; i++)
                {
                    array[i] = "hello";
                }
            }
            catch (Exception e)
            {

                Trace.TraceError("An error occurred: " + e);

                _telemetryClient.TrackException(e);
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
