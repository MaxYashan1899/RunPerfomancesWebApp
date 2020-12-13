using System;
using System.Web.Mvc;
using RunPerfomancesWebApp.Models;

namespace RunPerfomancesWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetPaceAndTime()
        {
            return View();
        }

        public ActionResult CountPaceAndTime(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                CalcPace(perfomances);
                perfomances.Time = perfomances.Distance / perfomances.Speed * 60;
                CalcTime(perfomances);
                return View("~/Views/Home/CountPaceAndTime.cshtml", perfomances);
            }
            else
            {
                return View("~/Views/Home/GetPaceAndTime.cshtml", perfomances);
            }
       
         }
       
        public ActionResult GetSpeedAndDistance()
        {
            return View();
        }

        public ActionResult CountSpeedAndDistance(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                perfomances.Speed = Math.Round((60 / perfomances.Pace), 2);
                perfomances.Distance = Math.Round((perfomances.Time / perfomances.Pace), 2);
                return View("~/Views/Home/CountSpeedAndDistance.cshtml", perfomances);
            }
            else
                return View("~/Views/Home/GetSpeedAndDistance.cshtml", perfomances);
        }
        public ActionResult GetSpeedAndTime()
        {
            return View();
        }

        public ActionResult CountSpeedAndTime(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                perfomances.Speed = Math.Round((60 / perfomances.Pace), 2);
                perfomances.Time = Math.Round(60 * (perfomances.Distance / (60 / perfomances.Pace)), 2);
                CalcTime(perfomances);
                return View("~/Views/Home/CountSpeedAndTime.cshtml", perfomances);
            }
            else
                return View("~/Views/Home/GetSpeedAndTime.cshtml", perfomances);
        }
        public ActionResult GetPaceAndDistance()
        {
            return View();
        }

        public ActionResult CountPaceAndDistance(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                CalcPace(perfomances);
                perfomances.Distance = Math.Round((perfomances.Time / 60 * perfomances.Speed), 2);
                return View("~/Views/Home/CountPaceAndDistance.cshtml", perfomances);
            }
            else
                return View("~/Views/Home/GetPaceAndDistance.cshtml", perfomances);
        }

        public ActionResult GetPaceAndSpeed()
        {
            return View();
        }

        public ActionResult CountPaceAndSpeed(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                perfomances.Speed = Math.Round(perfomances.Distance / (perfomances.Time / 60), 2);
                CalcPace(perfomances);
                return View("~/Views/Home/CountPaceAndSpeed.cshtml", perfomances);
            }
            else
                return View("~/Views/Home/GetPaceAndSpeed.cshtml", perfomances);
        }
        public ActionResult GetPace()
        {
            return View();
        }

        public ActionResult CountPace(RunPerfomances perfomances)
        {
            if (ModelState.IsValid)
            {
                CalcPace(perfomances);
                return View("~/Views/Home/CountPace.cshtml", perfomances);
            }
            else
                return View("~/Views/Home/GetPace.cshtml", perfomances);

        }
        private void CalcPace(RunPerfomances perfomances)
        {
            var pace = 60 / perfomances.Speed;
            var paceInMinutes = Math.Floor(pace / 1);
            double paceInSeconds = Math.Round((pace % 1) * 60, 0);
            perfomances.Pace = double.Parse(paceInMinutes + "," + paceInSeconds);
        }
        private void CalcTime(RunPerfomances perfomances)
        {
            perfomances.Hours = Math.Floor(perfomances.Time / 60);
            perfomances.Minutes = Math.Round((perfomances.Time % 60), 0);
        }
    }
}