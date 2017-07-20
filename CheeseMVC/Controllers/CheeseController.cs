using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
	public class CheeseController : Controller
	{
		private static Dictionary<string, string> Cheeses = new Dictionary<string, string>();

		// GET: /<controller>/
		public IActionResult Index()
		{
			ViewBag.cheeses = Cheeses;

			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[Route("/cheese/add")]
		public IActionResult NewCheese(string name, string description)
		{
			// Add the new cheese to my existing cheeses
			try
			{
				Cheeses.Add(name, description);
			} catch (Exception ex)
			{
				ViewBag.error = ex.Message;
				return View("Add");
			}
			

			return Redirect("/cheese");
		}

		public IActionResult Remove()
		{
			ViewBag.cheeses = Cheeses;

			return View();
		}

		[HttpPost]
		[Route("/cheese/remove")]
		public IActionResult RemoveCheese(string[] cheeses)
		{
			foreach (string cheese in cheeses)
			{
				Cheeses.Remove(cheese);
			}

			return Redirect("/cheese");
		}
	}
}
