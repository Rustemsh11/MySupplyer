using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class PipeWarehouseRepository
    {
        private SupplyerContext context;

        public PipeWarehouseRepository()
        {
            this.context = new SupplyerContext();
        }

        public int GetWarehouseCount(int categoryId, int pipeId)
        {
            var pipe = context.Pipes.FirstOrDefault(c => c.CategoryId == categoryId && c.Id == pipeId);
            return context.PipeWarehouses.FirstOrDefault(c => c.PipeId == pipe.Id)?.Count ?? 0;
        }

        public List<Pipe> GetAllPipesInWarehouse()
        {
            return context.PipeWarehouses.Select(c=>c.Pipe).ToList();
        }
    }
}
