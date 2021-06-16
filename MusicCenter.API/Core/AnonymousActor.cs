using MusicCenter.Application;
using MusicCenter.Implementation;
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

        public AnonymousActor()
        {
            var getUseCases = UseCaseUtils.AllUseCases.Where(uc => uc.Name.Contains("Get"))
                                                        .Select(uc => uc.Id);

            var registerUseCase = UseCaseUtils.AllUseCases.First(uc => uc.Name == "Ef Create User").Id;

            foreach (var getUseCase in getUseCases)
                AllowedUseCases.Add(getUseCase);

            AllowedUseCases.Add(registerUseCase);
        }
    }
}
