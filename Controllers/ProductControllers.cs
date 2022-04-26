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
	
	[HttpDelete("(id)")]
	public IActionResult Delete (int id)
	{
	    products.Remove(products.SingleOrDefault(p =>p.id == id));
	    return Ok();
	}


	private int NextProductId =>
		products.Count()==0 ? 1 : products.Max (x => x.id) +1;

	[HttpGet("AddProductId")]
	public int GetNextProductId(){
	    return NextProductId;
	}
//ADD TOVAR
	[HttpPost]
	public IActionResult Post(Product product)
	{
	    if (!ModelState.IsValid){
		return BadRequest(ModelState);//Якщо відсутній обовязковий атрибут в моделі повертаємо БЕД
	    }
	    product.id = NextProductId;
	    products.Add(product);
	    return CreatedAtAction(nameof(Get), new {id = product.id},product);
	}
	[HttpPost("AddProduct")]
	public IActionResult PostBody([FromBody] Product product) => Post(product);
//EDIT TOVAR
	[HttpPut]
	public IActionResult Put(Product product)
	{
	if (!ModelState.IsValid){
	return BadRequest(ModelState);
        }
        var storedProduct = products.SingleOrDefault (p => p.id ==product.id);
        if (storedProduct == null) return NotFound();
        storedProduct.Name = product.Name;
        storedProduct.Price = product.Price;
        return Ok(storedProduct);
        }
	[HttpPut("UpdateProduct")]
	public IActionResult PutBody([FromBody] Product product) => Put(product);

//	public IActionResult Index()
//	{
//	    return View();
//	}
    }
}