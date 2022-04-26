using First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace First.Controllers
{
    [Route("/api/[controller]")]
    public class Products : Controller
    {
        private static List<Product> products = new List<Product>(new[]{
	    new Product() {id =1, Name = "Mercedes", Price =10000},
	    new Product() {id =2, Name = "Audi", Price =8999},
	});

	[HttpGet]
	public IEnumerable<Product> Get() => products;

	[HttpGet("(id)")]
	public IActionResult Get(int id)
	{
	    var product = products.SingleOrDefault(p =>p.id ==id);
	    
	    if (product == null)
	    {
		return NotFound();
	    }
	    return Ok(product);
	}
	


//	public IActionResult Index()
//	{
//	    return View();
//	}
    }
}