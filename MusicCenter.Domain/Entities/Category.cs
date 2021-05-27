using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Category Parent { get; set; }
    }
}
