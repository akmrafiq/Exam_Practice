using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Practice.Core.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
