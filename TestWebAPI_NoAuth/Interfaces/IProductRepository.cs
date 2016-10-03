using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI_NoAuth.Models;

namespace TestWebAPI_NoAuth.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel GetDetails(int Id);
    }
}
