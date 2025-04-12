namespace MySupplyer.DAL
{
    public class Pipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int GostId { get; set; }
        public double SDR { get; set; }
        public double Thickness { get; set; }
        public double Diametr {  get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Gost Gost { get; set; }
    }
}
