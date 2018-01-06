using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq;

namespace Client.Controllers
{
      [Route("api/[controller]/[action]")]
        public class HomeController : Controller
    {
        [HttpGet(Name="fzf003")]
        public Person Index()
        {
            return  new Person();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

            
           [HttpGet]
          public List<Person> GetList()
        {
            return Enumerable.Range(1,100)
            .Select(p=>new Person())
            .ToList();
            
        }

         [HttpGet]
        public string Sum(int a, int b)
        {
            return (a+b).ToString();
        }

    }
}