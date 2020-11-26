using books_api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    { 
    }
}
