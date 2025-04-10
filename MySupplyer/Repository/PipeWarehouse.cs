using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class PipeWarehouse
    {
        public int Id { get; set; }

        public int PipeId { get; set; }

        public int Count {  get; set; }

        public Pipe Pipe {  get; set; }
    }
}
