using MusicCenter.Application;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Loggers
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly MusicCenterDbContext _context;

        public DatabaseUseCaseLogger(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            if (actor.Id == 0)
                return;
            
            var useCaseLog = new UseCaseLog()
            {
                UseCaseId = useCase.Id,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(useCaseData),
                CreatedAt = DateTime.UtcNow,
                UserId = actor.Id
            };

            _context.UseCaseLogs.Add(useCaseLog);
            _context.SaveChanges();
        }
    }
}
