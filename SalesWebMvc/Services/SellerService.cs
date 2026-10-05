using Microsoft.EntityFrameworkCore;
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

        public Seller FindById(int id) { 
        
        return _contex.Seller.FirstOrDefault(obj => obj.Id == id);
        
        }

        public void Remove(int id)
        {
            var obj = _contex.Seller.Find(id);
            _contex.Seller.Remove(obj);
            _contex.SaveChanges();
        }


    }
}
