namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers = new List<Seller>();


        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void removeSeller(Seller seller)
        {
            Sellers.Remove(seller);

        }

        public double totalSales(DateTime initial, DateTime final)
        {

            return Sellers.Sum(seller=>seller.totalSales(initial,final));
              
        }

    }
}     
