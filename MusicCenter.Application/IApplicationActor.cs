using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application
{
    public interface IApplicationActor
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public ICollection<int> AllowedUseCases { get; set; }
    }
}
