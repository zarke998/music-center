using MusicCenter.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id { get; set; }
        public string Identity { get; set; } = "Anonymous";
        public ICollection<int> AllowedUseCases { get; set; } = new List<int>();
    }
}
