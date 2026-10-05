using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _contex;

        public DepartmentService(SalesWebMvcContext contex)
        {
            _contex = contex;
        }

        public List<Department> FindAll()
        {
            return _contex.Department.OrderBy(x=>x.Name).ToList();
        }





    }
}
