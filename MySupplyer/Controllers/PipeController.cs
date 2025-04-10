using Microsoft.AspNetCore.Mvc;
using MySupplyer.DAL;
using MySupplyer.Repository;

namespace MySupplyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipeController: ControllerBase
    {
        private readonly PipesRepository pipesRepository;

        public PipeController()
        {
            pipesRepository = new PipesRepository();
        }

        [HttpGet]
        public IActionResult Pipes()
        {
            return Ok(pipesRepository.GetPipes());
        }

        [HttpGet("GetPipesByName/{categoryId:int}/{name}")]
        public IActionResult GetPipesByName(int categoryId, string name)
        {
            var d = pipesRepository.GetPipe(categoryId, name);
            return Ok(d);
        }

        [HttpGet("GetPipesByName/{categoryName}/{name}")]
        public IActionResult GetPipesByName(string categoryName, string name)
        {
            var d = pipesRepository.GetPipe(categoryName, name);
            return Ok(d);
        }

        //[HttpGet("GetPipesById/{id:int}")]
        //public IActionResult GetPipesById(int id)
        //{
        //    return Ok(pipesRepository.GetPipe(id));
        //}
    }
}
