using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> recentCalculations = new List<string>    {
        "1 + 2 = 3",
        "3 * 2 = 6",
        "5 - 3 = 2",
        "10 / 2 = 5",
        "4 + 1 = 5"
    };
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["RecentCalculations"] = recentCalculations;
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double firstNumber, string operation, double secondNumber)
        {
            double result = 0;
            string calculation = $"{firstNumber} {operation} {secondNumber} = ";

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = secondNumber != 0 ? firstNumber / secondNumber : 0;
                    break;
                default:
                    calculation = "Invalid Operation";
                    break;
            }

            calculation += result;
            ViewData["Result"] = result;

            // Add to recent calculations
            recentCalculations.Insert(0, calculation);

            // Keep only the last 5 calculations
            if (recentCalculations.Count > 5)
            {
                recentCalculations.RemoveAt(5);
            }

            ViewData["RecentCalculations"] = recentCalculations;
            return View("Index");
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
