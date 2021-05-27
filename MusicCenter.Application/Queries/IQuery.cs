using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries
{
    public interface IQuery<TResult> : IUseCase
    {
        TResult Execute();
    }

    public interface IQuery<TParam, TResult> : IUseCase
    {
        TResult Execute(TParam param);
    }
}
