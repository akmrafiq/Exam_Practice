using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Practice.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual IList<ProductImage> ProductImages { get; set; }
    }
}
