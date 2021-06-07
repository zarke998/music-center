using MusicCenter.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public ICollection<int> AllowedUseCases { get; set; }
    }
}
