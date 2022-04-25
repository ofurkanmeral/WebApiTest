using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public List<ProductDto> Product { get; set; }
    }
}
