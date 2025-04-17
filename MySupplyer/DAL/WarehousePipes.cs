namespace MySupplyer.DAL
{
    public class WarehousePipes
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int PipeId { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<Pipe> Pipes { get; set; }

    }
}
