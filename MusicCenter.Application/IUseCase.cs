﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application
{
    public interface IUseCase
    {
        public int Id { get; }
        public string Name { get; }
    }
}
