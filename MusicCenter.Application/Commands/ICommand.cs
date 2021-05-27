using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Commands
{
    public interface ICommand : IUseCase
    {
        void Execute();
    }

    public interface ICommand<TParam> : IUseCase
    {
        void Execute(TParam param);
    }
}
