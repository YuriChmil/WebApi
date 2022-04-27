using First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace First.Controllers
{
    [Route("/api/[controller]")]
    public class Test : Controller
    {
        private static List<Product> products = new List<Product>(new[]{
	    new Product() {id =1, Name = "Mercedes", Price =10000},
	    new Product() {id =2, Name = "Audi", Price =899},
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
	
	[HttpDelete("(id)")]
	public IActionResult Delete (int id)
	{
	    products.Remove(products.SingleOrDefault(p =>p.id == id));
	    return Ok();
	}
    }
}