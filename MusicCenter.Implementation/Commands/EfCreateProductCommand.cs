using AutoMapper;
using MusicCenter.Application.Commands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 3;
        public string Name => "Ef Create Product";

        public EfCreateProductCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(CreateProductDto request)
        {
            var product = _mapper.Map<Product>(request);

            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
