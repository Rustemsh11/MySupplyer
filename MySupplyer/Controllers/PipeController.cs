using Microsoft.AspNetCore.Mvc;
using MySupplyer.DAL;
using MySupplyer.Repository;
using System.Diagnostics.Contracts;

namespace MySupplyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipeController: ControllerBase
    {
        private readonly PipesRepository pipesRepository;
        private readonly CategoriesRepository categoriesRepository;
        private readonly GostRepository gostRepository;
        private readonly WarehousePipesRepository warehousePipesRepository;

        public PipeController()
        {
            pipesRepository = new PipesRepository();
            categoriesRepository = new CategoriesRepository();
            gostRepository = new GostRepository();
            warehousePipesRepository = new WarehousePipesRepository();
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

        [HttpGet("ReguestInfo")]
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

        [HttpGet("GetApplocablePipes")]
        public IActionResult GetApplicablePipes([FromBody] NeededPipeRequestData neededPipeRequestData) 
        {
            var category = categoriesRepository.GetCategory(neededPipeRequestData.CategoryName);
            var pipe = pipesRepository.GetPipesByGost(category.Id, neededPipeRequestData.GostName);
            var warehousesPipes = warehousePipesRepository.GetWarehousePipes(pipe.Select(c => c.Id).ToList());

            var pipesGroupedWithWareHouse = warehousesPipes.GroupBy(c => c.Warehouse);

            var res = new List<PipeResponse>();
            foreach (var item in pipesGroupedWithWareHouse)
            {
                var pipes = new List<PipeInfo>();
                foreach (var item2 in item)
                {
                    var pipeInfo = new PipeInfo()
                    {
                        CategoryName = item2.Pipe.Category.Name,
                        GostName = item2.Pipe.Gost.Name,
                        PipeName = item2.Pipe.Name,
                        SDR = item2.Pipe.SDR,
                        Thickness = item2.Pipe.Thickness,
                        Diametr = item2.Pipe.Diametr,
                        Price = item2.Pipe.Price,
                    };
                    pipes.Add(pipeInfo);
                }

                res.Add(new PipeResponse()
                {
                    WarehouseName = item.Key.Address,
                    PipeInfos = pipes
                });
            }

            return Ok(res);
        }

        public class PipeInfo
        {
            public string CategoryName { get; set; }
            public string GostName { get; set; }
            public string? PipeName { get; set; }
            public double SDR { get; set; }
            public double Thickness { get; set; }
            public double Diametr { get; set; }
            public double Price { get; set; }
        }

        public class PipeResponse
        {
            public string WarehouseName { get; set; }
            public List<PipeInfo> PipeInfos { get; set; }
        }

        public class NeededPipeRequestData
        {
            public string CategoryName { get; set; }

            public string GostName { get; set; }

            public string PipeName { get; set; }

            public double SDR { get; set; }

            public double Thickness { get; set; }

            public double Diametr { get; set; }
        }
        
        public class RequestInfoDto
        {
            public List<string> CategoryNames { get; set; }

            public List<string> GostNames { get; set; }

            public string PipeName { get; set; }

            public double SDR { get; set; }

            public double Thickness { get; set; }

            public double Diametr { get; set; }
        }
    }
}
