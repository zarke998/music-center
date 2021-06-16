using MusicCenter.Application;
using MusicCenter.Implementation.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation
{
    public static class UseCaseUtils
    {
        private static List<UseCaseInfo> _allUseCases;
        public static List<UseCaseInfo> AllUseCases
        {
            get
            {
                if(_allUseCases == null)
                {
                    _allUseCases = GetAllUseCases();
                }
                return _allUseCases;
            }
        }

        private static List<UseCaseInfo> GetAllUseCases()
        {
            var allUseCaseTypes = typeof(EfDeleteProductCommand).Assembly.GetTypes()
                                .Where(t => t.IsAssignableTo(typeof(IUseCase)));

            var allUseCases = new List<UseCaseInfo>();

            foreach (var useCase in allUseCaseTypes)
            {
                var useCaseInstance = FormatterServices.GetUninitializedObject(useCase) as IUseCase;
                allUseCases.Add(new UseCaseInfo()
                {
                    Id = useCaseInstance.Id,
                    Name = useCaseInstance.Name
                });
            }

            return allUseCases;
        }
    }

    public class UseCaseInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
