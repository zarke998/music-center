using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.ProductCommands
{
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 4;
        public string Name => "Ef Update Product";

        public EfUpdateProductCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(UpdateProductDto request)
        {
            var product = _context.Products.Include(p => p.ProductCategories)
                                            .First(p => p.Id == request.Id);

            _mapper.Map(request, product);

            _context.SaveChanges();
        }
    }
}
