using NetCore7WebAPI.Domain.Common;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Domain.Entities
{
    public class Brand :EntityBase
    {
        public Brand()
        {
                
        }
        public Brand(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}
