using Microsoft.EntityFrameworkCore;
using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class WarehousePipesRepository
    {
        public readonly SupplyerContext supplyerContext;
        public WarehousePipesRepository()
        {
            supplyerContext = new SupplyerContext();
        }

        public List<WarehousePipes> GetWarehousePipes(List<int> pipeId)
        {
            return supplyerContext.WarehousePipes.Include(c=>c.Warehouse).Include(c=>c.Pipe).ThenInclude(c=>c.Category).Include(c=>c.Pipe).ThenInclude(c=>c.Gost).Where(c => pipeId.Contains(c.PipeId)).ToList();
        }
    }
}
