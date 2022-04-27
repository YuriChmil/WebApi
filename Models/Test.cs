using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Test
    {
	public int id {get;set;}
	[Required]
	public string Name {get;set;}
	[Required]

	public decimal Price {get;set;}
    }
}