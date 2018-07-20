using System;
using MapLocator.Data;
using MapLocator.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MapLocator.Controllers
{
	[Route("api/[Controller]")]
	public class ProductsController : Controller
	{
		private readonly IDutchRepository _repository;
		private readonly ILogger<ProductsController> _logger;

		public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_repository.GetAllProducts());
			}
			catch (Exception ex)
			{
				_logger.LogError($"failed to get products {ex}");
				return BadRequest("Failed to get products");
			}
		}
	}
}
