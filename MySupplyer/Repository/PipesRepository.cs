using Microsoft.EntityFrameworkCore;
using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class PipesRepository
    {
        private readonly SupplyerContext supplyerContext;

        public PipesRepository()
        {
            supplyerContext = new SupplyerContext();
        }

        public Pipe GetPipe(int categoryId, int id)
        {
            return supplyerContext.Pipes.SingleOrDefault(c => c.CategoryId == categoryId &&  c.Id == id);
        }
        public Pipe GetPipe(int categoryId, string pipeName)
        {
            return supplyerContext.Pipes.SingleOrDefault(c => c.CategoryId == categoryId && c.Name.ToLower() == pipeName.ToLower());
        }
        public List<Pipe> GetPipesByGost(int categoryId, string gostName)
        {
            return supplyerContext.Pipes.Include(c=>c.Gost).Include(c=>c.Category).Where(c => c.CategoryId == categoryId && c.Gost.Name.ToLower() == gostName.ToLower()).ToList();
        }
        
        public Pipe GetPipe(string categoryName, int id)
        {
            return supplyerContext.Pipes.SingleOrDefault(c => c.Category.Name.ToLower() == categoryName.ToLower() &&  c.Id == id);
        }

        public Pipe GetPipe(string categoryName, string pipeName)
        {
            return supplyerContext.Pipes.SingleOrDefault(c => c.Category.Name.ToLower() == categoryName.ToLower() &&  c.Name.ToLower() == pipeName.ToLower());
        }

        public List<Pipe> GetPipes()
        {
            return supplyerContext.Pipes.ToList();
        }
    }
}
