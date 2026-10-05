using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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
        
        return _contex.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        
        }

        public void Remove(int id)
        {
            var obj = _contex.Seller.Find(id);
            _contex.Seller.Remove(obj);
            _contex.SaveChanges();
        }

        public void Updade(Seller obj)
        {
            if (!_contex.Seller.Any(x=> x.Id==obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _contex.Update(obj);
                _contex.SaveChanges();

            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
