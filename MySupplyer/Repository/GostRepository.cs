namespace MySupplyer.Repository
{
    public class GostRepository
    {
        public readonly SupplyerContext supplyerContext;
        public GostRepository() 
        {
            supplyerContext = new SupplyerContext();
        }

        public List<string> GetAllGostName()
        {
            return supplyerContext.Gosts.Select(c => c.Name).ToList();
        }
    }
}
