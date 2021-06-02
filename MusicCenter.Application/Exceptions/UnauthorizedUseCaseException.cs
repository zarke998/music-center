using System;
using System.Runtime.Serialization;

namespace MusicCenter.Application.Exceptions
{
    [Serializable]
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor) : base($"Actor '{actor.Identity}' with id {actor.Id} is not allowed to execute use case '{useCase.Name}' with id {useCase.Id}")
        {

        }
    }
}