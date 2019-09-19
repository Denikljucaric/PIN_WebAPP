using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_WebAPP.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
        public IEnumerable<Brand> Brand { get; set; }
        public IEnumerable<Carosel> Carosel { get; set; }
    }
}
