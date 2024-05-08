using Lab5.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        static Table[] _tables = new Table[] { };

        [HttpPost]
        public IActionResult Index(string myButton, Table table) // View
        {
            if (myButton == "Добавить")
            {
                _tables = _tables.Extend(table);
                ModelState.Clear();
                return View("Editor", new Table());
            }
            else // myButton == "Завершить"
            {
                ViewBag.Length = _tables.Length;
                ViewBag.Current = 1;
                
                Response.Cookies.Append("current", "1");

                return View(_tables[0]);
            }
        }

        public IActionResult Index() 
        {
            return View("Editor", new Table());
        }

        public IActionResult GetTableFuther()
        {
            string? id = Request.Cookies["current"];     
            if (id == null)
            {
                ViewBag.Length = _tables.Length;
                ViewBag.Current = 1;
                return View(_tables[0]);
            }
            else
            {
                int newTable = int.Parse(id) + 1;
                Response.Cookies.Append("current", newTable.ToString());

                ViewBag.Length = _tables.Length;
                ViewBag.Current = newTable;

                return View("Index", _tables[newTable-1]);
            }
        }

        public IActionResult GetTablePrevious()
        {
            string? id = Request.Cookies["current"];     
            if (id == null)
            {
                ViewBag.Length = _tables.Length;
                ViewBag.Current = 1;
                return View(_tables[0]);
            }
            else
            {
                int newTable = int.Parse(id) -1;
                Response.Cookies.Append("current", newTable.ToString());

                ViewBag.Length = _tables.Length;
                ViewBag.Current = newTable;

                return View("Index", _tables[newTable-1]);
            }
        }

        public IActionResult GetAllTables()
        {
            bool rand = new Random().Next(2) == 0? true: false;
            ViewData["randomBool"] = rand;
            return View("AllElements", _tables);
        }
    }
}
