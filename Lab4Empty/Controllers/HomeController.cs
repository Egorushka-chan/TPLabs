using System.Collections.Generic;

using Lab4Empty.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Lab4Empty.Controllers
{
    public class HomeController : Controller
    {
        private const int RequiedValue = 15;
        public IActionResult Index()
        {
            ViewBag.RequiedValue = RequiedValue;
            ViewBag.State = CalcState.Start;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string mybutton, int first, int second, string operand)
        {
            if (mybutton == "Очистить")
            {
                ModelState.Clear();
                return View();
            }

            float result = 0;
            switch (operand)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "/":
                    result = (float)first / (float)second;
                    break;
                case "*":
                    result = first * second;
                    break;
            }

            if (result == RequiedValue)
            {
                ViewBag.RequiedValue = RequiedValue;
                ViewBag.State = CalcState.Correct;
            }
            else
            {
                ViewBag.RequiedValue = RequiedValue;
                ViewBag.State = CalcState.Incorrect;
            }


            return View(new Calculator
            {
                LastResult = new Calculator
                {
                    First = first,
                    Second = second,
                    Result = result,
                    Operand = operand
                }
            });
        }

        public IActionResult GetResultPage(string first, string second, string operand, string result)
        {

            ViewBag.ResultStringOne = first + operand + second + "=" + result;
            string resultStringSecond = first + operand + second + " = " + result;

            if (resultStringSecond.IndexOf("+") != -1)
            {
                int pos = resultStringSecond.IndexOf("+");
                resultStringSecond = resultStringSecond.Substring(0, pos) + " плюс " + resultStringSecond.Substring(pos + 1, resultStringSecond.Length - pos - 1);
            }

            if (resultStringSecond.IndexOf("/") != -1)
            {
                int pos = resultStringSecond.IndexOf("/");
                resultStringSecond = resultStringSecond.Substring(0, pos) + " делить на " + resultStringSecond.Substring(pos + 1, resultStringSecond.Length - pos - 1);
            }
            if (resultStringSecond.IndexOf("-") != -1)
            {
                int pos = resultStringSecond.IndexOf("-");
                resultStringSecond = resultStringSecond.Substring(0, pos) + " минус " + resultStringSecond.Substring(pos + 1, resultStringSecond.Length - pos - 1);
            }
            if (resultStringSecond.IndexOf("*") != -1)
            {
                int pos = resultStringSecond.IndexOf("*");
                resultStringSecond = resultStringSecond.Substring(0, pos) + " умножить на " + resultStringSecond.Substring(pos + 1, resultStringSecond.Length - pos - 1);
            }
            ViewBag.ResultStringSecond = resultStringSecond;
            return View("Result");
        }
    }
}
