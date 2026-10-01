namespace SalesWebMvc.Models
{
    public class Seller 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public List<SalesRecord> sales {  get; set; }

        public void addSales(SalesRecord sr)
        {
            sales.Add(sr);
        }
        public void removeSales(SalesRecord sr)
        {
            sales.Remove(sr);
        }

      //  public double totalSales(DateTime initial,DateTime final)
      //  {

        //}





    }
}
