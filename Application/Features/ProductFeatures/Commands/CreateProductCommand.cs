using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Response<Product>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string ConfidentialData { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Product>>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Barcode = command.Barcode,
                    Name = command.Name,
                    Rate = command.Rate,
                    Description = command.Description,
                    BuyingPrice = command.BuyingPrice,
                    ConfidentialData = command.ConfidentialData
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken);

                return Response.Ok("Product is created successfuly", product);
            }
        }
    }
}
