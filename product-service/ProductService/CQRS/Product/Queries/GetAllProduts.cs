using MediatR;
using Microsoft.EntityFrameworkCore;

// Query
public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }

// Handler
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetAllProductsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync();
    }
}
