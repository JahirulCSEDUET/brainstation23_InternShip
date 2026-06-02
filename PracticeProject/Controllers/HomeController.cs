using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using PracticeProject.Services;
using PracticeProject.UnderstandingFluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;
        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;
        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;

        // Constructor Injection
        public HomeController(
            IScopedGuidService scoped1,
            IScopedGuidService scoped2,
            ISingletonGuidService singleton1,
            ISingletonGuidService singleton2,
            ITransientGuidService transient1,
            ITransientGuidService transient2)
        {
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            // For Understanding Fluent Validation
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student input)
        {
            // For Understanding Fluent Validation
            var validator = new StudentValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(input);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(input);
            }
            return Content("Student validated and saved successfully!");
        }
        public IActionResult Privacy()
        {
            //for understanding mvc Lifecycle
            var messages = new StringBuilder();
            messages.Append($"Transient 1: {_transient1.GetGuid()}\n");
            messages.Append($"Transient 2: {_transient2.GetGuid()}\n\n");
            messages.Append($"Scoped 1: {_scoped1.GetGuid()}\n");
            messages.Append($"Scoped 2: {_scoped2.GetGuid()}\n\n");
            messages.Append($"Singleton 1: {_singleton1.GetGuid()}\n");
            messages.Append($"Singleton 2: {_singleton2.GetGuid()}\n\n");
            return Ok(messages.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
