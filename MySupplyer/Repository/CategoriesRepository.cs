using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class CategoriesRepository
    {
        private readonly SupplyerContext supplyerContext;

        public CategoriesRepository()
        {
            supplyerContext = new SupplyerContext();
        }

        public Category GetCategory(int id)
        {
            return supplyerContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category GetCategory(string categoryName)
        {
            return supplyerContext.Categories.SingleOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
        }
        
        public List<Category> GetCategories()
        {
            return supplyerContext.Categories.ToList();
        }
    }
}
