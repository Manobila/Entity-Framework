namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Seller> sellers { get; set; }



        public void addSeller(Seller seller)
        {
            sellers.Add(seller);
        }

        public void removeSeller(Seller seller)
        {
            sellers.Remove(seller);

        }













    }
}     
