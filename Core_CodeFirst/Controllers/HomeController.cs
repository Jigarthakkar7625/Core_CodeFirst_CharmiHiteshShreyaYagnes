using Core_CodeFirst.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Core_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransient _transientService1;
        private readonly IEmployees _employeesService1;
        private readonly ITransient _transientService2; // No life time
        private readonly IScoped _scopedService1;
        private readonly IScoped _scopedService2; // Refresh
        private readonly ISingleton _singletonService1; // Permenet
        private readonly ISingleton _singletonService2;

        //private readonly ITransient _employees;

        //public HomeController(IEmployees employees) // Depency Injection
        public HomeController(ILogger<HomeController> logger, ITransient transientService1, ITransient transientService2, IScoped  scopedService1, IScoped scopedService2, ISingleton singletonService1, ISingleton singletonService2)
        {

            //_employeesService1 = employees;
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            //_employees = employees;
        }

        public IActionResult Index()
        {

            //var getALLEMp = _employeesService1.GetAllEmployee(); // DB mathi record ave che
            // N Tier


            //var a = _employees.GetAllEmployee();
            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();
            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();
            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public int getWordCount(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var strSplit = name.Split(' ');
                var count = strSplit.Length;
                return count;
            };
            return 0;
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        // Unit testing >> Developer > TDD > Test driven development
        // Testcases write
        // API nu testing Postman
        // 
    }
}