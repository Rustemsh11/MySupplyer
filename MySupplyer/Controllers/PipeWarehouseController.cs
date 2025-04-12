using Microsoft.AspNetCore.Mvc;
using MySupplyer.Repository;

namespace MySupplyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipeWarehouseController: ControllerBase
    {
        private readonly PipeWarehouseRepository pipeWarehouseRepository;
        private readonly CategoriesRepository categoriesRepository;
        private readonly GostRepository gostRepository;

        public PipeWarehouseController()
        {
            pipeWarehouseRepository = new PipeWarehouseRepository();
            categoriesRepository = new CategoriesRepository();
            gostRepository = new GostRepository();
        }

        [HttpGet("PipeWarehouse/ReguestInfo")]
        public IActionResult GetRequestInfo()
        {
            RequestInfoDto res = new RequestInfoDto()
            {
                CategoryNames = categoriesRepository.GetCategories().Select(c => c.Name).ToList(),
                GostNames = gostRepository.GetAllGostName(),
                PipeName ="",
                SDR = 0,
                Thickness = 0,
                Diametr = 0,
            };
            return Ok(res);
        }

        [HttpGet("{categoryId:int}/{pipeId:int}")]
        public IActionResult GetPipeCountInWarehouse(int categoryId, int pipeId)
        {
            return Ok(pipeWarehouseRepository.GetWarehouseCount(categoryId, pipeId));
        }

        [HttpGet]
        public IActionResult GetAllPipesInWareHouse()
        {
            return Ok(pipeWarehouseRepository.GetAllPipesInWarehouse());
        }

        public class RequestInfoDto
        {
            public List<string> CategoryNames { get; set; }
            
            public List<string> GostNames { get; set; }

            public string PipeName { get; set;}

            public double SDR { get; set;}
            
            public double Thickness { get; set;}
            
            public double Diametr { get; set;}
        }
    }
}
