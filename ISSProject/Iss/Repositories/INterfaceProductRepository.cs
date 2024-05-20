using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface INterfaceProductRepository
    {
        ProductMock Product { get; set; }
    }
}
