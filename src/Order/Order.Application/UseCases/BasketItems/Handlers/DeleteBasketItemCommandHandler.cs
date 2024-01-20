namespace Order.Application.UseCases.BasketItems.Handlers
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteBasketItemCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var basketItem = await _applicationDbContext.BasketItems.FirstOrDefaultAsync(basketItem=>basketItem.BasketId==request.BasketId && basketItem.ProductId==request.ProductId);
                if (basketItem is null)
                    return false;
                _applicationDbContext.BasketItems.Remove(basketItem);
                var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

