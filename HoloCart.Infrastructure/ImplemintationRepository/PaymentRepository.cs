using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class PaymentRepository : GenericRepositoryAsync<Payment>, IPaymentRepository
    {
        private readonly DbSet<Payment> _payments;

        public PaymentRepository(AppDbContext dbContext) : base(dbContext)
        {

            _payments = dbContext.Set<Payment>();
        }
    }
}
