using MusicCenter.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace MusicCenter.Application
{
    public class UseCaseExecutor
    {
        private readonly IUseCaseLogger _logger;
        private readonly IApplicationActor _actor;

        public UseCaseExecutor(IUseCaseLogger logger, IApplicationActor actor)
        {
            _logger = logger;
            this._actor = actor;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logger.Log(command, _actor, request);

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }

            command.Execute(request);

        }
        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            _logger.Log(query, _actor, search);

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }

            return query.Execute(search);
        }

    }
}
