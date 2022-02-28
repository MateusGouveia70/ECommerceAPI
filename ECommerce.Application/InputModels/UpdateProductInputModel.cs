using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.InputModels
{
    public class UpdateProductInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Brand { get; set; }
        public int Category_Id { get; set; }
    }
}
