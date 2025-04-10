using Microsoft.AspNetCore.Mvc;
using MySupplyer.Repository;

namespace MySupplyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipeWarehouseController: ControllerBase
    {
        private readonly PipeWarehouseRepository pipeWarehouseRepository;

        public PipeWarehouseController()
        {
            pipeWarehouseRepository = new PipeWarehouseRepository();
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
    }
}
