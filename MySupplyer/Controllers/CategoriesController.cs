using Microsoft.AspNetCore.Mvc;
using MySupplyer.Repository;

namespace MySupplyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController:ControllerBase
    {
        private readonly CategoriesRepository categoriesRepository;

        public CategoriesController()
        {
            categoriesRepository = new CategoriesRepository();
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return Ok(categoriesRepository.GetCategories());
        }
        
        [HttpGet("GetCategoriesByName/{name}")]
        public IActionResult GetCategoriesByName(string name)
        {
            var d = categoriesRepository.GetCategory(name);
            return Ok(d);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoriesById(int id)
        {
            return Ok(categoriesRepository.GetCategory(id));
        }
    }
}
