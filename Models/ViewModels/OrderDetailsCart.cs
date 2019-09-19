using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_WebAPP.Models.ViewModels
{
    public class OrderDetailsCart
    {
        public List<ShopingCart> listCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
