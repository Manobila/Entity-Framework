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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _contex.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj) {
        _contex.Add(obj);
        await _contex.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) {

            return await _contex.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _contex.Seller.FindAsync(id);
            _contex.Seller.Remove(obj);
            await _contex.SaveChangesAsync();
        }

        public async Task UpdadeAsync(Seller obj)
        {
            bool hasAny = await _contex.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _contex.Update(obj);
                await _contex.SaveChangesAsync();

            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
