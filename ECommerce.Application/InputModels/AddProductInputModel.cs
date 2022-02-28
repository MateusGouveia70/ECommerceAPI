using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.InputModels
{
    public class AddProductInputModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public decimal Value { get; private set; }
        public string Brand { get; private set; }
        public int Category_Id { get; private set; }
    }
}
