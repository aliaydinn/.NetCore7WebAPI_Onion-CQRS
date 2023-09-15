using NetCore7WebAPI.Domain.Common;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Domain.Entities
{
    public class Category :EntityBase
    {

        public Category()
        {
                
        }

        public Category(int parentId,string name,int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }
        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    
}

