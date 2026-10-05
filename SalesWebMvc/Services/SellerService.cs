using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _contex;

        public SellerService(SalesWebMvcContext contex)
        {
            _contex = contex;
        }
        public List<Seller> FindAll()
        {
            return _contex.Seller.ToList();
        }
        public void Insert(Seller obj) {
        _contex.Add(obj);
        _contex.SaveChanges();
        }

    }
}
